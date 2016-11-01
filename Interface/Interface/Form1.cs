using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using templates;

namespace Interface
{
    public partial class Form1 : Form
    {
        protected string templateFileName = "", xmlFileName = "";
        private string templateFilter = "MS Word|*.docx|All files|*.*";
        private string xmlFilter = "XML|*.xml|All files|*.*";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openDialog.Filter = xmlFilter;
            openDialog.FileName = "";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                xmlFileName = openDialog.FileName;
                label2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (xmlFileName == "" || templateFileName == "")
            {
                MessageBox.Show("Выберите шаблон и XML файл описания маркеров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Templates template = new Templates();
                template.setTemplateFile(templateFileName);
                template.setXMLFile(xmlFileName);
                template.open();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openDialog.Filter = templateFilter;
            openDialog.FileName = "";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                templateFileName = openDialog.FileName;
                label1.Visible = true;
            }
        }
    }
}
