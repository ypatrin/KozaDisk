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
        string view = "tree";

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
            this.load();
        }

        public void load()
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

            DisksBlocksBrowser.AllowWebBrowserDrop = false;
            DisksBlocksBrowser.IsWebBrowserContextMenuEnabled = false;
            DisksBlocksBrowser.WebBrowserShortcutsEnabled = false;
            DisksBlocksBrowser.ObjectForScripting = this;

            MyDocsBlockBrowser.AllowWebBrowserDrop = false;
            MyDocsBlockBrowser.IsWebBrowserContextMenuEnabled = false;
            MyDocsBlockBrowser.WebBrowserShortcutsEnabled = false;
            MyDocsBlockBrowser.ObjectForScripting = this;

            MyDocsListBrowser.AllowWebBrowserDrop = false;
            MyDocsListBrowser.IsWebBrowserContextMenuEnabled = false;
            MyDocsListBrowser.WebBrowserShortcutsEnabled = false;
            MyDocsListBrowser.ObjectForScripting = this;

            SearchBrowser.AllowWebBrowserDrop = false;
            SearchBrowser.IsWebBrowserContextMenuEnabled = false;
            SearchBrowser.WebBrowserShortcutsEnabled = false;
            SearchBrowser.ObjectForScripting = this;

            this.UserNameLabel.Text = this.userData.UserName;

            var disks = this.disks.getDisksList();

            // TREE

            string treeHtml = Properties.Resources.disk_tree;
            string disksHtml = "";

            string blocksHtml = Properties.Resources.disk_blocks;
            string disksBlockHtml = "";

            int count = 0;
            int folders_count = 0;

            foreach (Disk disk in disks)
            {
                count = count + 1;
                //get list of folders
                List<Folder> folders = disk.getFolders();

                //tree
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

                //blocks
                disksBlockHtml += $"<div class=\"block\" type=\"disk\" db=\"{disk.db}\">";
                disksBlockHtml += $"<div class=\"head\">{disk.name}</div>";
                disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\disk_big.png\"/></div>";
                disksBlockHtml += "</div>";

                disksHtml += "</div>";
            }

            treeHtml = treeHtml.Replace("%disks_tree%", disksHtml);
            treeHtml = treeHtml.Replace("%AppPath%", Constant.ApplcationPath);
            treeHtml = treeHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

            blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
            blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
            blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));


            this.TreeBrowser.Navigate("about:blank");
            this.TreeBrowser.DocumentText = "0";
            this.TreeBrowser.Document.OpenNew(true);
            this.TreeBrowser.Document.Write(treeHtml);
            this.TreeBrowser.Refresh();

            this.DisksBlocksBrowser.Navigate("about:blank");
            this.DisksBlocksBrowser.DocumentText = "0";
            this.DisksBlocksBrowser.Document.OpenNew(true);
            this.DisksBlocksBrowser.Document.Write(blocksHtml);
            this.DisksBlocksBrowser.Refresh();

            try
            {
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
            catch (Exception e) { }
        }

        public void openDisk(string db)
        {
            var disks = this.disks.getDisksList();

            foreach (Disk disk in disks)
            {
                if (disk.db == db)
                {
                    List<Folder> folders = disk.getFolders();

                    string blocksHtml = Properties.Resources.disk_blocks;
                    string disksBlockHtml = "";

                    foreach (Folder folder in folders)
                    {
                        disksBlockHtml += $"<div class=\"block\" type=\"folder\" db=\"{disk.db}\" id=\"{folder.id}\">";
                        disksBlockHtml += $"<div class=\"head\">{folder.name}</div>";
                        disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\folder_big.png\"/></div>";
                        disksBlockHtml += "</div>";
                    }

                    blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
                    blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
                    blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

                    this.DisksBlocksBrowser.Navigate("about:blank");
                    this.DisksBlocksBrowser.DocumentText = "0";
                    this.DisksBlocksBrowser.Document.OpenNew(true);
                    this.DisksBlocksBrowser.Document.Write(blocksHtml);
                    this.DisksBlocksBrowser.Refresh();
                }
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

            //blocks
            string blocksHtml = Properties.Resources.disk_blocks;
            string disksBlockHtml = "";

            foreach (var template in templates.getDocuments(folderId))
            {
                disksBlockHtml += $"<div class=\"block\" type=\"document\" db=\"{db}\" id=\"{template.id}\">";
                disksBlockHtml += $"<div class=\"head\">{template.name}</div>";
                disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\doc.png\"/></div>";
                disksBlockHtml += "</div>";
            }

            blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
            blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
            blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

            if (this.view == "tree")
            {
                this.FilesBrowser.Navigate("about:blank");
                this.FilesBrowser.DocumentText = "0";
                this.FilesBrowser.Document.OpenNew(true);
                this.FilesBrowser.Document.Write(filesHtml);
                this.FilesBrowser.Refresh();
            }

            if (this.view == "block")
            {
                this.DisksBlocksBrowser.Navigate("about:blank");
                this.DisksBlocksBrowser.DocumentText = "0";
                this.DisksBlocksBrowser.Document.OpenNew(true);
                this.DisksBlocksBrowser.Document.Write(blocksHtml);
                this.DisksBlocksBrowser.Refresh();
            }
        }

        public void openDocument(string documentId, string db)
        {
            db = db.Replace(Constant.ApplcationStorage + @"db\cd\", "");
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

            string templateFileContent = KozaDisk.Encrypt.Base64.Decode(template.template);
            string markersFileContent = KozaDisk.Encrypt.Base64.Decode(template.markersXML);

            //create template file
            System.IO.File.WriteAllBytes(KozaDisk.Constant.TempDocxFile, Convert.FromBase64String(template.template));
            //create markers file
            System.IO.File.WriteAllBytes(KozaDisk.Constant.TempXmlFile, Convert.FromBase64String(template.markersXML));

            //loading template
            templates.Templates templates = new templates.Templates();
            templates.setTemplate(KozaDisk.Constant.TempDocxFile, KozaDisk.Constant.TempXmlFile, template.name);
            templates.setUserXmlFile(this.userData.XmlFilePath);
            templates.setDbName(databaseName);
            templates.setDocId(Int32.Parse(template.id));
            templates.open();

            //delete temp files
            //System.IO.File.Delete(KozaDisk.Constant.TempDocxFile);
            //System.IO.File.Delete(KozaDisk.Constant.TempXmlFile);
        }

        private void BlockViewBtn_Click(object sender, EventArgs e)
        {
            this.view = "block";

            this.ListViewImg.Visible = false;
            this.ListViewBtn.Visible = true;

            this.BlockViewImg.Visible = true;
            this.BlockViewBtn.Visible = false;

            this.Tabs.SelectedIndex = 1;
        }

        private void ListViewBtn_Click(object sender, EventArgs e)
        {
            this.view = "tree";

            this.ListViewImg.Visible = true;
            this.ListViewBtn.Visible = false;

            this.BlockViewImg.Visible = false;
            this.BlockViewBtn.Visible = true;

            this.Tabs.SelectedIndex = 0;
        }

        private void AutoFillBtn_Click(object sender, EventArgs e)
        {
            AutofillForm autoFillForm = new AutofillForm(this.userData);
            autoFillForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel11.Visible = false;
            this.panel12.Visible = true;

            //buttons
            this.mdBlockViewDisabled.Visible = false;
            this.mdListViewEnabled.Visible = false;
            this.mdBlockViewEnabled.Visible = true;
            this.mdListViewDisabled.Visible = true;
            

            this.loadMyDocuments(Constant.MyDocumentsBlockTab);

            this.searchBox.Text = "";
        }

        private void loadMyDocuments(int TabIndex)
        {
            string databaseName = Constant.ApplcationStorage + $"users\\{this.userData.UserName}\\documents.db";

            if (!System.IO.File.Exists(databaseName))
            {
                this.Tabs.SelectedIndex = TabIndex;
            }
            else
            {
                //load documents
                SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                connection.Open();

                string sql = "SELECT id, db_name, doc_id, doc_name, doc_html, created_at FROM documents ORDER BY created_at";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader r = command.ExecuteReader();

                string blocksHtml = Properties.Resources.disk_blocks;
                string treeHtml = Properties.Resources.mydocs_tree;

                string disksTreeHtml = "";
                string disksBlockHtml = "";

                while (r.Read())
                {
                    string db = r["db_name"].ToString().Replace(Constant.ApplcationStorage + @"db\cd\", "");

                    disksBlockHtml += $"<div class=\"block mydoc\" type=\"document\" db=\"{db}\" id=\"{r["doc_id"].ToString()}\">";
                    disksBlockHtml += $"<div class=\"head\">{r["doc_name"].ToString()}</div>";
                    disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\doc.png\"/></div>";
                    disksBlockHtml += $"<div class=\"btn\">";
                    disksBlockHtml += $"<div class=\"date\">{r["created_at"].ToString()}</div>";
                    disksBlockHtml += $"<div class=\"delete\" id=\"{r["id"].ToString()}\"><img src=\"{Constant.ApplcationPath}icon\\iface\\delete.png\"/></div>";
                    disksBlockHtml += $"</div>";
                    disksBlockHtml += "</div>";

                    disksTreeHtml += $"<tr>";
                    disksTreeHtml += $"<td class=\"document\" id=\"{r["doc_id"].ToString()}\" db=\"{db}\">{r["doc_name"].ToString()}</td>";
                    disksTreeHtml += $"<td>{r["created_at"].ToString()}</td>";
                    disksTreeHtml += $"<td class=\"delete\" id=\"{r["id"].ToString()}\">X</td>";
                    disksTreeHtml += "<tr>";

                    //disksTreeHtml += $"<div class=\"document\" id=\"{r["doc_id"].ToString()}\" db=\"{db}\"></div>";
                }

                blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
                blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
                blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

                treeHtml = treeHtml.Replace("%AppPath%", Constant.ApplcationPath);
                treeHtml = treeHtml.Replace("%templates%", disksTreeHtml);

                MyDocsBlockBrowser.Navigate("about:blank");
                MyDocsBlockBrowser.DocumentText = "0";
                MyDocsBlockBrowser.Document.OpenNew(true);
                MyDocsBlockBrowser.Document.Write(blocksHtml);
                MyDocsBlockBrowser.Refresh();

                MyDocsListBrowser.Navigate("about:blank");
                MyDocsListBrowser.DocumentText = "0";
                MyDocsListBrowser.Document.OpenNew(true);
                MyDocsListBrowser.Document.Write(treeHtml);
                MyDocsListBrowser.Refresh();

                //open page
                this.Tabs.SelectedIndex = TabIndex;
            }
        }
 
        public void deleteDocument(string id)
        {
            if (MessageBox.Show("Видалити документ?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string databaseName = Constant.ApplcationStorage + $"users\\{this.userData.UserName}\\documents.db";

                SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                connection.Open();

                string sql = "DELETE FROM documents WHERE id = id";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                this.loadMyDocuments(Constant.MyDocumentsBlockTab);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void mdListViewDisabled_Click(object sender, EventArgs e)
        {
            //buttons
            this.mdBlockViewDisabled.Visible = true;
            this.mdListViewEnabled.Visible = true;
            this.mdBlockViewEnabled.Visible = false;
            this.mdListViewDisabled.Visible = false;

            this.loadMyDocuments(Constant.MyDocumentsListTab);
        }

        private void mdBlockViewDisabled_Click(object sender, EventArgs e)
        {
            //buttons
            this.mdBlockViewDisabled.Visible = false;
            this.mdListViewEnabled.Visible = false;
            this.mdBlockViewEnabled.Visible = true;
            this.mdListViewDisabled.Visible = true;

            this.loadMyDocuments(Constant.MyDocumentsBlockTab);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel11.Visible = true;
            this.panel12.Visible = false;

            this.view = "tree";

            this.ListViewImg.Visible = true;
            this.ListViewBtn.Visible = false;

            this.BlockViewImg.Visible = false;
            this.BlockViewBtn.Visible = true;

            this.Tabs.SelectedIndex = 0;
            this.searchBox.Text = "";

            this.load();
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    this.doSearch();
            //}
        }

        public void doSearch()
        {
            this.Tabs.SelectedIndex = 4;

            List<Template> findingTemplates = new List<Template>();
            //search DB
            var disks = this.disks.getDisksList();

            foreach (Disk disk in disks)
            {
                //open disk
                foreach (Template template in disk.serachDocs(searchBox.Text))
                {
                    findingTemplates.Add(template);
                }
            }

            //display
            string blocksHtml = Properties.Resources.disk_blocks;
            string disksBlockHtml = "";

            foreach (var template in findingTemplates)
            {
                disksBlockHtml += $"<div class=\"block\" type=\"document\" db=\"{template.dbName}\" id=\"{template.id}\">";
                disksBlockHtml += $"<div class=\"head\">{template.name}</div>";
                disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\doc.png\"/></div>";
                disksBlockHtml += "</div>";
            }

            blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
            blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
            blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

            this.SearchBrowser.Navigate("about:blank");
            this.SearchBrowser.DocumentText = "0";
            this.SearchBrowser.Document.OpenNew(true);
            this.SearchBrowser.Document.Write(blocksHtml);
            this.SearchBrowser.Refresh();

            this.searchBox.Focus();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string text = searchBox.Text;
            if (text.Length >= 3)
            {
                this.doSearch();
            }
            else
            {
                MessageBox.Show("Кількість символів для пошуку повинно будти не менш 3", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string text = searchBox.Text;
            if (text.Length >= 3) this.doSearch();
        }
    }
}
