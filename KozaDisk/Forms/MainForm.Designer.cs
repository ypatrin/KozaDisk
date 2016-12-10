namespace KozaDisk
{
    partial class MainForm
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
            this.usersBox = new System.Windows.Forms.ComboBox();
            this.metroButton1 = new System.Windows.Forms.Button();
            this.CreateLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usersBox
            // 
            this.usersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usersBox.FormattingEnabled = true;
            this.usersBox.Location = new System.Drawing.Point(23, 63);
            this.usersBox.Name = "usersBox";
            this.usersBox.Size = new System.Drawing.Size(452, 21);
            this.usersBox.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(348, 160);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(127, 28);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Вхід";
            // 
            // CreateLink
            // 
            this.CreateLink.AutoSize = true;
            this.CreateLink.Location = new System.Drawing.Point(23, 90);
            this.CreateLink.Name = "CreateLink";
            this.CreateLink.Size = new System.Drawing.Size(158, 13);
            this.CreateLink.TabIndex = 2;
            this.CreateLink.TabStop = true;
            this.CreateLink.Text = "Створити нового користувача";
            this.CreateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Оберіть користувача";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateLink);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.usersBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оберіть користувача";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usersBox;
        private System.Windows.Forms.Button metroButton1;
        private System.Windows.Forms.LinkLabel CreateLink;
        private System.Windows.Forms.Label label1;
    }
}