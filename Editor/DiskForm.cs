using Editor.Class;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Editor
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class DiskForm : Form
    {
        Editor.Class.DB DataBase = new Editor.Class.DB();
        SQLiteConnection m_dbConnection;

        public DiskForm()
        {
            InitializeComponent();
        }

        private void SingleDiskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SingleDiskForm_Load(object sender, EventArgs e)
        {
            //prepare tree
            this.KOTreeCatalogs.Nodes.Clear();
            List<Editor.Class.Catalog> catalogs = this.DataBase.getCatalogs();

            CatalogNode baseNode = new CatalogNode();
            baseNode.Text = "Коза Онлайн";

            foreach (Editor.Class.Catalog catalog in catalogs)
            {
                if (catalog.parentId == "0")
                {
                    CatalogNode node = new CatalogNode();
                    node.id = catalog.id;
                    node.name = catalog.id;
                    node.Text = $"[{catalog.id}] " + catalog.name;
                    node.catalogName = catalog.name;
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;

                    //get parent
                    foreach (Editor.Class.Catalog parentCatalog in catalogs)
                    {
                        if (catalog.id == parentCatalog.parentId)
                        {
                            CatalogNode parentNode = new CatalogNode();
                            parentNode.id = parentCatalog.id;
                            parentNode.name = parentCatalog.id;
                            parentNode.Text = $"[{parentCatalog.id}] " + parentCatalog.name;
                            parentNode.catalogName = parentCatalog.name;
                            parentNode.ImageIndex = 1;
                            parentNode.SelectedImageIndex = 2;

                            node.Nodes.Add(parentNode);
                        }

                    }

                    baseNode.Nodes.Add(node);
                }
            }

            this.KOTreeCatalogs.Nodes.Add(baseNode);

            //prepare browser
            this.FilesBrowser.ObjectForScripting = this;
            this.FilesBrowser.Navigate("about:blank");
            this.FilesBrowser.DocumentText = "0";
            this.FilesBrowser.Document.OpenNew(true);
            this.FilesBrowser.Document.Write("");
            this.FilesBrowser.Refresh();
        }

        private void KOTreeCatalogs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CatalogNode selectedNode = (CatalogNode)this.KOTreeCatalogs.SelectedNode;
            string filesHtml = Properties.Resources.Files;
            string fileHtml = "";

            this.FilesBrowser.Document.OpenNew(true);

            if (selectedNode != null)
            {
                List<Editor.Class.Document> documents = this.DataBase.getDocuments(selectedNode.id);

                foreach (Editor.Class.Document document in documents)
                {
                    string fileName = document.name;
                    string fileNameFull = document.name;

                    if (fileName.Length > 45)
                    {
                        fileName = fileName.Substring(0, 45) + "...";
                    }

                    if (fileName == fileNameFull)
                        fileNameFull = String.Empty;

                    fileHtml += $"<div class=\"block\" type=\"folder\">";
                    fileHtml += $"<div class=\"head\" title=\"{fileNameFull}\">{fileName}</div>";
                    fileHtml += $"<div class=\"image\"><img src=\"{Constant.ApplcationPath}icon\\doc.png\"/></div>";
                    fileHtml += $"<div class=\"tmpl_count\"><select id=\"doc_type_{document.id}\"><option value=\"portrait\">Портретный</option><option value=\"album\">Альбомный</option></select></div>";
                    fileHtml += $"<div class=\"tmpl_count\"><a href=\"#\" onClick=\"window.external.addDocument('{document.id}', '{document.name}'); return false;\" >Добавить</a></div>";
                    fileHtml += "</div>";
                }

                filesHtml = filesHtml.Replace("%disks_blocks%", fileHtml);
                filesHtml = filesHtml.Replace("%AppPath%", Constant.ApplcationPath);
                filesHtml = filesHtml.Replace("%AppPathUrl%", Constant.ApplcationPath.Replace(@"\", @"/"));

                this.FilesBrowser.Document.Write(filesHtml);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DiskTree.Nodes[0] != null)
                    this.DiskTree.Nodes[0].Text = this.DiskNameBox.Text;
            }
            catch(Exception ex)
            { }
        }

        //*******************************************************

        public void addDocument(string id, string docName)
        {
            //get type
            string type = FilesBrowser.Document.GetElementById("doc_type_"+id).GetAttribute("value");

            DocumentNode node = new DocumentNode();
            node.id = id;
            node.Text = docName;
            node.Name = docName;
            node.ImageIndex = 4;
            node.SelectedImageIndex = 4;

            if (type == "album")
            {
                node.Text = "[A] " + node.Text;
                node.documentType = "album";
            }
            else
            {
                node.Text = "[П] " + node.Text;
                node.documentType = "portrait";
            }

            TreeNode parentNode = this.DiskTree.SelectedNode ?? this.DiskTree.Nodes[0];
            if (parentNode != null)
            {
                parentNode.Nodes.Add(node);
                this.DiskTree.ExpandAll();
                this.NewFolderName.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Имя папки не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DiskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode parentNode = this.DiskTree.SelectedNode;
            NewFolderLabel.Text = "Добавить папку в " + parentNode.Text;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void CreateDiskBtn_Click(object sender, EventArgs e)
        {
            string disk1dbName = Editor.Class.Encrypt.MD5(this.RevisionBox.Text + "_1").ToLower() + ".db";
            string disk2dbName = Editor.Class.Encrypt.MD5(this.RevisionBox.Text + "_2").ToLower() + ".db";
            string ApplcationStorage = System.Windows.Forms.Application.StartupPath + @"\disks\" + this.RevisionBox.Text + @"\";

            if (Directory.Exists(ApplcationStorage))
            {
                MessageBox.Show("Такой диск уже создан. Измените имя выпуска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //create folder
                Directory.CreateDirectory(ApplcationStorage);
                Directory.CreateDirectory(ApplcationStorage + "to_cd");

                //copy source
                string SourcePath = System.Windows.Forms.Application.StartupPath + @"\source\";
                string DestinationPath = ApplcationStorage + "to_cd\\";

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);

                //create xml

                if (!this.DoubleDiskCheckbox.Checked)
                {
                    string diskXml = "";

                    diskXml += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
                    diskXml += "<disk>\n";
                    diskXml += $"    <name>{this.DiskNameBox.Text}</name>\n";
                    diskXml += $"    <description>{this.DiskDescriptionBox.Text}</description>\n";
                    diskXml += $"    <edition>{this.RevisionBox.Text}</edition>\n";
                    diskXml += $"    <db>{disk1dbName}</db>\n";
                    diskXml += "</disk>\n";

                    //save xml
                    File.AppendAllText(ApplcationStorage + "to_cd\\KozaDisk\\disk.xml", diskXml);
                }
                else
                {
                    string diskXml = "";

                    diskXml += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
                    diskXml += "<disks>\n";
                    diskXml += "    <disk>\n";
                    diskXml += $"       <name>{this.DiskNameBox.Text}</name>\n";
                    diskXml += $"       <description>{this.DiskDescriptionBox.Text}</description>\n";
                    diskXml += $"       <edition>{this.RevisionBox.Text}</edition>\n";
                    diskXml += $"       <db>{disk1dbName}</db>\n";
                    diskXml += "    </disk>\n";
                    diskXml += "    <disk>\n";
                    diskXml += $"       <name>{this.Disk2NameBox.Text}</name>\n";
                    diskXml += $"       <description>{this.Disk2DescriptionBox.Text}</description>\n";
                    diskXml += $"       <edition>{this.RevisionBox.Text}</edition>\n";
                    diskXml += $"       <db>{disk2dbName}</db>\n";
                    diskXml += "    </disk>\n";
                    diskXml += "</disks>\n";

                    //save xml
                    File.AppendAllText(ApplcationStorage + "to_cd\\KozaDisk\\disks.xml", diskXml);
                }

                /**********************************************
                                  DISK 1                      
                **********************************************/

                //created db
                SQLiteConnection.CreateFile(ApplcationStorage + "to_cd\\KozaDisk\\" + disk1dbName);
                m_dbConnection = new SQLiteConnection($"Data Source={ApplcationStorage}to_cd\\KozaDisk\\{disk1dbName};Version=3;");
                m_dbConnection.Open();

                string sql = "";

                sql = "CREATE TABLE templates (id INTEGER PRIMARY KEY AUTOINCREMENT, structure_id INTEGER(10) NOT NULL, file_ext VARCHAR (255), name STRING(255), name_lower STRING(255), markers_xml TEXT, template TEXT, type INTEGER(1) NOT NULL DEFAULT(0), orientation  VARCHAR (255) DEFAULT portrait);";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE structure (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING (255), parent_id INTEGER (10) DEFAULT (0));";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }

                this._processTreeNode(this.DiskTree.Nodes[0], "0");

                m_dbConnection.Close();

                /**********************************************
                                  DISK 2                      
                **********************************************/

                if (this.DoubleDiskCheckbox.Checked)
                {
                    //created db
                    SQLiteConnection.CreateFile(ApplcationStorage + "to_cd\\KozaDisk\\" + disk2dbName);
                    m_dbConnection = new SQLiteConnection($"Data Source={ApplcationStorage}to_cd\\KozaDisk\\{disk2dbName};Version=3;");
                    m_dbConnection.Open();

                    sql = "CREATE TABLE templates (id INTEGER PRIMARY KEY AUTOINCREMENT, structure_id INTEGER(10) NOT NULL, file_ext VARCHAR (255), name STRING(255), name_lower STRING(255), markers_xml TEXT, template TEXT, type INTEGER(1) NOT NULL DEFAULT(0), orientation  VARCHAR (255) DEFAULT portrait);";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "CREATE TABLE structure (id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING (255), parent_id INTEGER (10) DEFAULT (0));";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    this._processTreeNode(this.DiskTree.Nodes[0], "0");

                    m_dbConnection.Close();
                }

                //save information
                string infoXml = "";
                infoXml += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
                infoXml += "<info>\n";
                infoXml += $"    <disk_1 name=\"{this.DiskNameBox.Text}\" description=\"{this.DiskDescriptionBox.Text}\" edition=\"{this.RevisionBox.Text}\" >\n";

                foreach (TreeNode node in this.DiskTree.Nodes[0].Nodes)
                {
                    //if its category
                    if (node.ImageIndex == 1 || node.ImageIndex == 2)
                    {
                        infoXml += $"       <directory name=\"{node.Name}\" text=\"{node.Text}\">\n";

                        foreach (TreeNode docNode in node.Nodes)
                        {
                            //if its document
                            if (docNode.ImageIndex == 4)
                            {
                                DocumentNode dn = (DocumentNode)docNode;
                                infoXml += $"           <document id=\"{dn.id}\" name=\"{dn.Name}\" text=\"{dn.Text}\" orientation=\"{dn.documentType}\"/>\n";
                            }
                        }

                        infoXml += $"       </directory>\n";
                    }
                }

                infoXml += "    </disk_1>\n";

                if (this.DoubleDiskCheckbox.Checked)
                {
                    infoXml += $"    <disk_2 name=\"{this.Disk2NameBox.Text}\" description=\"{this.Disk2DescriptionBox.Text}\" edition=\"{this.RevisionBox.Text}\" >\n";

                    foreach (TreeNode node in this.DiskTree.Nodes[1].Nodes)
                    {
                        //if its category
                        if (node.ImageIndex == 1 || node.ImageIndex == 2)
                        {
                            infoXml += $"       <directory name=\"{node.Name}\" text=\"{node.Text}\">\n";

                            foreach (TreeNode docNode in node.Nodes)
                            {
                                //if its document
                                if (docNode.ImageIndex == 4)
                                {
                                    DocumentNode dn = (DocumentNode)docNode;
                                    infoXml += $"           <document id=\"{dn.id}\" name=\"{dn.Name}\" text=\"{dn.Text}\" orientation=\"{dn.documentType}\"/>\n";
                                }
                            }

                            infoXml += $"       </directory>\n";
                        }
                    }

                    infoXml += "    </disk_2>\n";
                }

                infoXml += "</info>\n";

                File.AppendAllText(ApplcationStorage + "disk_info.kd", infoXml);

                //done
                System.Diagnostics.Process.Start(ApplcationStorage);
            }
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
                if (node.ImageIndex == 4)
                {
                    this._insetDocument((DocumentNode)node, parentId);
                }

                this._processTreeNode(node, newParentId);
            }
        }

        private string _insertCategory(TreeNode categoryNode, string parentId)
        {
            string sql = $"INSERT INTO structure (name, parent_id) VALUES ('{categoryNode.Text}', '{parentId}');";
            using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
            {
                command.ExecuteNonQuery();
            }

            string folderID = m_dbConnection.LastInsertRowId.ToString();
            return folderID;
        }

        private void _insetDocument(DocumentNode documentNode, string categoryId)
        {
            //get document xml
            string markersXml = this.DataBase.getDocumentXml(documentNode.Name);
            string markersXmlEnc = Editor.Class.Encrypt.base64Encode(markersXml);

            //get document file
            string templateFile = "";
            string templateFileEnc = "";

            PrivateKeyFile keyFile = new PrivateKeyFile(Constant.ApplcationPath + "mcfr.key");
            PrivateKeyFile[] keyFiles = new[] { keyFile };

            var methods = new List<AuthenticationMethod>();
            methods.Add(new PasswordAuthenticationMethod("yury.patrin", "ClearMeaN"));
            methods.Add(new PrivateKeyAuthenticationMethod("yury.patrin", keyFiles));

            string fileName = this.DataBase.getTemplateFileName(documentNode.id);
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
                templateType = this.DataBase.getTemplateType(documentNode.id).ToString();
            }


            //insert document
            string sql = $"INSERT INTO templates (structure_id,file_ext,name,name_lower,markers_xml,template,type,orientation) VALUES('{categoryId}', '{ext}', '{documentNode.Name}', '{documentNode.Name.ToLower()}', '{markersXmlEnc}', '{templateFileEnc}', '{templateType}', '{documentNode.documentType}');";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.FileName = this.RevisionBox.Text.Replace(".","_") + ".kd";
            sfd.Filter = "КОЗА-ДИСК Инфо|*.kd";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;

                //save information
                string infoXml = "";
                infoXml += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
                infoXml += "<info>\n";
                infoXml += $"    <disk_1 name=\"{this.DiskNameBox.Text}\" description=\"{this.DiskDescriptionBox.Text}\" edition=\"{this.RevisionBox.Text}\" >\n";

                foreach (TreeNode node in this.DiskTree.Nodes[0].Nodes)
                {
                    //if its category
                    if (node.ImageIndex == 1 || node.ImageIndex == 2)
                    {
                        infoXml += $"       <directory name=\"{node.Name}\" text=\"{node.Text}\">\n";

                        foreach (TreeNode docNode in node.Nodes)
                        {
                            //if its document
                            if (docNode.ImageIndex == 4)
                            {
                                DocumentNode dn = (DocumentNode)docNode;
                                infoXml += $"           <document id=\"{dn.id}\" name=\"{dn.Name}\" text=\"{dn.Text}\" orientation=\"{dn.documentType}\"/>\n";
                            }
                        }

                        infoXml += $"       </directory>\n";
                    }
                }

                infoXml += "    </disk_1>\n";

                if (this.DoubleDiskCheckbox.Checked)
                {
                    infoXml += $"    <disk_2 name=\"{this.Disk2NameBox.Text}\" description=\"{this.Disk2DescriptionBox.Text}\" edition=\"{this.RevisionBox.Text}\" >\n";

                    foreach (TreeNode node in this.DiskTree.Nodes[1].Nodes)
                    {
                        //if its category
                        if (node.ImageIndex == 1 || node.ImageIndex == 2)
                        {
                            infoXml += $"       <directory name=\"{node.Name}\" text=\"{node.Text}\">\n";

                            foreach (TreeNode docNode in node.Nodes)
                            {
                                //if its document
                                if (docNode.ImageIndex == 4)
                                {
                                    DocumentNode dn = (DocumentNode)docNode;
                                    infoXml += $"           <document id=\"{dn.id}\" name=\"{dn.Name}\" text=\"{dn.Text}\" orientation=\"{dn.documentType}\"/>\n";
                                }
                            }

                            infoXml += $"       </directory>\n";
                        }
                    }

                    infoXml += "    </disk_2>\n";
                }

                infoXml += "</info>\n";

                File.AppendAllText(FileName, infoXml);
                MessageBox.Show("Успешно сохранено!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DiskTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void DiskTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void DiskTree_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = this.DiskTree.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = this.DiskTree.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        private void DiskTree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = this.DiskTree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            this.DiskTree.SelectedNode = this.DiskTree.GetNodeAt(targetPoint);
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.DiskTree.SelectedNode != null && this.DiskTree.SelectedNode.PrevNode != null)
            {
                // define edit collection
                TreeNodeCollection editNodes;
                if (this.DiskTree.SelectedNode.Parent != null)
                    editNodes = this.DiskTree.SelectedNode.Parent.Nodes;
                else
                    editNodes = this.DiskTree.Nodes;

                // define indexes
                int indexSelectedNode = this.DiskTree.SelectedNode.Index;
                int indexPreviousNode = this.DiskTree.SelectedNode.PrevNode.Index;

                // store node
                TreeNode selectedNode = this.DiskTree.SelectedNode;

                // swap
                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexPreviousNode, selectedNode);

                // select node
                this.DiskTree.SelectedNode = selectedNode;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.DiskTree.SelectedNode != null && this.DiskTree.SelectedNode.NextNode != null)
            {
                // define edit collection
                TreeNodeCollection editNodes;
                if (this.DiskTree.SelectedNode.Parent != null)
                    editNodes = this.DiskTree.SelectedNode.Parent.Nodes;
                else
                    editNodes = this.DiskTree.Nodes;

                // define indexes
                int indexSelectedNode = this.DiskTree.SelectedNode.Index;
                int indexNextNode = this.DiskTree.SelectedNode.NextNode.Index;

                // store node
                TreeNode selectedNode = this.DiskTree.SelectedNode;

                // swap
                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexNextNode, selectedNode);

                // select node
                this.DiskTree.SelectedNode = selectedNode;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DoubleDiskCheckbox.Checked)
            {
                Disk2Group.Enabled = true;
                TreeNode disk2 = new TreeNode();
                disk2.Text = "Новый диск 2";

                if (Disk2NameBox.Text.Trim() != "")
                {
                    disk2.Text = Disk2NameBox.Text.Trim();
                }

                this.DiskTree.Nodes.Add(disk2);
            }
            else
            {
                Disk2Group.Enabled = false;
                this.DiskTree.Nodes[1].Remove();
            }
        }

        private void Disk2NameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DiskTree.Nodes[1] != null)
                    this.DiskTree.Nodes[1].Text = this.Disk2NameBox.Text;
            }
            catch(Exception ex)
            { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "disk_info.kd";
            ofd.Filter = "КОЗА-ДИСК Инфо|*.kd";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(ofd.FileName);

                    XmlNode xmlDisk1 = xml.SelectSingleNode("/info/disk_1");
                    XmlNode xmlDisk2 = xml.SelectSingleNode("/info/disk_2");

                    if (xmlDisk2 == null)
                    {
                        this.DoubleDiskCheckbox.Checked = false;
                        this.Disk2Group.Enabled = false;
                    }
                    else
                    {
                        this.DoubleDiskCheckbox.Checked = true;
                        this.Disk2Group.Enabled = true;
                    }

                    //process disk1
                    if (xmlDisk1 != null)
                    {
                        //clear nodes
                        this.DiskTree.Nodes.Clear();

                        this.DiskNameBox.Text = xmlDisk1.Attributes["name"].Value;
                        this.DiskDescriptionBox.Text = xmlDisk1.Attributes["description"].Value;
                        this.RevisionBox.Text = xmlDisk1.Attributes["edition"].Value;

                        //add disk1 node
                        TreeNode disk1 = new TreeNode();

                        disk1.Text = xmlDisk1.Attributes["name"].Value;
                        disk1.ImageIndex = 3;
                        disk1.SelectedImageIndex = 3;

                        //add directories
                        foreach (XmlNode xmlDir in xml.SelectNodes("/info/disk_1/directory"))
                        {
                            DocumentNode directory = new DocumentNode();
                            directory.Name = xmlDir.Attributes["name"].Value;
                            directory.Text = xmlDir.Attributes["text"].Value;
                            directory.ImageIndex = 1;
                            directory.SelectedImageIndex = 2;

                            //add documents
                            foreach (XmlNode xmlDoc in xmlDir.SelectNodes("document"))
                            {
                                DocumentNode document = new DocumentNode();
                                document.id = xmlDoc.Attributes["id"].Value;
                                document.Name = xmlDoc.Attributes["name"].Value;
                                document.Text = xmlDoc.Attributes["text"].Value;
                                document.documentType = xmlDoc.Attributes["orientation"].Value;
                                document.ImageIndex = 4;
                                document.SelectedImageIndex = 4;

                                directory.Nodes.Add(document);
                            }

                            disk1.Nodes.Add(directory);
                        }

                        this.DiskTree.Nodes.Add(disk1);
                    }

                    //process disk2
                    if (xmlDisk2 != null)
                    {
                        this.Disk2NameBox.Text = xmlDisk2.Attributes["name"].Value;
                        this.Disk2DescriptionBox.Text = xmlDisk2.Attributes["description"].Value;

                        //add disk2 node
                        TreeNode disk2 = new TreeNode();

                        disk2.Text = xmlDisk2.Attributes["name"].Value;
                        disk2.ImageIndex = 3;
                        disk2.SelectedImageIndex = 3;

                        //add directories
                        foreach (XmlNode xmlDir in xml.SelectNodes("/info/disk_2/directory"))
                        {
                            DocumentNode directory = new DocumentNode();
                            directory.Name = xmlDir.Attributes["name"].Value;
                            directory.Text = xmlDir.Attributes["text"].Value;
                            directory.ImageIndex = 1;
                            directory.SelectedImageIndex = 2;

                            //add documents
                            foreach (XmlNode xmlDoc in xmlDir.SelectNodes("document"))
                            {
                                DocumentNode document = new DocumentNode();
                                document.id = xmlDoc.Attributes["id"].Value;
                                document.Name = xmlDoc.Attributes["name"].Value;
                                document.Text = xmlDoc.Attributes["text"].Value;
                                document.documentType = xmlDoc.Attributes["orientation"].Value;
                                document.ImageIndex = 4;
                                document.SelectedImageIndex = 4;

                                directory.Nodes.Add(document);
                            }

                            disk2.Nodes.Add(directory);
                        }

                        this.DiskTree.Nodes.Add(disk2);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Помилка відкриття файлу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.DiskTree.ExpandAll();
            }
        }
    }
}
