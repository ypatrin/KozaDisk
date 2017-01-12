using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;

namespace KozaDisk
{
    class Template
    {
        /// <summary>
        /// ID Шаблона
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// ID папки
        /// </summary>
        public string structureId { get; set; }

        /// <summary>
        /// Имя шаблона
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// XML описания маркира
        /// </summary>
        public string markersXML { get; set; }

        /// <summary>
        /// Шаблон
        /// </summary>
        public string template { get; set; }

        /// <summary>
        /// Тип шаблона. 0 - докумен, 1 - файл
        /// </summary>
        public string type { get; set; }

        public string dbName { get; set; }

        internal void setDbName(string databaseName)
        {
            throw new NotImplementedException();
        }

        internal void setDocId(int v)
        {
            throw new NotImplementedException();
        }
    }
}
