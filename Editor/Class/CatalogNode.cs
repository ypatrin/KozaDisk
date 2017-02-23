using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
    class CatalogNode : System.Windows.Forms.TreeNode
    {
        public string id { get; set; }
        public string name { get; set; }
        public string catalogName { get; set; }
    }
}
