using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KozaDisk.Forms
{
    public partial class TemplatesList : Form
    {
        User userData = null;
        Disks disks = new Disks();

        public TemplatesList()
        {
            InitializeComponent();
        }

        public void setUserData(User userData)
        {
            this.userData = userData;
        }

        private void TemplatesList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TemplatesList_Load(object sender, EventArgs e)
        {
            this.UserNameLabel.Text = this.userData.UserName;

            var disks = this.disks.getDisksList();

            // TREE

            string treeHtml = Properties.Resources.disk_tree;
            string disksHtml = "";

            int count = 0;

            foreach(Disk disk in disks)
            {
                count = count+1;
                //get list of folders
                List<Folder> folders = disk.getFolders();

                if (count <= 1) disksHtml += $"<div class=\"disk first\" id=\"{count}\">";
                else disksHtml += $"<div class=\"disk\" id=\"{count}\">";

                disksHtml += $"<div class=\"img\"><img src=\"{Constant.ApplcationPath}icon\\iface\\disk.png\"/></div>";
                disksHtml += $"<div class=\"name\">{disk.name}</div>";
                disksHtml += "</div>";

                disksHtml += $"<div class=\"folders\" id=\"folders_{count}\">";
                foreach (Folder folder in folders)
                {
                    disksHtml += $"<div class=\"folder\" id=\"{folder.id}\">";
                    disksHtml += $"<div class=\"img\"><img src=\"{Constant.ApplcationPath}icon\\iface\\folder.png\"/></div>";
                    disksHtml += $"<div class=\"name\">{folder.name}</div>";
                    disksHtml += "</div>";

                    //get list of documents
                    var templates = new Templates();
                    templates.setDB(disk.db);

                    foreach (var template in templates.getDocuments(folder.id))
                    {

                    }                   
                }

                disksHtml += "</div>";
            }

            treeHtml = treeHtml.Replace("%disks_tree%", disksHtml);
            treeHtml = treeHtml.Replace("%AppPath%", Constant.ApplcationPath);

            this.TreeBrowser.Navigate("about:blank");
            this.TreeBrowser.DocumentText = "0";
            this.TreeBrowser.Document.OpenNew(true);
            this.TreeBrowser.Document.Write(treeHtml);
            this.TreeBrowser.Refresh();

            //Wait for document to finish loading
            while (this.TreeBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(5);
            }

            // FILES

            string filesHtml = Properties.Resources.disk_tree_files;

            this.FilesBrowser.Navigate("about:blank");
            this.FilesBrowser.DocumentText = "0";
            this.FilesBrowser.Document.OpenNew(true);
            this.FilesBrowser.Document.Write(filesHtml);
            this.FilesBrowser.Refresh();

            while (this.FilesBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(5);
            }
        }
    }
}
