using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KozaDisk
{
    public class Users
    {
        public User[] getUsers()
        {
            string userStorage = Constant.ApplcationStorage;
            string[] usersDirectories = Directory.GetDirectories(userStorage + @"users\");

            List<User> users = new List<User>();

            foreach (string userDirectory in usersDirectories)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(User));
                User userObj;

                using (var reader = File.OpenText(userDirectory + @"\userdata.xml"))
                {
                    userObj = (User)serializer.Deserialize(reader);
                    userObj.UserName = Path.GetFileName(userDirectory);
                }

                users.Add(userObj);
            }

            return users.ToArray();
        }

        public User getUser(string UserName)
        {
            string userStorage = Constant.ApplcationStorage;
            string userDirectory = userStorage + @"users\" + UserName;

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            User userObj;

            using (var reader = File.OpenText(userDirectory + @"\userdata.xml"))
            {
                userObj = (User)serializer.Deserialize(reader);
                userObj.UserName = Path.GetFileName(userDirectory);
                userObj.XmlFilePath = userDirectory + @"\userdata.xml";
            }

            return userObj;
        }
    }
}
