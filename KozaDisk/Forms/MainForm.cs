using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            var addUserForm = new AddUserForm();
            addUserForm.ShowDialog();

            usersBox.Items.Clear();
            Users users = new Users();

            foreach (User user in users.getUsers())
            {
                usersBox.Items.Add(user.UserName);
            }
        }
    }
}
