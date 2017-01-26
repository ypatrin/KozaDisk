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
    public partial class PopupOkForm : Form
    {
        public PopupOkForm(String Message)
        {
            InitializeComponent();
            this.label1.Text = Message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
