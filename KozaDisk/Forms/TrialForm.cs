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
    public partial class TrialForm : Form
    {
        /// <summary>
        /// Trial form
        /// </summary>
        /// <param name="days">Оставшиеся дни работы диска</param>
        public TrialForm(string days)
        {
            InitializeComponent();
            this.label1.Text = $"Залишилось {days} днів";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
