using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk.Class.Objects
{
    class Navigation
    {
        /// <summary>
        /// ID элемента
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Имя базы данных
        /// </summary>
        public string db { get; set; }

        /// <summary>
        /// Тест ссылки
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Флаг если это диск
        /// </summary>
        public bool isDisk { get; set; }

        /// <summary>
        /// Флаг если это папка
        /// </summary>
        public bool isFolder { get; set; }

        /// <summary>
        /// Флаг моих документов
        /// </summary>
        public bool isMyDocs { get; set; }

        /// <summary>
        /// Флаг поиска
        /// </summary>
        public bool isSearch { get; set; }
    }
}
