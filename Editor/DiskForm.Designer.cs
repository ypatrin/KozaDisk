namespace Editor
{
    partial class DiskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Новый Диск");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DoubleDiskCheckbox = new System.Windows.Forms.CheckBox();
            this.RevisionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Disk2Group = new System.Windows.Forms.GroupBox();
            this.Disk2NameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Disk2DescriptionBox = new System.Windows.Forms.TextBox();
            this.Disk1Group = new System.Windows.Forms.GroupBox();
            this.DiskNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DiskDescriptionBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CreateDiskBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.FilesBrowser = new System.Windows.Forms.WebBrowser();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.DiskTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel22 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.NewFolderName = new System.Windows.Forms.TextBox();
            this.NewFolderLabel = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.KOTreeCatalogs = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Disk2Group.SuspendLayout();
            this.Disk1Group.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.Disk2Group);
            this.panel1.Controls.Add(this.Disk1Group);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 118);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DoubleDiskCheckbox);
            this.groupBox3.Controls.Add(this.RevisionBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(1121, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 96);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // DoubleDiskCheckbox
            // 
            this.DoubleDiskCheckbox.AutoSize = true;
            this.DoubleDiskCheckbox.Location = new System.Drawing.Point(14, 65);
            this.DoubleDiskCheckbox.Name = "DoubleDiskCheckbox";
            this.DoubleDiskCheckbox.Size = new System.Drawing.Size(174, 20);
            this.DoubleDiskCheckbox.TabIndex = 6;
            this.DoubleDiskCheckbox.Text = "Два віртуальних диска";
            this.DoubleDiskCheckbox.UseVisualStyleBackColor = true;
            this.DoubleDiskCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RevisionBox
            // 
            this.RevisionBox.Location = new System.Drawing.Point(14, 36);
            this.RevisionBox.Name = "RevisionBox";
            this.RevisionBox.Size = new System.Drawing.Size(180, 23);
            this.RevisionBox.TabIndex = 5;
            this.RevisionBox.Text = "2017.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Випуск";
            // 
            // Disk2Group
            // 
            this.Disk2Group.Controls.Add(this.Disk2NameBox);
            this.Disk2Group.Controls.Add(this.label4);
            this.Disk2Group.Controls.Add(this.label5);
            this.Disk2Group.Controls.Add(this.Disk2DescriptionBox);
            this.Disk2Group.Enabled = false;
            this.Disk2Group.Font = new System.Drawing.Font("Arial", 11F);
            this.Disk2Group.Location = new System.Drawing.Point(566, 10);
            this.Disk2Group.Name = "Disk2Group";
            this.Disk2Group.Size = new System.Drawing.Size(549, 96);
            this.Disk2Group.TabIndex = 7;
            this.Disk2Group.TabStop = false;
            this.Disk2Group.Text = "Диск 2";
            // 
            // Disk2NameBox
            // 
            this.Disk2NameBox.Location = new System.Drawing.Point(109, 22);
            this.Disk2NameBox.Name = "Disk2NameBox";
            this.Disk2NameBox.Size = new System.Drawing.Size(412, 24);
            this.Disk2NameBox.TabIndex = 1;
            this.Disk2NameBox.TextChanged += new System.EventHandler(this.Disk2NameBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.Location = new System.Drawing.Point(20, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Тема диска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.Location = new System.Drawing.Point(61, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Опис";
            // 
            // Disk2DescriptionBox
            // 
            this.Disk2DescriptionBox.Location = new System.Drawing.Point(109, 56);
            this.Disk2DescriptionBox.Name = "Disk2DescriptionBox";
            this.Disk2DescriptionBox.Size = new System.Drawing.Size(412, 24);
            this.Disk2DescriptionBox.TabIndex = 3;
            // 
            // Disk1Group
            // 
            this.Disk1Group.Controls.Add(this.DiskNameBox);
            this.Disk1Group.Controls.Add(this.label1);
            this.Disk1Group.Controls.Add(this.label2);
            this.Disk1Group.Controls.Add(this.DiskDescriptionBox);
            this.Disk1Group.Font = new System.Drawing.Font("Arial", 11F);
            this.Disk1Group.Location = new System.Drawing.Point(11, 10);
            this.Disk1Group.Name = "Disk1Group";
            this.Disk1Group.Size = new System.Drawing.Size(549, 96);
            this.Disk1Group.TabIndex = 6;
            this.Disk1Group.TabStop = false;
            this.Disk1Group.Text = "Диск 1";
            // 
            // DiskNameBox
            // 
            this.DiskNameBox.Location = new System.Drawing.Point(109, 22);
            this.DiskNameBox.Name = "DiskNameBox";
            this.DiskNameBox.Size = new System.Drawing.Size(412, 24);
            this.DiskNameBox.TabIndex = 1;
            this.DiskNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тема диска";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(61, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Опис";
            // 
            // DiskDescriptionBox
            // 
            this.DiskDescriptionBox.Location = new System.Drawing.Point(109, 56);
            this.DiskDescriptionBox.Name = "DiskDescriptionBox";
            this.DiskDescriptionBox.Size = new System.Drawing.Size(412, 24);
            this.DiskDescriptionBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.CreateDiskBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 632);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1352, 60);
            this.panel2.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::Editor.Properties.Resources.open_icon;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(19, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 40);
            this.button6.TabIndex = 2;
            this.button6.Text = "Відкрити";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Editor.Properties.Resources.save_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1221, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "Зберегти";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CreateDiskBtn
            // 
            this.CreateDiskBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateDiskBtn.BackColor = System.Drawing.Color.White;
            this.CreateDiskBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CreateDiskBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.CreateDiskBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.CreateDiskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateDiskBtn.Image = global::Editor.Properties.Resources.import_icon;
            this.CreateDiskBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateDiskBtn.Location = new System.Drawing.Point(1018, 9);
            this.CreateDiskBtn.Name = "CreateDiskBtn";
            this.CreateDiskBtn.Size = new System.Drawing.Size(186, 40);
            this.CreateDiskBtn.TabIndex = 0;
            this.CreateDiskBtn.Text = "Імпортувати шаблони";
            this.CreateDiskBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateDiskBtn.UseVisualStyleBackColor = false;
            this.CreateDiskBtn.Click += new System.EventHandler(this.CreateDiskBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1352, 514);
            this.panel3.TabIndex = 3;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel16);
            this.panel11.Controls.Add(this.panel15);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(393, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(582, 514);
            this.panel11.TabIndex = 5;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.FilesBrowser);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(20, 20);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(542, 474);
            this.panel16.TabIndex = 6;
            // 
            // FilesBrowser
            // 
            this.FilesBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesBrowser.IsWebBrowserContextMenuEnabled = false;
            this.FilesBrowser.Location = new System.Drawing.Point(0, 0);
            this.FilesBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.FilesBrowser.Name = "FilesBrowser";
            this.FilesBrowser.ScriptErrorsSuppressed = true;
            this.FilesBrowser.Size = new System.Drawing.Size(540, 472);
            this.FilesBrowser.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(20, 494);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(542, 20);
            this.panel15.TabIndex = 4;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(562, 20);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(20, 494);
            this.panel14.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 20);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(20, 494);
            this.panel13.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(582, 20);
            this.panel12.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel21);
            this.panel10.Controls.Add(this.panel20);
            this.panel10.Controls.Add(this.panel19);
            this.panel10.Controls.Add(this.panel18);
            this.panel10.Controls.Add(this.panel17);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(975, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(377, 514);
            this.panel10.TabIndex = 4;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.SystemColors.Control;
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Controls.Add(this.panel23);
            this.panel21.Controls.Add(this.panel22);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(20, 20);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(337, 474);
            this.panel21.TabIndex = 6;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.DiskTree);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(335, 385);
            this.panel23.TabIndex = 1;
            // 
            // DiskTree
            // 
            this.DiskTree.AllowDrop = true;
            this.DiskTree.BackColor = System.Drawing.Color.White;
            this.DiskTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiskTree.FullRowSelect = true;
            this.DiskTree.HideSelection = false;
            this.DiskTree.HotTracking = true;
            this.DiskTree.ImageIndex = 3;
            this.DiskTree.ImageList = this.imageList1;
            this.DiskTree.Location = new System.Drawing.Point(0, 0);
            this.DiskTree.Name = "DiskTree";
            treeNode1.Name = "NewDisk";
            treeNode1.Text = "Новый Диск";
            this.DiskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.DiskTree.SelectedImageIndex = 3;
            this.DiskTree.ShowNodeToolTips = true;
            this.DiskTree.Size = new System.Drawing.Size(335, 385);
            this.DiskTree.TabIndex = 1;
            this.DiskTree.TabStop = false;
            this.DiskTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.DiskTree_ItemDrag);
            this.DiskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DiskTree_AfterSelect);
            this.DiskTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.DiskTree_DragDrop);
            this.DiskTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.DiskTree_DragEnter);
            this.DiskTree.DragOver += new System.Windows.Forms.DragEventHandler(this.DiskTree_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "KO.png");
            this.imageList1.Images.SetKeyName(1, "folder-closed.png");
            this.imageList1.Images.SetKeyName(2, "Folder-open.png");
            this.imageList1.Images.SetKeyName(3, "disk_big_act.png");
            this.imageList1.Images.SetKeyName(4, "document.png");
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.button5);
            this.panel22.Controls.Add(this.button4);
            this.panel22.Controls.Add(this.button2);
            this.panel22.Controls.Add(this.button1);
            this.panel22.Controls.Add(this.NewFolderName);
            this.panel22.Controls.Add(this.NewFolderLabel);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel22.Location = new System.Drawing.Point(0, 385);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(335, 87);
            this.panel22.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(299, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "↓";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(266, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "↑";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 9F);
            this.button2.Location = new System.Drawing.Point(93, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Видалити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.Location = new System.Drawing.Point(11, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewFolderName
            // 
            this.NewFolderName.Location = new System.Drawing.Point(11, 27);
            this.NewFolderName.Name = "NewFolderName";
            this.NewFolderName.Size = new System.Drawing.Size(315, 23);
            this.NewFolderName.TabIndex = 1;
            // 
            // NewFolderLabel
            // 
            this.NewFolderLabel.AutoSize = true;
            this.NewFolderLabel.Location = new System.Drawing.Point(8, 7);
            this.NewFolderLabel.Name = "NewFolderLabel";
            this.NewFolderLabel.Size = new System.Drawing.Size(97, 16);
            this.NewFolderLabel.TabIndex = 0;
            this.NewFolderLabel.Text = "Додати папку";
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(20, 494);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(337, 20);
            this.panel20.TabIndex = 5;
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel19.Location = new System.Drawing.Point(357, 20);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(20, 494);
            this.panel19.TabIndex = 4;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(0, 20);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(20, 494);
            this.panel18.TabIndex = 3;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(377, 20);
            this.panel17.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 514);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.KOTreeCatalogs);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(20, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(353, 474);
            this.panel7.TabIndex = 4;
            // 
            // KOTreeCatalogs
            // 
            this.KOTreeCatalogs.BackColor = System.Drawing.Color.White;
            this.KOTreeCatalogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KOTreeCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KOTreeCatalogs.Font = new System.Drawing.Font("Arial", 10F);
            this.KOTreeCatalogs.HideSelection = false;
            this.KOTreeCatalogs.ImageIndex = 0;
            this.KOTreeCatalogs.ImageList = this.imageList1;
            this.KOTreeCatalogs.Location = new System.Drawing.Point(0, 0);
            this.KOTreeCatalogs.Name = "KOTreeCatalogs";
            this.KOTreeCatalogs.SelectedImageIndex = 0;
            this.KOTreeCatalogs.Size = new System.Drawing.Size(351, 472);
            this.KOTreeCatalogs.TabIndex = 0;
            this.KOTreeCatalogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.KOTreeCatalogs_AfterSelect);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(20, 494);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(353, 20);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(373, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 494);
            this.panel5.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(20, 494);
            this.panel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(393, 20);
            this.panel9.TabIndex = 0;
            // 
            // DiskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1352, 692);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DiskForm";
            this.Text = "КОЗА-ДИСК Редактор";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SingleDiskForm_FormClosed);
            this.Load += new System.EventHandler(this.SingleDiskForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Disk2Group.ResumeLayout(false);
            this.Disk2Group.PerformLayout();
            this.Disk1Group.ResumeLayout(false);
            this.Disk1Group.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RevisionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DiskDescriptionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DiskNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TreeView KOTreeCatalogs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.WebBrowser FilesBrowser;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TreeView DiskTree;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NewFolderName;
        private System.Windows.Forms.Label NewFolderLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CreateDiskBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox Disk2Group;
        private System.Windows.Forms.TextBox Disk2NameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Disk2DescriptionBox;
        private System.Windows.Forms.GroupBox Disk1Group;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox DoubleDiskCheckbox;
        private System.Windows.Forms.Button button6;
    }
}