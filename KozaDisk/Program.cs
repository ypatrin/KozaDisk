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
            //seach old users
            string oldKozaPath = Constant.MyDocumentsPath + @"\" + Constant.OldKozaName + @"\";

            if (Directory.Exists(oldKozaPath + "app"))
                oldKozaPath += @"app\";
            else
                oldKozaPath += @"koza\";

            if(!Directory.Exists(oldKozaPath))
            {
                Program.openForm();
            }
            else
            {
                //if old koza have users path
                if (Directory.Exists(oldKozaPath + @"UserFiles\"))
                {
                    //search folders
                    string[] directories = Directory.GetDirectories(oldKozaPath + @"UserFiles\");

                    foreach(string directory in directories)
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

                            foreach(string constLine in constLines)
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
                                    case "Назва організації вищого рівня":
                                        user.Subordination = constVal;
                                        break;
                                    case "Назва організації вищого рівня у родовому відмінку":
                                        user.SubordinationGenitive = constVal;
                                        break;
                                    case "Місце складання документів":
                                        user.Place = constVal;
                                        break;
                                    case "Прізвище та ініціали керівника":
                                        user.ChiefSurname = constVal;
                                        break;
                                    case "Ініціали та прізвище керівника":
                                        user.ChiefInitials = constVal;
                                        break;
                                    case "Посада керівника з великої літери":
                                        user.ChiefPosition = constVal;
                                        break;
                                    case "Посада керівника з малої літери в родовому відмінку":
                                        user.ChiefPositionLower = constVal;
                                        break;
                                }
                            }

                            //save to xml
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

                            //save xml
                            
                            if (!Directory.Exists(UserStorage))
                            {
                                Directory.CreateDirectory(UserStorage);
                            }

                            File.WriteAllText(UserStorage + @"\userdata.xml", xml);
                        }
                    }
                }

                //open form
                Program.openForm();
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
