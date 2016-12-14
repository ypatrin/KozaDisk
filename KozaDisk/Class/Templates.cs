using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;

namespace KozaDisk
{
    class Templates
    {
        string db;

        public void setDB(string db)
        {
            this.db = db;
        }

        public List<Template> getDocuments(string structureId)
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + this.db;
            List<Template> templates = new List<Template>();

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM templates WHERE structure_id = {structureId}", connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Template template = new Template();

                template.id = (string)reader["id"].ToString();
                template.structureId = (string)reader["structure_id"].ToString();
                template.name = (string)reader["name"].ToString();
                template.markersXML = (string)reader["markers_xml"].ToString(); 
                template.template = (string)reader["template"].ToString();
                template.type = (string)reader["type"].ToString();

                templates.Add(template);
                template = null;
            }

            connection.Close();

            return templates;
        }
    }
}
