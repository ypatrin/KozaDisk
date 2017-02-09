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
        public string remainingDays = "0";

        //relation
        protected string _relationDiskName = null;
        protected string _relationDiskDb = null;

        public Activate(string days)
        {
            InitializeComponent();
            if (Int32.Parse(days) <= 0)
            {
                this.button1.Visible = false;
            }
            else
            {
                this.remainingDays = days;
            }
        }

        public void setDiskName(string diskName)
        {
            this.DiskNameLabel.Text = diskName;
        }

        public void setRelationDiskName(string diskName)
        {
            this._relationDiskName = diskName;
        }

        public void setRelationDiskDb(string diskDb)
        {
            this._relationDiskDb = diskDb;
        }

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            ActivateErrorForm activateError = new ActivateErrorForm();
            ActivateError2Form activateError2 = new ActivateError2Form();
            ActivateOkForm activateOk = new ActivateOkForm();

            //prepare key
            DateTime now = DateTime.Now;
            string encKey = this.key + now.ToString("ddMMyyyy");

            //check code

            if (this.ActivateCodeBox.Text.Length != 24)
            {
                this.Visible = false;
                activateError.ShowDialog();
                this.Visible = true;
                
                return;
            }

            if (this.ActivateCodeBox.Text.Substring(4,1) != "-" && 
                this.ActivateCodeBox.Text.Substring(9, 1) != "-" &&
                this.ActivateCodeBox.Text.Substring(14, 1) != "-" &&
                this.ActivateCodeBox.Text.Substring(19, 1) != "-" )
            {
                this.Visible = false;
                activateError.ShowDialog();
                this.Visible = true;

                return;
            }

            string cpuID = string.Empty;
            string mbID = String.Empty;

            // Get processor ID
            var cpu = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
            var cpuList = cpu.Get();

            foreach (ManagementObject mo in cpuList)
            {
                cpuID = mo["ProcessorID"].ToString();
            }

            //get MainBorad id
            var mainboard = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            var mainboardList = cpu.Get();

            foreach (ManagementObject mo in mainboardList)
            {
                mbID = mo["ProcessorID"].ToString();
            }

            string secret = KozaDisk.Encrypt.Base64.Encode($"processor:{cpuID};mainboard:{mbID}");

            string userPhone = userData.UserPhone;

            if (userPhone == "+38(   )   -  -")
                userPhone = "";

            string xmlRequest = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>";
            xmlRequest += "<activation>";
            xmlRequest += "     <disk>";
            xmlRequest += $"        <name>{this.DiskNameLabel.Text}</name>"; //имя диска
            xmlRequest += $"        <id>{this.db}</id>"; // ID диска
            xmlRequest += $"        <key>{this.ActivateCodeBox.Text.Replace("-","")}</key>"; // ключ диска, который ввел юзер в окне активации
            xmlRequest += "     </disk>";

            if (this._relationDiskDb != null && this._relationDiskName != null)
            {
                xmlRequest += "     <relation_disk>";
                xmlRequest += $"        <name>{this._relationDiskName}</name>"; //имя диска
                xmlRequest += $"        <id>{this._relationDiskDb}</id>"; // ID диска
                xmlRequest += "     </relation_disk>";
            }

            xmlRequest += "     <user>";
            xmlRequest += $"        <email>{userData.UserEmail}</email>"; // Мыло юзера
            xmlRequest += $"        <full_name>{userData.UserName}</full_name>"; // ФИО юзера
            xmlRequest += $"        <phone>{userPhone}</phone>"; // ФИО юзера
            xmlRequest += $"        <app_code>{secret}</app_code>"; // ID приложения (уникальное для каждого юзера)
            xmlRequest += "     </user>";
            xmlRequest += "</activation>";

            string xmlEncoded = Class.CryptAes.Encrypt(xmlRequest, encKey);

            try
            {
                //send request
                string activeAnswer = Class.Request.POST(@"http://kozaonline.com.ua/kozadisc/activation", "XML_DATA=" + xmlEncoded);
                //decrypt answer
                string activeAnswerDecode = Class.CryptAes.Decrypt(activeAnswer, encKey);

                //parse xml
                XmlDocument answerXml = new XmlDocument();
                answerXml.LoadXml(activeAnswerDecode);

                XmlElement root = answerXml.DocumentElement;
                XmlNode status = root.SelectSingleNode($"activate_status/status");

                string activateStatus = status.InnerText;

                //activate
                if (activateStatus == "Error")
                {
                    this.Visible = false;
                    activateError.ShowDialog();
                    this.Visible = true;
                }
                if (activateStatus == "Activated")
                {
                    this.Visible = false;
                    activateError2.ShowDialog();
                    this.Visible = true;
                }
                if (activateStatus == "OK")
                {
                    XmlNode activationKey = root.SelectSingleNode($"activate_status/activation_key");

                    KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
                    activator.activate(this.db, activationKey.InnerText);
                    activator.activate(this._relationDiskDb, activationKey.InnerText);

                    this.Visible = false;
                    activateOk.ShowDialog();
                    this.Close();
                }
            } catch(Exception ex)
            {
                this.Visible = false;
                activateError.ShowDialog();
                this.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            KozaDisk.Forms.TrialForm trial = new TrialForm(this.remainingDays);
            trial.ShowDialog();
            this.Close();
        }

        private void Activate_Load(object sender, EventArgs e)
        {

        }
    }
}
