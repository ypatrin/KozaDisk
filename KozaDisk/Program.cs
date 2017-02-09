using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace KozaDisk
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            //create app data folders

            if (!Directory.Exists(Constant.ApplcationStorage))
                Directory.CreateDirectory(Constant.ApplcationStorage);

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\");

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\cd\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\cd\");

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\xml\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\xml\");

            if (!Directory.Exists(Constant.ApplcationStorage + @"users\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"users\");

            //seach old users
            string oldKozaPath = Constant.MyDocumentsPath + @"\" + Constant.OldKozaName + @"\";

            if (Directory.Exists(oldKozaPath + "app"))
                oldKozaPath += @"app\";
            else
                oldKozaPath += @"koza\";

            if(!Directory.Exists(oldKozaPath))
            {
                copyDbFromCd();
                Program.openForm();
            }
            else
            {
                try
                {
                    //if old koza have users path
                    if (Directory.Exists(oldKozaPath + @"UserFiles\"))
                    {
                        //search folders
                        string[] directories = Directory.GetDirectories(oldKozaPath + @"UserFiles\");

                        foreach (string directory in directories)
                        {
                            string userName = Path.GetFileName(directory);

                            string UserStorage = Constant.ApplcationStorage + @"users\" + userName;

                            if (Directory.Exists(UserStorage))
                                continue;

                            if (File.Exists(directory + @"\constants.ini"))
                            {
                                //init user object
                                var user = new User();
                                user.UserName = userName;

                                string[] constLines = System.IO.File.ReadAllLines(directory + @"\constants.ini");

                                foreach (string constLine in constLines)
                                {
                                    string constName = constLine.Split('=')[0] ?? "";
                                    string constVal = constLine.Split('=')[1] ?? "";

                                    switch (constName)
                                    {
                                        case "Повна назва організації":
                                            user.FullName = constVal;
                                            break;
                                        case "Повна назва організації у родовому відмінку з малої літери":
                                            user.FullNameGenitive = constVal;
                                            break;
                                        case "Скорочена назва організації у родовому відмінку":
                                            user.AbbreviationGenitive = constVal;
                                            break;
                                        case "Скорочена назва організації":
                                            user.AbbreviationGenitive = constVal;
                                            break;
                                        case "Назва організації вищого рівня":
                                            user.Subordination = constVal;
                                            break;
                                        case "Назва організації вищого рівня у родовому відмінку":
                                            user.SubordinationGenitive = constVal;
                                            break;
                                        case "Місце складання документів":
                                            user.Place = constVal;
                                            break;
                                        case "Код ЄДРПОУ":
                                            user.Code = constVal;
                                            break;
                                        case "Банківські реквізити":
                                            user.Bank = constVal;
                                            break;
                                        case "Юридична адреса":
                                            user.LegalAddress = constVal;
                                            break;
                                        case "Прізвище, ім’я, по батькові керівника":
                                            user.ChiefName = constVal;
                                            break;
                                        case "Прізвище та ініціали керівника":
                                            user.ChiefSurname = constVal;
                                            break;
                                        case "Прізвище та ініціали керівника у давальному відмінку":
                                            user.ChiefSurnameDative = constVal;
                                            break;
                                        case "Ініціали та прізвище керівника":
                                            user.ChiefInitials = constVal;
                                            break;
                                        case "Посада керівника з великої літери":
                                            user.ChiefPosition = constVal;
                                            break;
                                        case "Посада керівника у давальному відмінку з великої літери":
                                            user.ChiefPositionDative = constVal;
                                            break;
                                        case "Посада керівника у родовому відмінку з малої літери":
                                            user.ChiefPositionLower = constVal;
                                            break;
                                        case "Посада керівника з малої літери в родовому відмінку":
                                            user.ChiefPositionLower = constVal;
                                            break;
                                        case "Поштова адреса організації":
                                            user.Address = constVal;
                                            break;
                                        case "Телефон":
                                            user.Telephone = constVal;
                                            break;
                                        case "Факс":
                                            user.Fax = constVal;
                                            break;
                                        case "Електронна адреса":
                                            user.Email = constVal;
                                            break;
                                    }
                                }

                                //save to xml
                                string xml = "";

                                var serializer = new XmlSerializer(typeof(User));
                                using (StringWriter writer = new Utf8StringWriter())
                                {
                                    serializer.Serialize(writer, user);
                                    xml = writer.ToString();
                                }

                                //save xml

                                if (!Directory.Exists(UserStorage))
                                {
                                    Directory.CreateDirectory(UserStorage);
                                }

                                File.WriteAllText(UserStorage + @"\userdata.xml", xml);
                            }
                        }
                    }
                }
                catch (Exception ex) { }

                //copy db from cd
                copyDbFromCd();

                //open form
                Program.openForm();
            }
        }

        static void copyDbFromCdSingle(string diskFolder)
        {
            string xmlFile = diskFolder + "disk.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);

            Disk disk = new Disk();

            disk.name = doc.DocumentElement.SelectSingleNode("/disk/name").InnerText;
            disk.description = doc.DocumentElement.SelectSingleNode("/disk/description").InnerText;
            disk.edition = doc.DocumentElement.SelectSingleNode("/disk/edition").InnerText; ;
            disk.db = doc.DocumentElement.SelectSingleNode("/disk/db").InnerText;

            string source_disk_db = diskFolder + disk.db;
            string destination_disk_db = Constant.ApplcationStorage + @"db\cd\" + disk.db;

            string source_disk_xml = diskFolder + "disk.xml";
            string destination_disk_xml = Constant.ApplcationStorage + @"db\xml\" + disk.edition + ".xml";

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\cd\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\cd\");

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\xml\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\xml\");

            //check if disk added
            if (!File.Exists(destination_disk_xml))
            {
                //copy
                File.Copy(source_disk_db, destination_disk_db);
                File.Copy(source_disk_xml, destination_disk_xml);

                File.SetAttributes(destination_disk_db, FileAttributes.Normal);
                File.SetAttributes(destination_disk_xml, FileAttributes.Normal);
            }
        }

        static void copyDbFromCdDouble(string diskFolder)
        {
            string xmlFile = diskFolder + "disks.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);

            XmlNodeList disks = doc.DocumentElement.SelectNodes("/KozaDisk/disks/disk");

            Disk disk_1 = new Disk();

            disk_1.name = disks[0].SelectSingleNode("name").InnerText;
            disk_1.description = disks[0].SelectSingleNode("description").InnerText;
            disk_1.edition = disks[0].SelectSingleNode("edition").InnerText; ;
            disk_1.db = disks[0].SelectSingleNode("db").InnerText;

            Disk disk_2 = new Disk();

            disk_2.name = disks[1].SelectSingleNode("name").InnerText;
            disk_2.description = disks[1].SelectSingleNode("description").InnerText;
            disk_2.edition = disks[1].SelectSingleNode("edition").InnerText; ;
            disk_2.db = disks[1].SelectSingleNode("db").InnerText;

            string disk1Xml = "";
            string disk2Xml = "";

            disk1Xml += $"<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            disk1Xml += $"<disk>";
            disk1Xml += $"    <name>{disk_1.name}</name>";
            disk1Xml += $"    <description>{disk_1.description}</description>";
            disk1Xml += $"    <edition>{disk_1.edition}</edition>";
            disk1Xml += $"    <db>{disk_1.db}</db>";
            disk1Xml += $"    <relation>{disk_2.db.Replace(".db", "")}.xml</relation>";
            disk1Xml += $"</disk> ";

            disk2Xml += $"<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            disk2Xml += $"<disk>";
            disk2Xml += $"    <name>{disk_2.name}</name>";
            disk2Xml += $"    <description>{disk_2.description}</description>";
            disk2Xml += $"    <edition>{disk_2.edition}</edition>";
            disk2Xml += $"    <db>{disk_2.db}</db>";
            disk2Xml += $"    <relation>{disk_1.db.Replace(".db", "")}.xml</relation>";
            disk2Xml += $"</disk> ";

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\xml\"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\xml\");

            //save xml
            string disk_1_path = Constant.ApplcationStorage + @"db\xml\" + disk_1.db.Replace(".db","") + ".xml";
            string disk_2_path = Constant.ApplcationStorage + @"db\xml\" + disk_2.db.Replace(".db", "") + ".xml";

            if (!File.Exists(disk_1_path))
                File.WriteAllText(disk_1_path, disk1Xml);

            if (!File.Exists(disk_2_path))
                File.WriteAllText(disk_2_path, disk2Xml);

            //copy db
            string disk_1_db_path = Constant.ApplcationStorage + @"db\cd\" + disk_1.db;
            string disk_2_db_path = Constant.ApplcationStorage + @"db\cd\" + disk_2.db;
            string disk_1_db_source = diskFolder + disk_1.db;
            string disk_2_db_source = diskFolder + disk_2.db;

            if (!File.Exists(disk_1_db_path))
                File.Copy(disk_1_db_source, disk_1_db_path);

            if (!File.Exists(disk_2_db_path))
                File.Copy(disk_2_db_source, disk_2_db_path);

            //set attributes
            File.SetAttributes(disk_1_path, FileAttributes.Normal);
            File.SetAttributes(disk_2_path, FileAttributes.Normal);
            File.SetAttributes(disk_1_db_path, FileAttributes.Normal);
            File.SetAttributes(disk_2_db_path, FileAttributes.Normal);
        }

        static void copyDbFromCd()
        {
            //search cd
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.DriveType == System.IO.DriveType.CDRom)
                {
                    string diskFolder = drive.RootDirectory.ToString() + @"KozaDisk\";

                    //if this is KozaDisk
                    if(Directory.Exists(diskFolder))
                    {
                        //single
                        if (File.Exists(diskFolder + "disk.xml"))
                        {
                            copyDbFromCdSingle(diskFolder);
                        }

                        //double
                        if (File.Exists(diskFolder + "disks.xml"))
                        {
                            copyDbFromCdDouble(diskFolder);
                        }
                    }
                }
            }
        }

        static void openForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    }
}
