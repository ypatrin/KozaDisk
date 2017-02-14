using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SQLite;
using Renci.SshNet;
using Editor.Class;

namespace Editor
{
    public partial class Form1 : Form
    {
        Editor.Class.DB DataBase = new Editor.Class.DB();
        SQLiteConnection m_dbConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TreeCatalogs.Nodes.Clear();
            this.ListDocuments.Clear();

            List<Editor.Class.Catalog> catalogs = this.DataBase.getCatalogs();

            TreeNode baseNode = new TreeNode();
            baseNode.Text = "Коза Онлайн";

            foreach (Editor.Class.Catalog catalog in catalogs)
            {
                if (catalog.parentId == "0")
                {
                    TreeNode node = new TreeNode();
                    node.Name = catalog.id;
                    node.Text = catalog.name;
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;

                    //get parent
                    foreach (Editor.Class.Catalog parentCatalog in catalogs)
                    {
                        if (catalog.id == parentCatalog.parentId)
                        {
                            TreeNode parentNode = new TreeNode();
                            parentNode.Name = parentCatalog.id;
                            parentNode.Text = parentCatalog.name;
                            parentNode.ImageIndex = 1;
                            parentNode.SelectedImageIndex = 2;

                            node.Nodes.Add(parentNode);
                        }

                    }

                    baseNode.Nodes.Add(node);
                }
            }

            this.TreeCatalogs.Nodes.Add(baseNode);
        }

        private void TreeCatalogs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void TreeCatalogs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.SelectedDocument.Text = "";
            this.AddButton.Enabled = false;
            this.ListDocuments.Items.Clear();

            TreeNode selectedNode = this.TreeCatalogs.SelectedNode;

            if (selectedNode != null)
            {
                List<Editor.Class.Document> documents = this.DataBase.getDocuments(selectedNode.Name);

                foreach(Editor.Class.Document document in documents)
                {
                    DocumentItem lvi = new DocumentItem();
                    lvi.Name = document.id;
                    lvi.Text = document.name;
                    lvi.documentType = document.type;
                    lvi.ImageIndex = 3;

                    this.ListDocuments.Items.Add(lvi);
                }
            }
        }

        private void ListDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection lvi = this.ListDocuments.SelectedItems;

                if (lvi[0] != null)
                {
                    ListViewItem selectedItem = lvi[0];

                    this.SelectedDocument.Text = selectedItem.Text;
                    this.AddButton.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void DiskView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.DeleteDiskNodeBtn.Enabled = true;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ListDocuments.Items.Clear();

                string link = this.LinkBox.Text;
                string id = null;

                //check if this link
                Regex expression = new Regex(@"document/(?<Identifier>[0-9]*)");
                var results = expression.Matches(link);

                foreach (Match match in results)
                {
                    id = match.Groups["Identifier"].Value;
                }

                if (id != null)
                {
                    List<Editor.Class.Document> documents = this.DataBase.getDocumentsById(id);

                    foreach (Editor.Class.Document document in documents)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Name = document.id;
                        lvi.Text = document.name;
                        lvi.ImageIndex = 3;

                        this.ListDocuments.Items.Add(lvi);
                    }
                }

                //check if this id
                int result;
                if (Int32.TryParse(link, out result))
                {
                    id = result.ToString();

                    List<Editor.Class.Document> documents = this.DataBase.getDocumentsById(id);

                    foreach (Editor.Class.Document document in documents)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Name = document.id;
                        lvi.Text = document.name;
                        lvi.ImageIndex = 3;

                        this.ListDocuments.Items.Add(lvi);
                    }
                }

                return;
            }
        }

        private void NewFolderBtn_Click(object sender, EventArgs e)
        {
            if (this.NewFolderName.Text != "")
            {
                TreeNode parentNode = this.DiskTree.SelectedNode ?? this.DiskTree.Nodes[0];

                TreeNode newNode = new TreeNode();
                newNode.Text = this.NewFolderName.Text;
                newNode.ImageIndex = 1;
                newNode.SelectedImageIndex = 2;

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(newNode);
                    this.DiskTree.ExpandAll();
                    this.NewFolderName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Имя папки не может быть пустым!","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection lvi = this.ListDocuments.SelectedItems;

                if (lvi[0] != null)
                {
                    ListViewItem selectedItem = (ListViewItem)lvi[0];

                    TreeNode parentNode = this.DiskTree.SelectedNode ?? this.DiskTree.Nodes[0];

                    DocumentNode newNode = new DocumentNode();
                    newNode.Text = selectedItem.Text;
                    newNode.Name = selectedItem.Name;
                    newNode.ImageIndex = 3;
                    newNode.SelectedImageIndex = 3;

                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(newNode);
                        this.DiskTree.ExpandAll();
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void DeleteDiskNodeBtn_Click(object sender, EventArgs e)
        {
            if (this.DiskTree.SelectedNode != null)
            {
                if (this.DiskTree.SelectedNode == this.DiskTree.Nodes[0])
                {
                   
                }
                else
                {
                    if (this.DiskTree.SelectedNode.Parent == null)
                    {
                        this.DiskTree.Nodes.Remove(this.DiskTree.SelectedNode);
                    }
                    else
                    {
                        this.DiskTree.SelectedNode.Parent.Nodes.Remove(this.DiskTree.SelectedNode);
                    }
                }
            }
        }

        private void revBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateDiskBtn_Click(object sender, EventArgs e)
        {
            string dbName = this.DiskRevisionBox.Text + ".db";
            string ApplcationStorage = System.Windows.Forms.Application.StartupPath + @"\disks\" + this.DiskRevisionBox.Text + @"\";

            //create folder
            Directory.CreateDirectory(ApplcationStorage);

            //create xml
            string diskXml = "";
            diskXml += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            diskXml += "<disk>\n";
            diskXml += $"    <name>{this.DiskNameBox.Text}</name>\n";
            diskXml += $"    <description>{this.DiskDescriptionBox.Text}</description>\n";
            diskXml += $"    <edition>{this.DiskRevisionBox.Text}</edition>\n";
            diskXml += $"    <db>{dbName}</db>\n";
            diskXml += "</disk>\n";

            //save xml
            File.AppendAllText(ApplcationStorage + "disk.xml", diskXml);

            //created db
            SQLiteConnection.CreateFile(ApplcationStorage + dbName);
            m_dbConnection = new SQLiteConnection($"Data Source={ApplcationStorage}{dbName};Version=3;");
            m_dbConnection.Open();

            string sql = "";

            sql = "CREATE TABLE templates (id INTEGER PRIMARY KEY AUTOINCREMENT, structure_id INTEGER(10) NOT NULL, file_ext VARCHAR (255), name STRING(255), name_lower STRING(255), markers_xml TEXT, template TEXT, type INTEGER(1) NOT NULL DEFAULT(0), orientation  VARCHAR (255) DEFAULT portrait);";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE structure (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING (255), parent_id INTEGER (10) DEFAULT (0));";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            this._processTreeNode(this.DiskTree.Nodes[0], "0");

            m_dbConnection.Close();

            MessageBox.Show("Диск успешно создан!", "КозаДиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _processTreeNode(TreeNode treeNode, string parentId)
        {
            string newParentId = parentId;

            foreach (TreeNode node in treeNode.Nodes)
            {
                //if its category
                if (node.ImageIndex == 1 || node.ImageIndex == 2)
                {
                    newParentId = this._insertCategory(node, parentId);
                }

                //if its document
                if (node.ImageIndex == 3)
                {
                    this._insetDocument(node, parentId);
                }

                this._processTreeNode(node, newParentId);
            }
        }

        private string _insertCategory(TreeNode categoryNode, string parentId)
        {
            string sql = $"INSERT INTO structure (name, parent_id) VALUES ('{categoryNode.Text}', '{parentId}');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string folderID = m_dbConnection.LastInsertRowId.ToString();
            return folderID;
        }

        private void _insetDocument(TreeNode documentNode, string categoryId)
        {
            //get document xml
            string markersXml = this.DataBase.getDocumentXml(documentNode.Name);
            string markersXmlEnc = Editor.Class.Encrypt.base64Encode(markersXml);

            //get document file
            string templateFile = "";
            string templateFileEnc = "";

            PrivateKeyFile keyFile = new PrivateKeyFile("D:\\MCFR\\SSH Key\\mcfr.key");
            PrivateKeyFile[] keyFiles = new[] { keyFile };

            var methods = new List<AuthenticationMethod>();
            methods.Add(new PasswordAuthenticationMethod("yury.patrin", "ClearMeaN"));
            methods.Add(new PrivateKeyAuthenticationMethod("yury.patrin", keyFiles));

            string fileName = this.DataBase.getTemplateFileName(documentNode.Name);
            string serverPath = @"/srv/hosts/kozaonline.com.ua/htdocs/data/document_templates/" + fileName;
            string localPath = System.IO.Path.GetTempPath() + fileName;

            try
            {
                var con = new ConnectionInfo("194.247.12.67", 22, "yury.patrin", methods.ToArray());
                using (var client = new SftpClient(con))
                {
                    client.Connect();

                    using (var fs = new FileStream(localPath, FileMode.Create))
                    {
                        client.DownloadFile(serverPath, fs);
                        fs.Close();
                    }
                }


                byte[] binarydata = File.ReadAllBytes(localPath);
                templateFileEnc = System.Convert.ToBase64String(binarydata, 0, binarydata.Length);
            }
            catch (Exception ex) { }

            string templateType = "0";

            // if that static file?
            string ext = Path.GetExtension(localPath);

            // if file extension != doc and docx - its static file
            if (ext != ".docx" && ext != ".doc")
            {
                templateType = "1";
            }
            //check is doc file is static
            else
            {
                templateType = this.DataBase.getTemplateType(documentNode.Name).ToString();
            }


            //insert document
            string sql = $"INSERT INTO templates (structure_id,file_ext,name,name_lower,markers_xml,template,type) VALUES('{categoryId}', '{ext}', '{documentNode.Text}', '{documentNode.Text.ToLower()}', '{markersXmlEnc}', '{templateFileEnc}', '{templateType}');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }
        }

        private void DiskNameBox_TextChanged(object sender, EventArgs e)
        {
            this.DiskTree.Nodes[0].Text = this.DiskNameBox.Text;
        }
    }
}
