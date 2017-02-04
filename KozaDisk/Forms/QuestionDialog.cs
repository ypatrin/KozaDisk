using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KozaDisk.Forms
{
    public partial class QuestionDialog : Form
    {
        public QuestionDialog(string message)
        {
            InitializeComponent();
            this.MessageLabel.Text = message;
        }

        public QuestionDialog()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
