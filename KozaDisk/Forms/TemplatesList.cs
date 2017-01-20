﻿using System;
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

        bool isNoNavigation = false;

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

        public void prepareTree()
        {
            KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
            this.DiskTree.Nodes.Clear();

            var disks = this.disks.getDisksList();

            foreach (Disk disk in disks)
            {
                Class.Objects.DiskTreeNode diskTreeNode = new Class.Objects.DiskTreeNode();
                diskTreeNode.db = disk.db;
                diskTreeNode.Name = disk.name;
                diskTreeNode.Text = disk.name;
                diskTreeNode.setType(Class.Objects.DiskTreeType.Disk);

                if (!activator.isActivated(disk.db))
                {
                    diskTreeNode.ImageIndex = 0;
                    diskTreeNode.SelectedImageIndex = 0;
                }
                else
                {
                    diskTreeNode.ImageIndex = 1;
                    diskTreeNode.SelectedImageIndex = 1;
                }         
                
                if (!activator.isActivated(disk.db) && !activator.isTrial(disk.db))
                {
                    continue;
                }    

                List<Folder> folders = disk.getFolders();

                foreach (Folder folder in folders)
                {
                    Class.Objects.DiskTreeNode folderNode = new Class.Objects.DiskTreeNode();
                    folderNode.db = disk.db;
                    folderNode.id = folder.id;
                    folderNode.Text = folder.name;
                    folderNode.setType(Class.Objects.DiskTreeType.Folder);

                    foreach (Folder subFolder in disk.getFolders(folderNode.id))
                    {
                        Class.Objects.DiskTreeNode subFolderNode = new Class.Objects.DiskTreeNode();
                        subFolderNode.db = disk.db;
                        subFolderNode.id = subFolder.id;
                        subFolderNode.Text = subFolder.name;
                        subFolderNode.setType(Class.Objects.DiskTreeType.Folder);

                        foreach (Folder sub2Folder in disk.getFolders(folderNode.id))
                        {
                            Class.Objects.DiskTreeNode sub2FolderNode = new Class.Objects.DiskTreeNode();
                            sub2FolderNode.db = disk.db;
                            sub2FolderNode.id = sub2Folder.id;
                            sub2FolderNode.Text = sub2Folder.name;
                            sub2FolderNode.setType(Class.Objects.DiskTreeType.Folder);

                            folderNode.Nodes.Add(sub2FolderNode);
                        }

                        folderNode.Nodes.Add(subFolderNode);
                    }

                    diskTreeNode.Nodes.Add(folderNode);
                }

                this.DiskTree.Nodes.Add(diskTreeNode);
            }
        }

        public void prepareList()
        {
            string html = Properties.Resources.disk_blocks;
            string nodeHtml = "";

            var disks = this.disks.getDisksList();

            foreach (Disk disk in disks)
            {
                //get list of folders
                List<Folder> folders = disk.getFolders();

                //blocks
                nodeHtml += $"<div class=\"block\" type=\"disk\" db=\"{disk.db}\" onClick=\"window.external.openDisk('{disk.db}');\">";
                nodeHtml += $"<div class=\"head\">{disk.name}</div>";
                nodeHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\disk_big.png\"/></div>";
                nodeHtml += "</div>";
            }

            html = html.Replace("%disks_blocks%", nodeHtml);
            html = html.Replace("%AppPath%", Constant.ApplcationPath);
            html = html.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

            this.DisksBlocksBrowser.Navigate("about:blank");
            this.DisksBlocksBrowser.DocumentText = "0";
            this.DisksBlocksBrowser.Document.OpenNew(true);
            this.DisksBlocksBrowser.Document.Write(html);
            this.DisksBlocksBrowser.Refresh();
        }

        public void load()
        {
            FilesBrowser.AllowWebBrowserDrop = false;
            FilesBrowser.IsWebBrowserContextMenuEnabled = false;
            FilesBrowser.WebBrowserShortcutsEnabled = false;
            FilesBrowser.ScriptErrorsSuppressed = false;
            FilesBrowser.ObjectForScripting = this;

            DisksBlocksBrowser.AllowWebBrowserDrop = false;
            DisksBlocksBrowser.IsWebBrowserContextMenuEnabled = false;
            DisksBlocksBrowser.WebBrowserShortcutsEnabled = false;
            DisksBlocksBrowser.ScriptErrorsSuppressed = false;
            DisksBlocksBrowser.ObjectForScripting = this;

            MyDocsBlockBrowser.AllowWebBrowserDrop = false;
            MyDocsBlockBrowser.IsWebBrowserContextMenuEnabled = false;
            MyDocsBlockBrowser.WebBrowserShortcutsEnabled = false;
            MyDocsBlockBrowser.ScriptErrorsSuppressed = false;
            MyDocsBlockBrowser.ObjectForScripting = this;

            MyDocsListBrowser.AllowWebBrowserDrop = false;
            MyDocsListBrowser.IsWebBrowserContextMenuEnabled = false;
            MyDocsListBrowser.WebBrowserShortcutsEnabled = false;
            MyDocsListBrowser.ScriptErrorsSuppressed = false;
            MyDocsListBrowser.ObjectForScripting = this;

            SearchBrowser.AllowWebBrowserDrop = false;
            SearchBrowser.IsWebBrowserContextMenuEnabled = false;
            SearchBrowser.WebBrowserShortcutsEnabled = false;
            SearchBrowser.ScriptErrorsSuppressed = false;
            SearchBrowser.ObjectForScripting = this;


            NaviBrowser.ObjectForScripting = this;

            this.UserNameLabel.Text = this.userData.UserName;

            this.writeNavigation(new List<Class.Objects.Navigation>());

            this.prepareTree();
            this.prepareList();
        }

        public void openDisk(string db)
        {
            this.DisksBlocksBrowser.Stop();

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
                        disksBlockHtml += $"<div class=\"block\" type=\"folder\" db=\"{disk.db}\" id=\"{folder.id}\" onClick=\"window.external.openFolder('{folder.id}', '{disk.db}');\">";
                        disksBlockHtml += $"<div class=\"head\">{folder.name}</div>";
                        disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\folder_big.png\"/></div>";
                        disksBlockHtml += "</div>";
                    }

                    blocksHtml = blocksHtml.Replace("%disks_blocks%", disksBlockHtml);
                    blocksHtml = blocksHtml.Replace("%AppPath%", Constant.ApplcationPath);
                    blocksHtml = blocksHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

                    while (this.DisksBlocksBrowser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                        this.DisksBlocksBrowser.Stop();
                    }

                    this.DisksBlocksBrowser.Navigate("about:blank");
                    this.DisksBlocksBrowser.DocumentText = "0";
                    this.DisksBlocksBrowser.Document.OpenNew(true);
                    this.DisksBlocksBrowser.Document.Write(blocksHtml);
                    this.DisksBlocksBrowser.Refresh();

                    //write navigation
                    List<KozaDisk.Class.Objects.Navigation> navi = new List<Class.Objects.Navigation>();
                    KozaDisk.Class.Objects.Navigation cd = new Class.Objects.Navigation();

                    cd.db = disk.db;
                    cd.text = disk.name;
                    cd.isDisk = true;
                    cd.isFolder = false;
                    cd.isMyDocs = false;

                    navi.Add(cd);

                    writeNavigation(navi);

                    KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
                    if (!activator.isActivated(disk.db))
                    {
                        //display activation message
                        KozaDisk.Forms.Activate activateForm = new KozaDisk.Forms.Activate();
                        activateForm.setDiskName(disk.name);
                        activateForm.userData = this.userData;
                        activateForm.db = disk.db;
                        activateForm.ShowDialog();
                    }


                }
            }
        }

        public void openFolder(string folderId, string db)
        {
            //write navigation
            List<KozaDisk.Class.Objects.Navigation> navi = new List<Class.Objects.Navigation>();
            KozaDisk.Class.Objects.Navigation cd = new Class.Objects.Navigation();
            KozaDisk.Class.Objects.Navigation folder = new Class.Objects.Navigation();

            //search disk info
            var disks = this.disks.getDisksList();

            foreach (Disk disk in disks)
            {
                if (disk.db == db)
                {
                    cd.db = disk.db;
                    cd.text = disk.name;
                    cd.isDisk = true;
                    cd.isFolder = false;
                    cd.isMyDocs = false;

                    foreach (Folder cdFolder in disk.getFolders())
                    {
                        if (cdFolder.id == folderId)
                        {
                            folder.id = cdFolder.id;
                            folder.db = disk.db;
                            folder.text = cdFolder.name;
                            folder.isDisk = false;
                            folder.isFolder = true;
                            folder.isMyDocs = false;
                        }
                    }
                }
            }

            navi.Add(cd);
            navi.Add(folder);

            this.writeNavigation(navi);

            var templates = new Templates();
            templates.setDB(db);

            string filesHtml = Properties.Resources.disk_tree_files;
            string templatesHtml = "";
            
            foreach (var template in templates.getDocuments(folderId))
            {
                templatesHtml += $"<div class=\"document\" id=\"{template.id}\" db=\"{db}\" onClick=\"window.external.openDocument('{template.id}', '{db}');\">{template.name}</div>";
            }

            filesHtml = filesHtml.Replace("%AppPath%", Constant.ApplcationPath);
            filesHtml = filesHtml.Replace("%templates%", templatesHtml);

            //blocks
            string blocksHtml = Properties.Resources.disk_blocks;
            string disksBlockHtml = "";

            foreach (var template in templates.getDocuments(folderId))
            {
                // document
                if (template.type == "0")
                {
                    disksBlockHtml += $"<div class=\"block\" type=\"document\" db=\"{db}\" id=\"{template.id}\" onClick=\"window.external.openDocument('{template.id}', '{db}');\">";
                    disksBlockHtml += $"<div class=\"head\">{template.name}</div>";
                    disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\doc.png\"/></div>";
                    disksBlockHtml += "</div>";
                }

                //file
                if (template.type == "1")
                {
                    disksBlockHtml += $"<div class=\"block\" type=\"document\" db=\"{db}\" id=\"{template.id}\" onClick=\"window.external.openDocument('{template.id}', '{db}');\">";
                    disksBlockHtml += $"<div class=\"head\">{template.name}</div>";
                    disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\file.png\"/></div>";
                    disksBlockHtml += "</div>";
                }
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

            this.DisksBlocksBrowser.Stop();

            while (this.DisksBlocksBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                
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
            template.fileExt = (string)reader["file_ext"].ToString();

            string templateFileContent = KozaDisk.Encrypt.Base64.Decode(template.template);
            string markersFileContent = KozaDisk.Encrypt.Base64.Decode(template.markersXML);

            //create template file
            System.IO.File.WriteAllBytes(KozaDisk.Constant.TempDocxFile, Convert.FromBase64String(template.template));
            //create markers file
            System.IO.File.WriteAllBytes(KozaDisk.Constant.TempXmlFile, Convert.FromBase64String(template.markersXML));

            if (template.type == "0")
            {
                //loading template
                templates.Templates templates = new templates.Templates();
                templates.setTemplate(KozaDisk.Constant.TempDocxFile, KozaDisk.Constant.TempXmlFile, template.name);
                templates.setUserXmlFile(this.userData.XmlFilePath);
                templates.setDbName(databaseName);
                templates.setDocId(Int32.Parse(template.id));
                templates.open();
            }
            if (template.type == "1")
            {
                /*
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = template.name + ".pdf";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                sfd.Filter = "PDF File|*.pdf";
                sfd.Title = "Зберегти документ " + template.name;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(sfd.FileName, Convert.FromBase64String(template.template));
                    
                    if (MessageBox.Show("Документ успішно збережений! Відкрити?", "Збереження документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
                */

                System.IO.File.WriteAllBytes(Constant.TempPath + template.name + template.fileExt, Convert.FromBase64String(template.template));
                System.Diagnostics.Process.Start(Constant.TempPath + template.name + template.fileExt);
            }
        }

        public void openMyDocument(string documentId, string db)
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

            connection.Close();

            string myDocsDb = Constant.ApplcationStorage + $"users\\{this.userData.UserName}\\documents.db";
            SQLiteConnection myDocCn = new SQLiteConnection(string.Format("Data Source={0};", myDocsDb));
            myDocCn.Open();

            string sql = $"SELECT id, db_name, doc_id, doc_name, doc_html, created_at FROM documents WHERE doc_id = '{documentId}'";

            SQLiteCommand MyDocCmd = new SQLiteCommand(sql, myDocCn);
            SQLiteDataReader r = MyDocCmd.ExecuteReader();
            r.Read();
            string html = r["doc_html"].ToString();
            html = Encrypt.Base64.Decode(html);

            myDocCn.Close();

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
            templates.open(html);
            

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
            this.isNoNavigation = false;
        }

        private void ListViewBtn_Click(object sender, EventArgs e)
        {
            this.view = "tree";

            this.ListViewImg.Visible = true;
            this.ListViewBtn.Visible = false;

            this.BlockViewImg.Visible = false;
            this.BlockViewBtn.Visible = true;

            this.Tabs.SelectedIndex = 0;

            this.isNoNavigation = true;
            this.writeNavigation(new List<Class.Objects.Navigation>());
        }

        private void AutoFillBtn_Click(object sender, EventArgs e)
        {
            AutofillForm autoFillForm = new AutofillForm(this.userData);
            autoFillForm.ShowDialog();

            Users users = new Users();
            User user = users.getUser(this.userData.UserName);
            this.userData = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyDocsLink();
        }

        public void MyDocsLink()
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

            //write navigation
            List<KozaDisk.Class.Objects.Navigation> navi = new List<Class.Objects.Navigation>();
            KozaDisk.Class.Objects.Navigation myDoc = new Class.Objects.Navigation();

            myDoc.text = "Мої документи";
            myDoc.isDisk = false;
            myDoc.isFolder = false;
            myDoc.isMyDocs = true;

            navi.Add(myDoc);

            writeNavigation(navi);
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

                    disksBlockHtml += $"<div class=\"block mydoc\" type=\"document\" db=\"{db}\" id=\"{r["doc_id"].ToString()}\" onClick=\"window.external.openMyDocument('{r["doc_id"].ToString()}', '{db}');\">";
                    disksBlockHtml += $"<div class=\"head\">{r["doc_name"].ToString()}</div>";
                    disksBlockHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\iface\\doc.png\"/></div>";
                    disksBlockHtml += $"<div class=\"btn\">";
                    disksBlockHtml += $"<div class=\"date\">{r["created_at"].ToString()}</div>";
                    disksBlockHtml += $"<div class=\"delete\" id=\"{r["id"].ToString()}\" onClick=\"window.external.deleteDocument('{r["doc_id"].ToString()}');\"><img src=\"{Constant.ApplcationPath}icon\\iface\\delete.png\"/></div>";
                    disksBlockHtml += $"</div>";
                    disksBlockHtml += "</div>";

                    disksTreeHtml += $"<tr>";
                    disksTreeHtml += $"<td class=\"document\" id=\"{r["doc_id"].ToString()}\" db=\"{db}\">{r["doc_name"].ToString()}</td>";
                    disksTreeHtml += $"<td>{r["created_at"].ToString()}</td>";
                    disksTreeHtml += $"<td class=\"delete\" id=\"{r["id"].ToString()}\" onClick=\"window.external.deleteDocument('{r["doc_id"].ToString()}');\">X</td>";
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

        public void NaviMainLink()
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

            this.prepareList();
            this.prepareTree();

            this.writeNavigation(new List<Class.Objects.Navigation>());
        }

        private void writeNavigation(List<KozaDisk.Class.Objects.Navigation> navigationLinks)
        {
            string links = "";
            string separator = " <span style=\"font-family: sans-serif; font-size: 12px; color: #797979;\">&gt;</span> ";
            string style = "font-family: 'Miriad Pro'; font-size: 15px; cursor: pointer; color: 00bd9c;";

            //write home
            links += $"<a name=\"home\" class=\"navi\" style=\"{style}\" onClick=\"window.external.NaviMainLink()\">Головна</a>";

            if (!this.isNoNavigation)
            {
                foreach (KozaDisk.Class.Objects.Navigation navigationLink in navigationLinks)
                {
                    //add separator
                    links += separator;

                    //write link
                    if (navigationLink.isDisk)
                    {
                        links += $"<a name=\"home\" class=\"navi\" style=\"{style}\" onClick=\"window.external.openDisk('{navigationLink.db}');\">{navigationLink.text}</a>";
                    }

                    if (navigationLink.isFolder)
                    {
                        links += $"<a name=\"home\" class=\"navi\" style=\"{style}\" onClick=\"window.external.openFolder('{navigationLink.id}', '{navigationLink.db}');\">{navigationLink.text}</a>";
                    }

                    if (navigationLink.isMyDocs)
                    {
                        links += $"<a name=\"home\" class=\"navi\" style=\"{style}\" onClick=\"window.external.MyDocsLink();\">{navigationLink.text}</a>";
                    }
                }
            }

            NaviBrowser.Navigate("about:blank");
            NaviBrowser.DocumentText = "0";
            NaviBrowser.Document.OpenNew(true);
            NaviBrowser.Document.Write(links);
            NaviBrowser.Refresh();

            /*
            while (NaviBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            */

        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void DiskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Class.Objects.DiskTreeNode selectedNode = (Class.Objects.DiskTreeNode)this.DiskTree.SelectedNode;

            if (selectedNode.getType() == Class.Objects.DiskTreeType.Disk)
            {
                KozaDisk.Class.Activator activator = new KozaDisk.Class.Activator();
                if (!activator.isActivated(selectedNode.db) && !selectedNode.isAtivateWindowDisplayed)
                {
                    //display activation message
                    KozaDisk.Forms.Activate activateForm = new KozaDisk.Forms.Activate();
                    activateForm.setDiskName(selectedNode.Name);
                    activateForm.userData = this.userData;
                    activateForm.db = selectedNode.db;
                    activateForm.ShowDialog();

                    if (activator.isActivated(selectedNode.db))
                    {
                        this.prepareTree();
                    }
                    else
                    {
                        selectedNode.isAtivateWindowDisplayed = true;
                    }
                }
            }

            if (selectedNode.getType() == Class.Objects.DiskTreeType.Folder)
            {
                this.openFolder(selectedNode.id, selectedNode.db);
            }
        }
    }
}
