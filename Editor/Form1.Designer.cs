namespace Editor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test", "1484268907_EditDocument.png");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("01.2017", 4, 4);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Новый диск");
            this.panel1 = new System.Windows.Forms.Panel();
            this.DiskDescriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DiskRevisionBox = new System.Windows.Forms.TextBox();
            this.DiskNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CreateDiskBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.ListDocuments = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel13 = new System.Windows.Forms.Panel();
            this.LinkBox = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.SelectedDocument = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.DiskTree = new System.Windows.Forms.TreeView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.DeleteDiskNodeBtn = new System.Windows.Forms.Button();
            this.NewFolderBtn = new System.Windows.Forms.Button();
            this.NewFolderName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.TreeCatalogs = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DiskDescriptionBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DiskRevisionBox);
            this.panel1.Controls.Add(this.DiskNameBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 40);
            this.panel1.TabIndex = 0;
            // 
            // DiskDescriptionBox
            // 
            this.DiskDescriptionBox.Location = new System.Drawing.Point(511, 7);
            this.DiskDescriptionBox.Name = "DiskDescriptionBox";
            this.DiskDescriptionBox.Size = new System.Drawing.Size(364, 24);
            this.DiskDescriptionBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Описание";
            // 
            // DiskRevisionBox
            // 
            this.DiskRevisionBox.Location = new System.Drawing.Point(1004, 8);
            this.DiskRevisionBox.Name = "DiskRevisionBox";
            this.DiskRevisionBox.Size = new System.Drawing.Size(120, 24);
            this.DiskRevisionBox.TabIndex = 7;
            this.DiskRevisionBox.Text = "01.2017";
            // 
            // DiskNameBox
            // 
            this.DiskNameBox.Location = new System.Drawing.Point(101, 7);
            this.DiskNameBox.Name = "DiskNameBox";
            this.DiskNameBox.Size = new System.Drawing.Size(315, 24);
            this.DiskNameBox.TabIndex = 6;
            this.DiskNameBox.TextChanged += new System.EventHandler(this.DiskNameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(881, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер выпуска";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя диска";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CreateDiskBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(0, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1152, 59);
            this.panel2.TabIndex = 1;
            // 
            // CreateDiskBtn
            // 
            this.CreateDiskBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CreateDiskBtn.Location = new System.Drawing.Point(482, 14);
            this.CreateDiskBtn.Name = "CreateDiskBtn";
            this.CreateDiskBtn.Size = new System.Drawing.Size(137, 29);
            this.CreateDiskBtn.TabIndex = 0;
            this.CreateDiskBtn.Text = "Создать диск";
            this.CreateDiskBtn.UseVisualStyleBackColor = false;
            this.CreateDiskBtn.Click += new System.EventHandler(this.CreateDiskBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1152, 440);
            this.panel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(308, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(480, 430);
            this.panel7.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(480, 385);
            this.panel10.TabIndex = 1;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.ListDocuments);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 23);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(480, 362);
            this.panel14.TabIndex = 1;
            // 
            // ListDocuments
            // 
            this.ListDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDocuments.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ListDocuments.LargeImageList = this.imageList1;
            this.ListDocuments.Location = new System.Drawing.Point(0, 0);
            this.ListDocuments.Name = "ListDocuments";
            this.ListDocuments.Size = new System.Drawing.Size(480, 362);
            this.ListDocuments.SmallImageList = this.imageList1;
            this.ListDocuments.TabIndex = 3;
            this.ListDocuments.UseCompatibleStateImageBehavior = false;
            this.ListDocuments.View = System.Windows.Forms.View.List;
            this.ListDocuments.SelectedIndexChanged += new System.EventHandler(this.ListDocuments_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1484269124_www_page.png");
            this.imageList1.Images.SetKeyName(1, "Folder-closed.png");
            this.imageList1.Images.SetKeyName(2, "Folder-open.png");
            this.imageList1.Images.SetKeyName(3, "1484268907_EditDocument.png");
            this.imageList1.Images.SetKeyName(4, "disck-focus.png");
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.LinkBox);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(480, 23);
            this.panel13.TabIndex = 0;
            // 
            // LinkBox
            // 
            this.LinkBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LinkBox.Location = new System.Drawing.Point(0, 0);
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(480, 22);
            this.LinkBox.TabIndex = 2;
            this.LinkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.SelectedDocument);
            this.panel8.Controls.Add(this.AddButton);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 385);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(480, 45);
            this.panel8.TabIndex = 0;
            // 
            // SelectedDocument
            // 
            this.SelectedDocument.AutoSize = true;
            this.SelectedDocument.Location = new System.Drawing.Point(108, 9);
            this.SelectedDocument.Name = "SelectedDocument";
            this.SelectedDocument.Size = new System.Drawing.Size(0, 16);
            this.SelectedDocument.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(6, 6);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(96, 31);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel12);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(788, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(364, 430);
            this.panel6.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.DiskTree);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(364, 330);
            this.panel12.TabIndex = 1;
            // 
            // DiskTree
            // 
            this.DiskTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiskTree.HideSelection = false;
            this.DiskTree.ImageIndex = 0;
            this.DiskTree.ImageList = this.imageList1;
            this.DiskTree.Location = new System.Drawing.Point(0, 0);
            this.DiskTree.Name = "DiskTree";
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "0";
            treeNode1.SelectedImageIndex = 4;
            treeNode1.Text = "01.2017";
            this.DiskTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.DiskTree.SelectedImageIndex = 0;
            this.DiskTree.Size = new System.Drawing.Size(364, 330);
            this.DiskTree.TabIndex = 0;
            this.DiskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DiskView_AfterSelect);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.DeleteDiskNodeBtn);
            this.panel11.Controls.Add(this.NewFolderBtn);
            this.panel11.Controls.Add(this.NewFolderName);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 330);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(364, 100);
            this.panel11.TabIndex = 0;
            // 
            // DeleteDiskNodeBtn
            // 
            this.DeleteDiskNodeBtn.Enabled = false;
            this.DeleteDiskNodeBtn.Location = new System.Drawing.Point(117, 63);
            this.DeleteDiskNodeBtn.Name = "DeleteDiskNodeBtn";
            this.DeleteDiskNodeBtn.Size = new System.Drawing.Size(94, 29);
            this.DeleteDiskNodeBtn.TabIndex = 3;
            this.DeleteDiskNodeBtn.Text = "Удалить";
            this.DeleteDiskNodeBtn.UseVisualStyleBackColor = true;
            this.DeleteDiskNodeBtn.Click += new System.EventHandler(this.DeleteDiskNodeBtn_Click);
            // 
            // NewFolderBtn
            // 
            this.NewFolderBtn.Location = new System.Drawing.Point(9, 63);
            this.NewFolderBtn.Name = "NewFolderBtn";
            this.NewFolderBtn.Size = new System.Drawing.Size(102, 29);
            this.NewFolderBtn.TabIndex = 2;
            this.NewFolderBtn.Text = "Создать";
            this.NewFolderBtn.UseVisualStyleBackColor = true;
            this.NewFolderBtn.Click += new System.EventHandler(this.NewFolderBtn_Click);
            // 
            // NewFolderName
            // 
            this.NewFolderName.Location = new System.Drawing.Point(9, 32);
            this.NewFolderName.Name = "NewFolderName";
            this.NewFolderName.Size = new System.Drawing.Size(343, 22);
            this.NewFolderName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Создать папку";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(308, 430);
            this.panel5.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.TreeCatalogs);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(308, 430);
            this.panel9.TabIndex = 1;
            // 
            // TreeCatalogs
            // 
            this.TreeCatalogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TreeCatalogs.HideSelection = false;
            this.TreeCatalogs.ImageIndex = 0;
            this.TreeCatalogs.ImageList = this.imageList1;
            this.TreeCatalogs.Location = new System.Drawing.Point(0, 0);
            this.TreeCatalogs.Name = "TreeCatalogs";
            treeNode2.Name = "Disk";
            treeNode2.Text = "Новый диск";
            this.TreeCatalogs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.TreeCatalogs.SelectedImageIndex = 0;
            this.TreeCatalogs.Size = new System.Drawing.Size(308, 430);
            this.TreeCatalogs.TabIndex = 1;
            this.TreeCatalogs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeCatalogs_AfterSelect);
            this.TreeCatalogs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeCatalogs_NodeMouseClick);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1152, 10);
            this.panel4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1152, 539);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "КозаДиск 2.0 Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DiskRevisionBox;
        private System.Windows.Forms.TextBox DiskNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button CreateDiskBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TreeView TreeCatalogs;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label SelectedDocument;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button NewFolderBtn;
        private System.Windows.Forms.TextBox NewFolderName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TreeView DiskTree;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.ListView ListDocuments;
        private System.Windows.Forms.Button DeleteDiskNodeBtn;
        private System.Windows.Forms.TextBox DiskDescriptionBox;
        private System.Windows.Forms.Label label3;
    }
}

