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
        private int mode = 0; //0 - create, 1 - modify
        private User userData;
        public AutofillForm()
        {
            InitializeComponent();
            this.mode = 0;
        }

        public AutofillForm(User user)
        {
            InitializeComponent();
            this.setUser(user);
            this.mode = 1;
        }

        public void setUser(User user)
        {
            this.AbbreviationBox.Text = user.Abbreviation ;
            this.AbbreviationGenitiveBox.Text = user.AbbreviationGenitive;
            this.AddressBox.Text = user.Address;
            this.BankBox.Text = user.Bank;
            this.ChiefInitialsBox.Text = user.ChiefInitials;
            this.ChiefNameBox.Text = user.ChiefName;
            this.ChiefNameGenitiveBox.Text = user.ChiefNameGenitive;
            this.ChiefPositionBox.Text = user.ChiefPosition;
            this.ChiefPositionDativeBox.Text = user.ChiefPositionDative;
            this.ChiefPositionLowerBox.Text = user.ChiefPositionLower;
            this.ChiefSurnameBox.Text = user.ChiefSurname;
            this.ChiefSurnameDativeBox.Text = user.ChiefSurnameDative;
            this.CodeBox.Text = user.Code;
            this.EmailBox.Text = user.Email;
            this.FaxBox.Text = user.Fax;
            this.FullNameBox.Text = user.FullName;
            this.FullNameGenitiveBox.Text = user.FullNameGenitive;
            this.InitialsCadreBox.Text = user.InitialsCadre;
            this.LegalAddressBox.Text = user.LegalAddress;
            this.PlaceBox.Text = user.Place;
            this.PositionCadreBox.Text = user.PositionCadre;
            this.PositionCadreGenitiveBox.Text = user.PositionCadreGenitive;
            this.SubordinationBox.Text = user.Subordination;
            this.SubordinationGenitiveBox.Text = user.SubordinationGenitive;
            this.SurnameCadreBox.Text = user.SurnameCadre;
            this.TelephoneBox.Text = user.Telephone;
            this.UnitBox.Text = user.Unit;

            this.userData = user;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TabButton1_Click(object sender, EventArgs e)
        {

        }

        private void TabButton2_Click(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 0;
            TabButton2.Enabled = false;
            TabButton3.Enabled = true;

            TabButton2.ForeColor = Color.FromArgb(27, 188, 155);
            TabButton3.ForeColor = Color.White;

            TabButton2.BackColor = Color.White;
            TabButton3.BackColor = Color.FromArgb(21, 168, 139);

            TabButton2.FlatAppearance.BorderSize = 1;
            TabButton3.FlatAppearance.BorderSize = 0;
        }

        private void TabButton3_Click(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 1;

            TabButton2.Enabled = true;
            TabButton3.Enabled = false;

            TabButton2.ForeColor = Color.White;
            TabButton3.ForeColor = Color.FromArgb(27, 188, 155);

            TabButton2.BackColor = Color.FromArgb(21, 168, 139);
            TabButton3.BackColor = Color.White;

            TabButton2.FlatAppearance.BorderSize = 0;
            TabButton3.FlatAppearance.BorderSize = 1;
        }

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.UserName = this.userData.UserName;
            user.UserEmail = this.userData.UserEmail;
            user.UserPhone = this.userData.UserPhone;

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

                var serializer = new XmlSerializer(typeof(User));
                using (StringWriter writer = new Utf8StringWriter())
                {
                    serializer.Serialize(writer, user);
                    xml = writer.ToString();
                }

                string UserStorage = Constant.ApplcationStorage + @"users\" + user.UserName;

                if (!Directory.Exists(UserStorage))
                {
                    Directory.CreateDirectory(UserStorage);
                }

                File.WriteAllText(UserStorage + @"\userdata.xml", xml);

                MessageBox.Show("Дані користувача успішно сбережено.", "Автозаповнення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutofillForm_Load(object sender, EventArgs e)
        {
            this.Tabs.SelectedIndex = 0;
            TabButton2.Enabled = false;
            TabButton3.Enabled = true;

            TabButton2.ForeColor = Color.FromArgb(27, 188, 155);
            TabButton3.ForeColor = Color.White;

            TabButton2.BackColor = Color.White;
            TabButton3.BackColor = Color.FromArgb(21, 168, 139);

            TabButton2.FlatAppearance.BorderSize = 1;
            TabButton3.FlatAppearance.BorderSize = 0;
        }
    }
}
