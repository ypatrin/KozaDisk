using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KozaDisk.Forms
{
    public partial class HelpForm : Form
    {
        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;


        public HelpForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpForm_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void HelpForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void HelpForm_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void CloseBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "instruction.pdf";
            sfd.Filter = "PDF Файл|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                    File.Delete(sfd.FileName);

                File.Copy(Constant.ApplcationPath + "instruction.pdf", sfd.FileName);
                MessageBox.Show("Файл успішно збережений!", "Допомога", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */

            System.Diagnostics.Process.Start(Constant.ApplcationPath + "instruction.pdf");
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.richTextBox1.LoadFile(Constant.ApplcationPath + "manual.rtf");
        }
    }
}
