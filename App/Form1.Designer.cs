namespace App
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
            this.loadTmplBtn = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.loadXmlUserBtn = new System.Windows.Forms.Button();
            this.openTmplBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadXmlTmplBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadTmplBtn
            // 
            this.loadTmplBtn.Location = new System.Drawing.Point(12, 12);
            this.loadTmplBtn.Name = "loadTmplBtn";
            this.loadTmplBtn.Size = new System.Drawing.Size(167, 23);
            this.loadTmplBtn.TabIndex = 7;
            this.loadTmplBtn.Text = "Загрузить шаблон";
            this.loadTmplBtn.UseVisualStyleBackColor = true;
            this.loadTmplBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // openDialog
            // 
            this.openDialog.Filter = "MS Word .docx|*.docx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "XML загружен";
            this.label3.Visible = false;
            // 
            // loadXmlUserBtn
            // 
            this.loadXmlUserBtn.Location = new System.Drawing.Point(12, 71);
            this.loadXmlUserBtn.Name = "loadXmlUserBtn";
            this.loadXmlUserBtn.Size = new System.Drawing.Size(167, 23);
            this.loadXmlUserBtn.TabIndex = 12;
            this.loadXmlUserBtn.Text = "Загрузить XML юзера";
            this.loadXmlUserBtn.UseVisualStyleBackColor = true;
            this.loadXmlUserBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // openTmplBtn
            // 
            this.openTmplBtn.Location = new System.Drawing.Point(12, 115);
            this.openTmplBtn.Name = "openTmplBtn";
            this.openTmplBtn.Size = new System.Drawing.Size(378, 23);
            this.openTmplBtn.TabIndex = 11;
            this.openTmplBtn.Text = "Открыть окно редактирования шаблона";
            this.openTmplBtn.UseVisualStyleBackColor = true;
            this.openTmplBtn.Click += new System.EventHandler(this.openTmplBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "XML загружен";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Шаблон загружен";
            this.label1.Visible = false;
            // 
            // loadXmlTmplBtn
            // 
            this.loadXmlTmplBtn.Location = new System.Drawing.Point(12, 42);
            this.loadXmlTmplBtn.Name = "loadXmlTmplBtn";
            this.loadXmlTmplBtn.Size = new System.Drawing.Size(167, 23);
            this.loadXmlTmplBtn.TabIndex = 8;
            this.loadXmlTmplBtn.Text = "Загрузить XML шаблона";
            this.loadXmlTmplBtn.UseVisualStyleBackColor = true;
            this.loadXmlTmplBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 149);
            this.Controls.Add(this.loadTmplBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loadXmlUserBtn);
            this.Controls.Add(this.openTmplBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadXmlTmplBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadTmplBtn;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadXmlUserBtn;
        private System.Windows.Forms.Button openTmplBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadXmlTmplBtn;
    }
}

