using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraPrinting;

namespace templates
{
    public partial class PrintForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        RichEditControl richEditControl;

        public PrintForm(RichEditControl richEditControl)
        {
            InitializeComponent();

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = richEditControl;

            printingSystem1.Links.Add(link);
        }

        private void printPreviewBarItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
