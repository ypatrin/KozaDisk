using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk
{
    class Folder
    {
        /// <summary>
        /// ID папки
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ID родителя
        /// </summary>
        public string parentId { get; set; }
    }
}
