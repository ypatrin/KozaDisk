namespace KozaDisk.Forms
{
    partial class TemplatesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplatesList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.PictureBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AutoFillBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.mdListViewDisabled = new System.Windows.Forms.PictureBox();
            this.mdListViewEnabled = new System.Windows.Forms.PictureBox();
            this.mdBlockViewEnabled = new System.Windows.Forms.PictureBox();
            this.mdBlockViewDisabled = new System.Windows.Forms.PictureBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.BlockViewImg = new System.Windows.Forms.PictureBox();
            this.ListViewBtn = new System.Windows.Forms.PictureBox();
            this.BlockViewBtn = new System.Windows.Forms.PictureBox();
            this.ListViewImg = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.NaviBrowser = new System.Windows.Forms.WebBrowser();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Tabs = new TablessControl();
            this.TreeTab = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.FilesBrowser = new System.Windows.Forms.WebBrowser();
            this.panel9 = new System.Windows.Forms.Panel();
            this.DiskTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ListTab = new System.Windows.Forms.TabPage();
            this.DisksBlocksBrowser = new System.Windows.Forms.WebBrowser();
            this.MyDocsBlockTab = new System.Windows.Forms.TabPage();
            this.MyDocsBlockBrowser = new System.Windows.Forms.WebBrowser();
            this.MyDocsListTab = new System.Windows.Forms.TabPage();
            this.MyDocsListBrowser = new System.Windows.Forms.WebBrowser();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.SearchBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdListViewDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdListViewEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBlockViewEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBlockViewDisabled)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockViewImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlockViewBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewImg)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.TreeTab.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.ListTab.SuspendLayout();
            this.MyDocsBlockTab.SuspendLayout();
            this.MyDocsListTab.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 91);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(644, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(370, 91);
            this.panel5.TabIndex = 2;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(370, 91);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.SearchBtn);
            this.panel6.Controls.Add(this.searchBox);
            this.panel6.Location = new System.Drawing.Point(9, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(349, 28);
            this.panel6.TabIndex = 0;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Image = global::KozaDisk.Properties.Resources.search;
            this.SearchBtn.Location = new System.Drawing.Point(315, 2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(26, 22);
            this.SearchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click_1);
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(349, 26);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged_1);
            this.searchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.AutoFillBtn);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 91);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.button1.Location = new System.Drawing.Point(566, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 38);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.button2.Location = new System.Drawing.Point(410, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 38);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "Мої документи";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // AutoFillBtn
            // 
            this.AutoFillBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.AutoFillBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoFillBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AutoFillBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.AutoFillBtn.Location = new System.Drawing.Point(240, 26);
            this.AutoFillBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.AutoFillBtn.Name = "AutoFillBtn";
            this.AutoFillBtn.Size = new System.Drawing.Size(140, 38);
            this.AutoFillBtn.TabIndex = 4;
            this.AutoFillBtn.TabStop = false;
            this.AutoFillBtn.Text = "Автозаповнення";
            this.AutoFillBtn.UseVisualStyleBackColor = true;
            this.AutoFillBtn.Click += new System.EventHandler(this.AutoFillBtn_Click);
            this.AutoFillBtn.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.AutoFillBtn.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KozaDisk.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(21, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 48);
            this.panel2.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.mdListViewDisabled);
            this.panel12.Controls.Add(this.mdListViewEnabled);
            this.panel12.Controls.Add(this.mdBlockViewEnabled);
            this.panel12.Controls.Add(this.mdBlockViewDisabled);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(857, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(82, 48);
            this.panel12.TabIndex = 4;
            this.panel12.Visible = false;
            // 
            // mdListViewDisabled
            // 
            this.mdListViewDisabled.Image = global::KozaDisk.Properties.Resources.clock;
            this.mdListViewDisabled.Location = new System.Drawing.Point(48, 11);
            this.mdListViewDisabled.Name = "mdListViewDisabled";
            this.mdListViewDisabled.Size = new System.Drawing.Size(19, 20);
            this.mdListViewDisabled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mdListViewDisabled.TabIndex = 11;
            this.mdListViewDisabled.TabStop = false;
            this.mdListViewDisabled.Visible = false;
            this.mdListViewDisabled.Click += new System.EventHandler(this.mdListViewDisabled_Click);
            this.mdListViewDisabled.MouseHover += new System.EventHandler(this.mdListViewDisabled_MouseHover);
            // 
            // mdListViewEnabled
            // 
            this.mdListViewEnabled.Image = global::KozaDisk.Properties.Resources.clock1;
            this.mdListViewEnabled.Location = new System.Drawing.Point(46, 8);
            this.mdListViewEnabled.Name = "mdListViewEnabled";
            this.mdListViewEnabled.Size = new System.Drawing.Size(25, 25);
            this.mdListViewEnabled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mdListViewEnabled.TabIndex = 10;
            this.mdListViewEnabled.TabStop = false;
            this.mdListViewEnabled.Visible = false;
            this.mdListViewEnabled.MouseHover += new System.EventHandler(this.mdListViewDisabled_MouseHover);
            // 
            // mdBlockViewEnabled
            // 
            this.mdBlockViewEnabled.Image = global::KozaDisk.Properties.Resources.block;
            this.mdBlockViewEnabled.Location = new System.Drawing.Point(15, 9);
            this.mdBlockViewEnabled.Name = "mdBlockViewEnabled";
            this.mdBlockViewEnabled.Size = new System.Drawing.Size(25, 25);
            this.mdBlockViewEnabled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mdBlockViewEnabled.TabIndex = 9;
            this.mdBlockViewEnabled.TabStop = false;
            this.mdBlockViewEnabled.Visible = false;
            this.mdBlockViewEnabled.MouseHover += new System.EventHandler(this.mdBlockViewEnabled_MouseHover);
            // 
            // mdBlockViewDisabled
            // 
            this.mdBlockViewDisabled.Image = global::KozaDisk.Properties.Resources.block2;
            this.mdBlockViewDisabled.Location = new System.Drawing.Point(15, 8);
            this.mdBlockViewDisabled.Name = "mdBlockViewDisabled";
            this.mdBlockViewDisabled.Size = new System.Drawing.Size(25, 25);
            this.mdBlockViewDisabled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mdBlockViewDisabled.TabIndex = 8;
            this.mdBlockViewDisabled.TabStop = false;
            this.mdBlockViewDisabled.Visible = false;
            this.mdBlockViewDisabled.Click += new System.EventHandler(this.mdBlockViewDisabled_Click);
            this.mdBlockViewDisabled.MouseHover += new System.EventHandler(this.mdBlockViewEnabled_MouseHover);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.BlockViewImg);
            this.panel11.Controls.Add(this.ListViewBtn);
            this.panel11.Controls.Add(this.BlockViewBtn);
            this.panel11.Controls.Add(this.ListViewImg);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(939, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(75, 48);
            this.panel11.TabIndex = 3;
            // 
            // BlockViewImg
            // 
            this.BlockViewImg.Image = global::KozaDisk.Properties.Resources.menu_focus;
            this.BlockViewImg.Location = new System.Drawing.Point(9, 11);
            this.BlockViewImg.Name = "BlockViewImg";
            this.BlockViewImg.Size = new System.Drawing.Size(19, 20);
            this.BlockViewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlockViewImg.TabIndex = 6;
            this.BlockViewImg.TabStop = false;
            this.BlockViewImg.Visible = false;
            this.BlockViewImg.MouseHover += new System.EventHandler(this.BlockViewImg_MouseHover);
            // 
            // ListViewBtn
            // 
            this.ListViewBtn.Image = global::KozaDisk.Properties.Resources.Listing;
            this.ListViewBtn.Location = new System.Drawing.Point(36, 11);
            this.ListViewBtn.Name = "ListViewBtn";
            this.ListViewBtn.Size = new System.Drawing.Size(19, 20);
            this.ListViewBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ListViewBtn.TabIndex = 5;
            this.ListViewBtn.TabStop = false;
            this.ListViewBtn.Visible = false;
            this.ListViewBtn.Click += new System.EventHandler(this.ListViewBtn_Click);
            this.ListViewBtn.MouseHover += new System.EventHandler(this.ListViewBtn_MouseHover);
            // 
            // BlockViewBtn
            // 
            this.BlockViewBtn.Image = global::KozaDisk.Properties.Resources.menu;
            this.BlockViewBtn.Location = new System.Drawing.Point(9, 11);
            this.BlockViewBtn.Name = "BlockViewBtn";
            this.BlockViewBtn.Size = new System.Drawing.Size(19, 20);
            this.BlockViewBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlockViewBtn.TabIndex = 4;
            this.BlockViewBtn.TabStop = false;
            this.BlockViewBtn.Click += new System.EventHandler(this.BlockViewBtn_Click);
            this.BlockViewBtn.MouseHover += new System.EventHandler(this.BlockViewImg_MouseHover);
            // 
            // ListViewImg
            // 
            this.ListViewImg.Image = global::KozaDisk.Properties.Resources.Listing_focus;
            this.ListViewImg.Location = new System.Drawing.Point(35, 11);
            this.ListViewImg.Name = "ListViewImg";
            this.ListViewImg.Size = new System.Drawing.Size(19, 20);
            this.ListViewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ListViewImg.TabIndex = 3;
            this.ListViewImg.TabStop = false;
            this.ListViewImg.MouseHover += new System.EventHandler(this.ListViewBtn_MouseHover);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.NaviBrowser);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(924, 48);
            this.panel7.TabIndex = 0;
            // 
            // NaviBrowser
            // 
            this.NaviBrowser.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.NaviBrowser.AllowWebBrowserDrop = false;
            this.NaviBrowser.CausesValidation = false;
            this.NaviBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NaviBrowser.IsWebBrowserContextMenuEnabled = false;
            this.NaviBrowser.Location = new System.Drawing.Point(0, 0);
            this.NaviBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.NaviBrowser.Name = "NaviBrowser";
            this.NaviBrowser.ScrollBarsEnabled = false;
            this.NaviBrowser.Size = new System.Drawing.Size(924, 48);
            this.NaviBrowser.TabIndex = 1;
            this.NaviBrowser.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.Tabs);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 139);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1014, 472);
            this.panel8.TabIndex = 2;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.TreeTab);
            this.Tabs.Controls.Add(this.ListTab);
            this.Tabs.Controls.Add(this.MyDocsBlockTab);
            this.Tabs.Controls.Add(this.MyDocsListTab);
            this.Tabs.Controls.Add(this.searchTab);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1014, 472);
            this.Tabs.TabIndex = 3;
            // 
            // TreeTab
            // 
            this.TreeTab.Controls.Add(this.panel10);
            this.TreeTab.Controls.Add(this.panel9);
            this.TreeTab.Location = new System.Drawing.Point(4, 27);
            this.TreeTab.Name = "TreeTab";
            this.TreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.TreeTab.Size = new System.Drawing.Size(1006, 441);
            this.TreeTab.TabIndex = 0;
            this.TreeTab.Text = "TreeTab";
            this.TreeTab.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.FilesBrowser);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(376, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(627, 435);
            this.panel10.TabIndex = 1;
            // 
            // FilesBrowser
            // 
            this.FilesBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesBrowser.Location = new System.Drawing.Point(0, 0);
            this.FilesBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.FilesBrowser.Name = "FilesBrowser";
            this.FilesBrowser.ScriptErrorsSuppressed = true;
            this.FilesBrowser.Size = new System.Drawing.Size(627, 435);
            this.FilesBrowser.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.DiskTree);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(373, 435);
            this.panel9.TabIndex = 0;
            // 
            // DiskTree
            // 
            this.DiskTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiskTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.DiskTree.Font = new System.Drawing.Font("Arial", 12F);
            this.DiskTree.ImageIndex = 0;
            this.DiskTree.ImageList = this.imageList1;
            this.DiskTree.Indent = 30;
            this.DiskTree.Location = new System.Drawing.Point(0, 0);
            this.DiskTree.Margin = new System.Windows.Forms.Padding(5);
            this.DiskTree.Name = "DiskTree";
            this.DiskTree.SelectedImageIndex = 0;
            this.DiskTree.ShowNodeToolTips = true;
            this.DiskTree.ShowPlusMinus = false;
            this.DiskTree.ShowRootLines = false;
            this.DiskTree.Size = new System.Drawing.Size(373, 435);
            this.DiskTree.TabIndex = 0;
            this.DiskTree.TabStop = false;
            this.DiskTree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DiskTree_DrawNode);
            this.DiskTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.DiskTree_BeforeSelect);
            this.DiskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DiskTree_AfterSelect);
            this.DiskTree.Validating += new System.ComponentModel.CancelEventHandler(this.DiskTree_Validating);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "disk.png");
            this.imageList1.Images.SetKeyName(1, "disk-op.png");
            this.imageList1.Images.SetKeyName(2, "folder.png");
            this.imageList1.Images.SetKeyName(3, "folder-open.png");
            // 
            // ListTab
            // 
            this.ListTab.Controls.Add(this.DisksBlocksBrowser);
            this.ListTab.Location = new System.Drawing.Point(4, 27);
            this.ListTab.Name = "ListTab";
            this.ListTab.Padding = new System.Windows.Forms.Padding(3);
            this.ListTab.Size = new System.Drawing.Size(1006, 441);
            this.ListTab.TabIndex = 1;
            this.ListTab.Text = "ListTab";
            this.ListTab.UseVisualStyleBackColor = true;
            // 
            // DisksBlocksBrowser
            // 
            this.DisksBlocksBrowser.AllowNavigation = false;
            this.DisksBlocksBrowser.AllowWebBrowserDrop = false;
            this.DisksBlocksBrowser.CausesValidation = false;
            this.DisksBlocksBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisksBlocksBrowser.IsWebBrowserContextMenuEnabled = false;
            this.DisksBlocksBrowser.Location = new System.Drawing.Point(3, 3);
            this.DisksBlocksBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.DisksBlocksBrowser.Name = "DisksBlocksBrowser";
            this.DisksBlocksBrowser.ScriptErrorsSuppressed = true;
            this.DisksBlocksBrowser.Size = new System.Drawing.Size(1000, 435);
            this.DisksBlocksBrowser.TabIndex = 0;
            this.DisksBlocksBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // MyDocsBlockTab
            // 
            this.MyDocsBlockTab.Controls.Add(this.MyDocsBlockBrowser);
            this.MyDocsBlockTab.Location = new System.Drawing.Point(4, 27);
            this.MyDocsBlockTab.Name = "MyDocsBlockTab";
            this.MyDocsBlockTab.Padding = new System.Windows.Forms.Padding(3);
            this.MyDocsBlockTab.Size = new System.Drawing.Size(1006, 441);
            this.MyDocsBlockTab.TabIndex = 2;
            this.MyDocsBlockTab.Text = "MyDocsBlockTab";
            this.MyDocsBlockTab.UseVisualStyleBackColor = true;
            // 
            // MyDocsBlockBrowser
            // 
            this.MyDocsBlockBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyDocsBlockBrowser.IsWebBrowserContextMenuEnabled = false;
            this.MyDocsBlockBrowser.Location = new System.Drawing.Point(3, 3);
            this.MyDocsBlockBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.MyDocsBlockBrowser.Name = "MyDocsBlockBrowser";
            this.MyDocsBlockBrowser.ScriptErrorsSuppressed = true;
            this.MyDocsBlockBrowser.Size = new System.Drawing.Size(1000, 435);
            this.MyDocsBlockBrowser.TabIndex = 0;
            this.MyDocsBlockBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // MyDocsListTab
            // 
            this.MyDocsListTab.Controls.Add(this.MyDocsListBrowser);
            this.MyDocsListTab.Location = new System.Drawing.Point(4, 27);
            this.MyDocsListTab.Name = "MyDocsListTab";
            this.MyDocsListTab.Padding = new System.Windows.Forms.Padding(3);
            this.MyDocsListTab.Size = new System.Drawing.Size(1006, 441);
            this.MyDocsListTab.TabIndex = 3;
            this.MyDocsListTab.Text = "MyDocsListTab";
            this.MyDocsListTab.UseVisualStyleBackColor = true;
            // 
            // MyDocsListBrowser
            // 
            this.MyDocsListBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyDocsListBrowser.Location = new System.Drawing.Point(3, 3);
            this.MyDocsListBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.MyDocsListBrowser.Name = "MyDocsListBrowser";
            this.MyDocsListBrowser.ScriptErrorsSuppressed = true;
            this.MyDocsListBrowser.Size = new System.Drawing.Size(1000, 435);
            this.MyDocsListBrowser.TabIndex = 0;
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.SearchBrowser);
            this.searchTab.Location = new System.Drawing.Point(4, 27);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1006, 441);
            this.searchTab.TabIndex = 4;
            this.searchTab.Text = "searchTab";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // SearchBrowser
            // 
            this.SearchBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBrowser.Location = new System.Drawing.Point(3, 3);
            this.SearchBrowser.MinimumSize = new System.Drawing.Size(22, 24);
            this.SearchBrowser.Name = "SearchBrowser";
            this.SearchBrowser.ScriptErrorsSuppressed = true;
            this.SearchBrowser.Size = new System.Drawing.Size(1000, 435);
            this.SearchBrowser.TabIndex = 0;
            // 
            // TemplatesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 611);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "TemplatesList";
            this.Text = "КОЗА-ДИСК";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TemplatesList_FormClosed);
            this.Load += new System.EventHandler(this.TemplatesList_Load);
            this.Resize += new System.EventHandler(this.TemplatesList_Resize);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mdListViewDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdListViewEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBlockViewEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdBlockViewDisabled)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlockViewImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlockViewBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewImg)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.TreeTab.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ListTab.ResumeLayout(false);
            this.MyDocsBlockTab.ResumeLayout(false);
            this.MyDocsListTab.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AutoFillBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private TablessControl Tabs;
        private System.Windows.Forms.TabPage TreeTab;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TabPage ListTab;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.WebBrowser FilesBrowser;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.PictureBox BlockViewBtn;
        private System.Windows.Forms.PictureBox ListViewImg;
        private System.Windows.Forms.PictureBox ListViewBtn;
        private System.Windows.Forms.PictureBox BlockViewImg;
        private System.Windows.Forms.TabPage MyDocsBlockTab;
        private System.Windows.Forms.WebBrowser MyDocsBlockBrowser;
        private System.Windows.Forms.TabPage MyDocsListTab;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.PictureBox mdBlockViewDisabled;
        private System.Windows.Forms.PictureBox mdBlockViewEnabled;
        private System.Windows.Forms.PictureBox mdListViewEnabled;
        private System.Windows.Forms.PictureBox mdListViewDisabled;
        private System.Windows.Forms.WebBrowser MyDocsListBrowser;
        private System.Windows.Forms.WebBrowser SearchBrowser;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.WebBrowser DisksBlocksBrowser;
        public System.Windows.Forms.WebBrowser NaviBrowser;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox SearchBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView DiskTree;
    }
}