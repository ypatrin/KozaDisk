using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Xml;

namespace KozaDisk.Forms
{
    public partial class Activate : Form
    {
        public User userData { get; set; }
        public string db { get; set; }
        public string key = "fbv8295_";

        public Activate()
        {
            InitializeComponent();
        }

        public void setDiskName(string diskName)
        {
            this.DiskNameLabel.Text = diskName;
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            //check code

            if (this.ActivateCodeBox.Text.Length != 24)
            {
                MessageBox.Show("Невірний код активації.", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.ActivateCodeBox.Text.Substring(4,1) != "-" && 
                this.ActivateCodeBox.Text.Substring(9, 1) != "-" &&
                this.ActivateCodeBox.Text.Substring(14, 1) != "-" &&
                this.ActivateCodeBox.Text.Substring(19, 1) != "-" )
            {
                MessageBox.Show("Невірний код активації.", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //prepare key
            DateTime now = DateTime.Now;
            this.key = this.key + now.ToString("ddMMyyyy");

            string cpuID = string.Empty;

            var mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
            var mbsList = mbs.Get();

            foreach (ManagementObject mo in mbsList)
            {
                cpuID = mo["ProcessorID"].ToString();
            }

            string xmlRequest = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>";
            xmlRequest += "<activation>";
            xmlRequest += "     <disk>";
            xmlRequest += $"        <name>{this.DiskNameLabel.Text}</name>"; //имя диска
            xmlRequest += $"        <id>{this.db}</id>"; // ID диска
            xmlRequest += $"        <key>{this.ActivateCodeBox.Text.Replace("-","")}</key>"; // ключ диска, который ввел юзер в окне активации
            xmlRequest += "     </disk>";
            xmlRequest += "     <user>";
            xmlRequest += $"        <email>{userData.UserEmail}</email>"; // Мыло юзера
            xmlRequest += $"        <full_name>{userData.UserName}</full_name>"; // ФИО юзера
            xmlRequest += $"        <phone>{userData.UserPhone}</phone>"; // ФИО юзера
            xmlRequest += $"        <app_code>{cpuID}</app_code>"; // ID приложения (уникальное для каждого юзера)
            xmlRequest += "     </user>";
            xmlRequest += "</activation>";

            string xmlEncoded = Class.CryptAes.Encrypt(xmlRequest, this.key);

            try
            {
                //send request
                string activeAnswer = Class.Request.POST(@"http://kozaonline.com.ua/kozadisc/activation", "XML_DATA=" + xmlEncoded);
                //decrypt answer
                string activeAnswerDecode = Class.CryptAes.Decrypt(activeAnswer, this.key);

                //parse xml
                XmlDocument answerXml = new XmlDocument();
                answerXml.LoadXml(activeAnswerDecode);

                XmlElement root = answerXml.DocumentElement;
                XmlNode status = root.SelectSingleNode($"activate_status/status");

                string activateStatus = status.InnerText;

                //activate
                if (activateStatus == "Error")
                {
                    MessageBox.Show("Невірний код активації. Спробуйте ще раз!", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (activateStatus == "Activated")
                {
                    MessageBox.Show("Цей код вже активовано. Введіть будь ласка інший код.", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (activateStatus == "OK")
                {
                    XmlNode activationKey = root.SelectSingleNode($"activate_status/activation_key");

                    KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
                    activator.activate(this.db, activationKey.InnerText);

                    MessageBox.Show("Активацію успішно виконано!", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Помилка сервера активації. Спробуйте ще раз пізніше!", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
