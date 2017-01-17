using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KozaDisk.Forms;
using System.Xml.Serialization;

namespace KozaDisk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Users users = new Users();

            int i = 0;

            foreach(User user in users.getUsers())
            {
                usersBox.Items.Add(user.UserName);

                if (i == 0)
                {
                    usersBox.Text = user.UserName;
                }

                i++;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.NewUserPanel.Visible = true;
            this.LoginPanel.Visible = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = usersBox.Text;

            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Оберіть будь ласка користувача.", "KozaDisk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Users users = new Users();
            User user = users.getUser(userName);

            TemplatesList templatesList = new TemplatesList();
            templatesList.setUserData(user);
            templatesList.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check if all required fild s are filled
            if (this.UsernameBox.Text.Trim() == "" || this.EmailBox.Text.Trim() == "")
            {
                MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //fill user object
                User newUser = new User();
                newUser.UserName = this.UsernameBox.Text.Trim();
                newUser.UserEmail = this.EmailBox.Text.Trim();
                newUser.UserPhone = this.PhoneBox.Text.Trim();

                //save to xml
                string xml = "";
                var serializer = new XmlSerializer(typeof(User));
                using (StringWriter writer = new Utf8StringWriter())
                {
                    serializer.Serialize(writer, newUser);
                    xml = writer.ToString();
                }

                string UserStorage = Constant.ApplcationStorage + @"users\" + newUser.UserName;

                if (!Directory.Exists(UserStorage))
                {
                    Directory.CreateDirectory(UserStorage);
                }

                File.WriteAllText(UserStorage + @"\userdata.xml", xml);

                //update users list
                usersBox.Items.Clear();
                Users users = new Users();

                foreach (User user in users.getUsers())
                {
                    usersBox.Items.Add(user.UserName);
                }

                usersBox.Text = newUser.UserName;

                this.NewUserPanel.Visible = false;
                this.LoginPanel.Visible = true;
            }
        }
    }
}
