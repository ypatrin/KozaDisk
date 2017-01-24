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
        User User;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Constant.ApplcationStorage + @"app\login.cfg"))
            {
                //search users
                Users users = new Users();

                int i = 0;

                foreach (User user in users.getUsers())
                {
                    usersBox.Items.Add(user.UserName);

                    if (i == 0)
                    {
                        usersBox.Text = user.UserName;
                    }

                    i++;
                }

                //create user
                if (i == 0)
                {
                    this.NewUserPanel.Visible = true;
                    this.LoginPanel.Visible = false;
                }
                //import user
                else
                {
                    this.NewUserPanel.Visible = false;
                    this.LoginPanel.Visible = true;
                }
            }
            else
            {
                //login
                this.NewUserPanel.Visible = false;
                this.LoginPanel.Visible = true;

                this.usersBox.Visible = false;
                this.ImportButton.Visible = false;
                this.CreateButton.Visible = false;

                this.LoginButton.Visible = true;
                this.UserNameLbl.Visible = true;

                string userName = File.ReadAllText(Constant.ApplcationStorage + @"app\login.cfg");
                this.UserNameLbl.Text = userName;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.User = new User();

            this.NewUserPanel.Visible = true;
            this.LoginPanel.Visible = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = usersBox.Text;

            Users users = new Users();
            this.User = users.getUser(userName);

            this.UsernameBox.Text = this.User.UserName;
            this.EmailBox.Text = this.User.UserEmail;
            this.PhoneBox.Text = this.User.UserPhone;

            this.NewUserPanel.Visible = true;
            this.LoginPanel.Visible = false;
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
                this.User.UserName = this.UsernameBox.Text.Trim();
                this.User.UserEmail = this.EmailBox.Text.Trim();
                this.User.UserPhone = this.PhoneBox.Text.Trim();

                //save to xml
                string xml = "";
                var serializer = new XmlSerializer(typeof(User));
                using (StringWriter writer = new Utf8StringWriter())
                {
                    serializer.Serialize(writer, this.User);
                    xml = writer.ToString();
                }

                string UserStorage = Constant.ApplcationStorage + @"users\" + this.User.UserName;

                if (!Directory.Exists(UserStorage))
                {
                    Directory.CreateDirectory(UserStorage);
                }

                File.WriteAllText(UserStorage + @"\userdata.xml", xml);

                //save login info
                string AppStorage = Constant.ApplcationStorage + @"app\";

                if (!Directory.Exists(AppStorage))
                {
                    Directory.CreateDirectory(AppStorage);
                }

                File.WriteAllText(AppStorage + @"\login.cfg", this.User.UserName);

                //load user
                this.NewUserPanel.Visible = false;
                this.LoginPanel.Visible = true;

                this.usersBox.Visible = false;
                this.ImportButton.Visible = false;
                this.CreateButton.Visible = false;

                this.LoginButton.Visible = true;
                this.UserNameLbl.Visible = true;

                this.UserNameLbl.Text = this.User.UserName;
            }
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string userName = File.ReadAllText(Constant.ApplcationStorage + @"app\login.cfg");

            //login 
            Users users = new Users();
            User user = users.getUser(userName.Trim());

            //load application
            TemplatesList templatesList = new TemplatesList();
            templatesList.setUserData(user);
            templatesList.Show();

            this.Hide();
        }

        private void rightButton_MouseHover(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.FromArgb(26, 188, 156);
        }

        private void rightButton_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.FromArgb(62, 66, 70);
        }

        private void rightButtonImg_MouseHover(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Parent.BackColor = Color.FromArgb(26, 188, 156);
        }

        private void rightButtonLbl_MouseHover(object sender, EventArgs e)
        {
            Label pictureBox = (Label)sender;
            pictureBox.Parent.BackColor = Color.FromArgb(26, 188, 156);
        }

        private void rightButton_Maunal_Click(object sender, MouseEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Іструкція Коза-Диск 2.0.pdf";
            sfd.Filter = "PDF Файл|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                    File.Delete(sfd.FileName);

                File.Copy(Constant.ApplcationPath + "manual.pdf", sfd.FileName);
                MessageBox.Show("Файл успішно збережений!", "Допомога", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rightButton_Help_Click(object sender, MouseEventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void rightButton_Contacts_Click(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mcfr.ua/#contacts");
        }
    }
}
