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
    public partial class PrintForm : DevExpress.XtraEditors.XtraForm
    {
        RichEditControl richEditControl = null;
        PrintableComponentLink link = null;

        public PrintForm(RichEditControl richEditControl)
        {
            InitializeComponent();
            documentViewer1.PrintingSystem.AddCommandHandler(new MyCommandHandler());

            printingSystem1.ClearContent();
            link = new PrintableComponentLink(new PrintingSystem());
            link.Component = richEditControl;
            printingSystem1.Links.Add(link);
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            

            //documentViewer1.Update();
            //documentViewer1.Refresh();
            //documentViewer1.InitiateDocumentCreation();
        }

        private void PrintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            link = null;
            printingSystem1.Links.Clear();
            printingSystem1.ClearContent();

            this.richEditControl = null;
        }
    }
}
