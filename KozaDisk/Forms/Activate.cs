using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

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

            string xmlRequest = "";
            xmlRequest += "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>";
            xmlRequest += "<activation>";
            xmlRequest += "     <disk>";
            xmlRequest += $"        <name>{this.DiskNameLabel.Text}</name>"; //имя диска
            xmlRequest += "         <id>INT</id>"; // ID диска
            xmlRequest += $"        <key>{this.ActivateCodeBox.Text}</key>"; // ключ диска, который ввел юзер в окне активации
            xmlRequest += "     </disk>";
            xmlRequest += "     <user>";
            xmlRequest += $"        <email>{userData.Email}</email>"; // Мыло юзера
            xmlRequest += $"        <full_name>{userData.UserName}</full_name>"; // ФИО юзера
            xmlRequest += $"        <app_code>{cpuID}</app_code>"; // ID приложения (уникальное для каждого юзера)
            xmlRequest += "     </user>";
            xmlRequest += "</ activation>";

            string xmlEncoded = Class.CryptAesCBC.EncryptStringAES(xmlRequest, this.key);

            string activeAnswer = Class.Request.POST(@"http://kozaonline.com.ua/kozadisc/activation", "XML_DATA=" + xmlEncoded);
            //MessageBox.Show(activeAnswer);

            //activate OK

            KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
            activator.activate(this.db, "1414-6817-4189-6510-2069");

            MessageBox.Show("Активацію успішно виконано!", "Активація", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
