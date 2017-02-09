using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

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
        /// Связанный диск
        /// </summary>
        public Disk relationCd { get; set; }

        /// <summary>
        /// Получает список папок
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

        public int getCoutTemplates()
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            int count = 0;

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT count(*) FROM templates", connection);
            count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        public int getCoutTemplates(int folderId)
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            int count = 0;

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT count(*) FROM templates WHERE structure_id = " + folderId, connection);
            count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        /// <summary>
        /// Получает список родительских папок
        /// </summary>
        public List<Folder> getFolders(string parentId)
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            List<Folder> folders = new List<Folder>();

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM structure WHERE parent_id = '{parentId}'", connection);
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

        /// <summary>
        /// Поиск документов по паттерну
        /// </summary>
        /// <param name="pattern">Паттерн для поиска</param>
        public List<Template> serachDocs(String pattern)
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            List<Template> templates = new List<Template>();

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM templates WHERE name_lower LIKE '%{pattern.ToLower()}%'", connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Template template = new Template();
                template.id = (string)reader["id"].ToString();
                template.name = (string)reader["name"].ToString();
                template.markersXML = (string)reader["markers_xml"].ToString();
                template.template = (string)reader["template"].ToString();
                template.dbName = (string)this.db;

                templates.Add(template);
                template = null;
            }

            return templates;
        }
    }
}
