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

            foreach(User user in users.getUsers())
            {
                usersBox.Items.Add(user.UserName);
            }
        }

        private void CreateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var autoFillForm = new Forms.AutofillForm();
            autoFillForm.ShowDialog();

            usersBox.Items.Clear();
            Users users = new Users();

            foreach (User user in users.getUsers())
            {
                usersBox.Items.Add(user.UserName);
            }
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
    }
}
