using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KozaDisk
{
    class Disk
    {
        /// <summary>
        /// Имя диска
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Описание диска
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Редакция диска
        /// </summary>
        public string edition { get; set; }

        /// <summary>
        /// Имя файла базы данных диска
        /// </summary>
        public string db { get; set; }

        /// <summary>
        /// Получает список родительских папок
        /// </summary>
        public List<Folder> getFolders()
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            List<Folder> folders = new List<Folder>();

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM structure WHERE parent_id = 0", connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Folder folder = new Folder();

                folder.id = (string)reader["id"].ToString();
                folder.name = (string)reader["name"].ToString();
                folder.parentId = (string)reader["parent_id"].ToString();

                folders.Add(folder);
                folder = null;
            }

            connection.Close();

            return folders;
        }
    }
}
