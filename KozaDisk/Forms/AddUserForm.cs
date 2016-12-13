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

namespace KozaDisk
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
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

        private void CreateUserBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
