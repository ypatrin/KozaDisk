using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Class
{
    class Catalog
    {
        /// <summary>
        /// Catalog ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Catalog parent ID
        /// </summary>
        public string parentId { get; set; }

        /// <summary>
        /// Catalog name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Catalog order
        /// </summary>
        public string position { get; set; }
    }
}
