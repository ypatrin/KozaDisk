using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using System.Drawing.Text;

namespace KozaDisk.Forms
{
    public partial class AutofillForm : System.Windows.Forms.Form
    {
        public AutofillForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TabButton1_Click(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 0;

            TabButton1.Enabled = false;
            TabButton2.Enabled = true;
            TabButton3.Enabled = true;

            TabButton1.ForeColor = Color.FromArgb(27, 188, 155);
            TabButton2.ForeColor = Color.White;
            TabButton3.ForeColor = Color.White;

            TabButton1.BackColor = Color.White;
            TabButton2.BackColor = Color.FromArgb(21, 168, 139);
            TabButton3.BackColor = Color.FromArgb(21, 168, 139);

            TabButton1.FlatAppearance.BorderSize = 1;
            TabButton2.FlatAppearance.BorderSize = 0;
            TabButton3.FlatAppearance.BorderSize = 0;
        }

        private void TabButton2_Click(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 1;
            TabButton1.Enabled = true;
            TabButton2.Enabled = false;
            TabButton3.Enabled = true;

            TabButton1.ForeColor = Color.White;
            TabButton2.ForeColor = Color.FromArgb(27, 188, 155);
            TabButton3.ForeColor = Color.White;

            TabButton1.BackColor = Color.FromArgb(21, 168, 139);
            TabButton2.BackColor = Color.White;
            TabButton3.BackColor = Color.FromArgb(21, 168, 139);

            TabButton1.FlatAppearance.BorderSize = 0;
            TabButton2.FlatAppearance.BorderSize = 1;
            TabButton3.FlatAppearance.BorderSize = 0;
        }

        private void TabButton3_Click(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 2;

            TabButton1.Enabled = true;
            TabButton2.Enabled = true;
            TabButton3.Enabled = false;

            TabButton1.ForeColor = Color.White;
            TabButton2.ForeColor = Color.White;
            TabButton3.ForeColor = Color.FromArgb(27, 188, 155);

            TabButton1.BackColor = Color.FromArgb(21, 168, 139);
            TabButton2.BackColor = Color.FromArgb(21, 168, 139);
            TabButton3.BackColor = Color.White;

            TabButton1.FlatAppearance.BorderSize = 0;
            TabButton2.FlatAppearance.BorderSize = 0;
            TabButton3.FlatAppearance.BorderSize = 1;
        }

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (String.IsNullOrEmpty(this.UserNameBox.Text))
            {
                MessageBox.Show("Ім'я користувача не може бути порожнім!", "Створення користувача", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                user.UserName = this.UserNameBox.Text;
                user.Abbreviation = this.AbbreviationBox.Text;
                user.AbbreviationGenitive = this.AbbreviationGenitiveBox.Text;
                user.Address = this.AddressBox.Text;
                user.Bank = this.BankBox.Text;
                user.ChiefInitials = this.ChiefInitialsBox.Text;
                user.ChiefName = this.ChiefNameBox.Text;
                user.ChiefNameGenitive = this.ChiefNameGenitiveBox.Text;
                user.ChiefPosition = this.ChiefPositionBox.Text;
                user.ChiefPositionDative = this.ChiefPositionDativeBox.Text;
                user.ChiefPositionLower = this.ChiefPositionLowerBox.Text;
                user.ChiefSurname = this.ChiefSurnameBox.Text;
                user.ChiefSurnameDative = this.ChiefSurnameDativeBox.Text;
                user.Code = this.CodeBox.Text;
                user.Email = this.EmailBox.Text;
                user.Fax = this.FaxBox.Text;
                user.FullName = this.FullNameBox.Text;
                user.FullNameGenitive = this.FullNameGenitiveBox.Text;
                user.InitialsCadre = this.InitialsCadreBox.Text;
                user.LegalAddress = this.LegalAddressBox.Text;
                user.Place = this.PlaceBox.Text;
                user.PositionCadre = this.PositionCadreBox.Text;
                user.PositionCadreGenitive = this.PositionCadreGenitiveBox.Text;
                user.Subordination = this.SubordinationBox.Text;
                user.SubordinationGenitive = this.SubordinationGenitiveBox.Text;
                user.SurnameCadre = this.SurnameCadreBox.Text;
                user.Telephone = this.TelephoneBox.Text;
                user.Unit = this.UnitBox.Text;

                string xml = "";
                XmlSerializer serializer = new XmlSerializer(user.GetType());

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        serializer.Serialize(writer, user);
                        xml = sww.ToString();
                    }
                }

                string UserStorage = Constant.ApplcationStorage + @"users\" + user.UserName;

                if (!Directory.Exists(UserStorage))
                {
                    Directory.CreateDirectory(UserStorage);
                }

                File.WriteAllText(UserStorage + @"\userdata.xml", xml);

                MessageBox.Show("Користувача успішно створено.", "Створення користувача", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
