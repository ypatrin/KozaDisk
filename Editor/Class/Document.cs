using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Class
{
    class Document
    {
        /// <summary>
        /// Document ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        public string categoryId { get; set; }

        /// <summary>
        /// Document name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Document file name
        /// </summary>
        public string fileName { get; set; }

        public int type { get; set; }

    }
}
