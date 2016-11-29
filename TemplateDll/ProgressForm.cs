using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace templates
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void setProgress(int progressVal)
        {
            progressBar1.Value = progressVal;
        }

        public void setMax(int val)
        {
            progressBar1.Maximum = val;
        }

        public void setText(string Text)
        {
            labelControl1.Text = Text;
        }
    }
}
