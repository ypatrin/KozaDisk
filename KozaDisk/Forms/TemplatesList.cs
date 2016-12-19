using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Data.Common;
using System.Data.SQLite;

namespace KozaDisk.Forms
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
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
            //prepare browser
            TreeBrowser.AllowWebBrowserDrop = false;
            TreeBrowser.IsWebBrowserContextMenuEnabled = false;
            TreeBrowser.WebBrowserShortcutsEnabled = false;
            TreeBrowser.ObjectForScripting = this;

            FilesBrowser.AllowWebBrowserDrop = false;
            FilesBrowser.IsWebBrowserContextMenuEnabled = false;
            FilesBrowser.WebBrowserShortcutsEnabled = false;
            FilesBrowser.ObjectForScripting = this;

            this.UserNameLabel.Text = this.userData.UserName;

            var disks = this.disks.getDisksList();

            // TREE

            string treeHtml = Properties.Resources.disk_tree;
            string disksHtml = "";

            int count = 0;
            int folders_count = 0;

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
                    folders_count = folders_count + 1;
                    disksHtml += $"<div class=\"folder\" id=\"{folders_count}\" db=\"{disk.db}\" fid=\"{folder.id}\">";
                    disksHtml += $"<div class=\"img\"><img src=\"{Constant.ApplcationPath}icon\\iface\\folder.png\"/></div>";
                    disksHtml += $"<div class=\"name\">{folder.name}</div>";
                    disksHtml += "</div>";
                }

                disksHtml += "</div>";
            }

            treeHtml = treeHtml.Replace("%disks_tree%", disksHtml);
            treeHtml = treeHtml.Replace("%AppPath%", Constant.ApplcationPath);
            treeHtml = treeHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\",@"/"));

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
            string templatesHtml = "";
            filesHtml = filesHtml.Replace("%AppPath%", Constant.ApplcationPath);
            filesHtml = filesHtml.Replace("%templates%", templatesHtml);

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

        public void openFolder(string folderId, string db)
        {
            var templates = new Templates();
            templates.setDB(db);

            string filesHtml = Properties.Resources.disk_tree_files;
            string templatesHtml = "";
            
            foreach (var template in templates.getDocuments(folderId))
            {
                templatesHtml += $"<div class=\"document\" id=\"{template.id}\" db=\"{db}\">{template.name}</div>";
            }

            filesHtml = filesHtml.Replace("%AppPath%", Constant.ApplcationPath);
            filesHtml = filesHtml.Replace("%templates%", templatesHtml);

            this.FilesBrowser.Navigate("about:blank");
            this.FilesBrowser.DocumentText = "0";
            this.FilesBrowser.Document.OpenNew(true);
            this.FilesBrowser.Document.Write(filesHtml);
            this.FilesBrowser.Refresh();
        }

        public void openDocument(string documentId, string db)
        {
            string databaseName = Constant.ApplcationStorage + @"db\cd\" + db;

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM templates WHERE id = {documentId}", connection);
            SQLiteDataReader reader = command.ExecuteReader();

            reader.Read();

            Template template = new Template();

            template.id = (string)reader["id"].ToString();
            template.structureId = (string)reader["structure_id"].ToString();
            template.name = (string)reader["name"].ToString();
            template.markersXML = (string)reader["markers_xml"].ToString();
            template.template = (string)reader["template"].ToString();
            template.type = (string)reader["type"].ToString();

            MessageBox.Show($"Открывает документ id = {template.id}", "KozaDisk", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
