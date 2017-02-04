namespace KozaDisk.Forms
{
    partial class QuestionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.YesBtn = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KozaDisk.Properties.Resources.ques_del;
            this.pictureBox1.Location = new System.Drawing.Point(140, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // YesBtn
            // 
            this.YesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(156)))));
            this.YesBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.YesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.YesBtn.ForeColor = System.Drawing.Color.White;
            this.YesBtn.Location = new System.Drawing.Point(46, 144);
            this.YesBtn.Name = "YesBtn";
            this.YesBtn.Size = new System.Drawing.Size(105, 35);
            this.YesBtn.TabIndex = 7;
            this.YesBtn.Text = "Так";
            this.YesBtn.UseVisualStyleBackColor = false;
            this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Arial", 18F);
            this.MessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MessageLabel.Location = new System.Drawing.Point(40, 90);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(243, 27);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "Видалити документ?";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NoBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.YesBtn);
            this.panel1.Controls.Add(this.MessageLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 206);
            this.panel1.TabIndex = 10;
            // 
            // NoBtn
            // 
            this.NoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(156)))));
            this.NoBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.NoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoBtn.Font = new System.Drawing.Font("Arial", 11F);
            this.NoBtn.ForeColor = System.Drawing.Color.White;
            this.NoBtn.Location = new System.Drawing.Point(169, 144);
            this.NoBtn.Name = "NoBtn";
            this.NoBtn.Size = new System.Drawing.Size(105, 35);
            this.NoBtn.TabIndex = 8;
            this.NoBtn.Text = "Ні";
            this.NoBtn.UseVisualStyleBackColor = false;
            this.NoBtn.Click += new System.EventHandler(this.NoBtn_Click);
            // 
            // QuestionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 206);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "КОЗА-ДИСК";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button YesBtn;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NoBtn;
    }
}