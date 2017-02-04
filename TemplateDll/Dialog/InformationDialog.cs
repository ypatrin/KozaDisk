using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace templates.Dialog
{
    public partial class InformationDialog : Form
    {
        public InformationDialog()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
