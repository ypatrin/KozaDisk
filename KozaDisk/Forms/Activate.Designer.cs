namespace KozaDisk.Forms
{
    partial class Activate
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ActivateButton = new System.Windows.Forms.Button();
            this.ActivateCodeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DiskNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Активація диску через інтернет";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ActivateButton);
            this.panel1.Controls.Add(this.ActivateCodeBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DiskNameLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(5, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 323);
            this.panel1.TabIndex = 1;
            // 
            // ActivateButton
            // 
            this.ActivateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(156)))));
            this.ActivateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ActivateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivateButton.ForeColor = System.Drawing.Color.White;
            this.ActivateButton.Location = new System.Drawing.Point(247, 268);
            this.ActivateButton.Name = "ActivateButton";
            this.ActivateButton.Size = new System.Drawing.Size(120, 35);
            this.ActivateButton.TabIndex = 5;
            this.ActivateButton.Text = "Активувати";
            this.ActivateButton.UseVisualStyleBackColor = false;
            this.ActivateButton.Click += new System.EventHandler(this.ActivateButton_Click);
            // 
            // ActivateCodeBox
            // 
            this.ActivateCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ActivateCodeBox.Font = new System.Drawing.Font("Myriad Pro", 12F);
            this.ActivateCodeBox.Location = new System.Drawing.Point(12, 221);
            this.ActivateCodeBox.Name = "ActivateCodeBox";
            this.ActivateCodeBox.Size = new System.Drawing.Size(355, 27);
            this.ActivateCodeBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Введіть код активації";
            // 
            // DiskNameLabel
            // 
            this.DiskNameLabel.AutoSize = true;
            this.DiskNameLabel.Font = new System.Drawing.Font("Myriad Pro", 11F);
            this.DiskNameLabel.Location = new System.Drawing.Point(9, 158);
            this.DiskNameLabel.Name = "DiskNameLabel";
            this.DiskNameLabel.Size = new System.Drawing.Size(48, 18);
            this.DiskNameLabel.TabIndex = 2;
            this.DiskNameLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myriad Pro Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Диск";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Myriad Pro", 11F);
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(12, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(355, 60);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Для активації диску введіть, будь ласка, код, який прийшов Вам разом з диском. Та" +
    "кож жи можете користуватися диском 14 днів в пробному режимі.";
            // 
            // Activate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(189)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(389, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Myriad Pro", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Activate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Активація диску";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ActivateButton;
        private System.Windows.Forms.TextBox ActivateCodeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DiskNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}