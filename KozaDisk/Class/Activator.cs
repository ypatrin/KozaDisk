using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace KozaDisk.Class
{
    /// <summary>
    /// Активатор дисков
    /// </summary>
    class Activator
    {
        /// <summary>
        /// Activator config
        /// </summary>
        private XmlDocument Config;

        /// <summary>
        /// Activator config file
        /// </summary>
        string ConfigFile = KozaDisk.Constant.ApplcationStorage + @"db\acd\disk.xml";

        /// <summary>
        /// Активатор дисков
        /// </summary>
        public Activator()
        {
            this._loadConfig();
        }

        /// <summary>
        /// Активирован ли диск
        /// </summary>
        /// <param name="db">Имя БД</param>
        /// <returns></returns>
        public bool isActivated(string db)
        {
            XmlElement root = this.Config.DocumentElement;

            try
            {
                XmlNode disk = root.SelectSingleNode($"db_{db}");
                string activeStatus = disk.SelectSingleNode("activeStatus").InnerText.ToString();

                if (activeStatus == "active")
                    return true;
                else
                    return false;                                
            }
            catch(Exception ex)
            {
                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddDays(31);

                //create db node
                XmlElement dbElem = this.Config.CreateElement("db_"+db);
                dbElem.InnerXml = $"<activeStatus>inactive</activeStatus><key></key>";

                //add db to config xml
                root.AppendChild(dbElem);

                this._saveConfig();

                return false;
            }
        }

        /// <summary>
        /// Получает количество оставшихся дней триала диска
        /// </summary>
        /// <param name="db">Имя БД</param>
        /// <returns></returns>
        public string getTrialDays(string db)
        {
            string days = "0";

            XmlElement root = this.Config.DocumentElement;

            if (db.Trim() == "2017.1.db")
            {
                DateTime startDate = Convert.ToDateTime("07/02/2017");
                DateTime endDate = startDate.AddDays(30);
                DateTime now = DateTime.Now;

                days = (endDate - now).TotalDays.ToString();

                if (days.IndexOf(',') != -1)
                    days = days.Remove(days.IndexOf(','));

                if (days.IndexOf('.') != -1)
                    days = days.Remove(days.IndexOf(','));
            }

            return days;
        }

        /// <summary>
        /// Доступен ли триал для данного диска
        /// </summary>
        /// <param name="db">Имя БД</param>
        /// <returns></returns>
        public bool isTrial(string db)
        {
            string days = getTrialDays(db);

            if (Int32.Parse(days) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Активация диска
        /// </summary>
        /// <param name="db">Имя БД</param>
        /// <param name="key">Ключ активации</param>
        public void activate(string db, string key)
        {
            XmlElement root = this.Config.DocumentElement;

            XmlNode disk = root.SelectSingleNode($"db_{db}");
            disk.SelectSingleNode("activeStatus").InnerText = "active";
            disk.SelectSingleNode("key").InnerText = key;

            this._saveConfig();
        }

        /// <summary>
        /// Load config of activator
        /// </summary>
        private void _loadConfig()
        {
            if (!Directory.Exists(KozaDisk.Constant.ApplcationStorage + @"db\acd\"))
            {
                Directory.CreateDirectory(KozaDisk.Constant.ApplcationStorage + @"db\acd\");
            }

            if (!File.Exists(this.ConfigFile))
            {               
                //create base config
                string xmlBaseConfig = "<?xml version=\"1.0\" encoding=\"utf-8\"?><activator></activator>";
                string xmlBaseConfigEnc = KozaDisk.Encrypt.Base64.Encode(xmlBaseConfig);
                File.WriteAllText(this.ConfigFile, xmlBaseConfigEnc);
            }

            //read config
            string configFileText = KozaDisk.Encrypt.Base64.Decode(File.ReadAllText(this.ConfigFile));

            XmlDocument configXml = new XmlDocument();
            configXml.LoadXml(configFileText);

            this.Config = configXml;
        }

        /// <summary>
        /// Save activator config
        /// </summary>
        private void _saveConfig()
        {
            //save config
            string xmlBaseConfig = this.Config.InnerXml.ToString();
            string xmlBaseConfigEnc = KozaDisk.Encrypt.Base64.Encode(xmlBaseConfig);
            File.Delete(this.ConfigFile);
            File.WriteAllText(this.ConfigFile, xmlBaseConfigEnc);
        }
    }
}
