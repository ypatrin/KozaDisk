using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk.Class.Objects
{
    class DiskTreeNode : System.Windows.Forms.TreeNode
    {
        public string id { get; set; }
        public string db { get; set; }
        public string description { get; set; }
        public Disk relationDisk { get; set; }

        public bool isAtivateWindowDisplayed { get; set; }

        private string type;

        public void setType(string type)
        {
            if (type == DiskTreeType.Disk)
            {
                this.ImageIndex = 0;
                this.SelectedImageIndex = 1;
            }

            if (type == DiskTreeType.Folder)
            {
                this.ImageIndex = 2;
                this.SelectedImageIndex = 3;
            }

            this.type = type;
        }

        public string getType()
        {
            return this.type;
        }
    }

    public class DiskTreeType
    {
        public static string Disk = "disk";
        public static string Folder = "folder";
    }
}
