using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Class
{
    class DocumentItem : System.Windows.Forms.ListViewItem
    {
        public int documentType { get; set; }
    }

    class DocumentNode : System.Windows.Forms.TreeNode
    {
        public int documentType { get; set; }
    }
}
