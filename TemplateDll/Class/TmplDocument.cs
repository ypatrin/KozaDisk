using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace templates
{
    class TmplDocument
    {
        private static TmplDocument instance;
        private RichEditControl Doc = new RichEditControl();
        private WebBrowser browser;
        private Markers markers = new Markers();
        private string templateName;

        private TmplDocument()
        { }

        public static TmplDocument getInstance()
        {
            if (instance == null)
                instance = new TmplDocument();
            return instance;
        }

        public void setDocument(string documentPath)
        {
            this.Doc.LoadDocument(documentPath);
            this.templateName = Path.GetFileName(documentPath);
        }

        public void setBrowser(WebBrowser browser)
        {
            this.browser = browser;
        }

        public Document getDocument()
        {
            return Doc.Document;
        }

        public void saveToHtml(string htmlFileName)
        {
            Doc.SaveDocument(htmlFileName, DocumentFormat.Html);
        }

        public void processMarkers()
        {
            this.processTextMarkers();
        }

        public void save()
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = this.templateName;
            saveDialog.Filter = "MS Word Document|*.docx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                this.Doc.Document.SaveDocument(saveDialog.FileName, DocumentFormat.OpenXml);
            }
        }

        private void processTextMarkers()
        {
            // get all input element
            var elements = this.browser.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in elements)
            {
                // process only text elements
                if (input.GetAttribute("type") == "text")
                {
                    var name = input.GetAttribute("name");
                    var value = input.GetAttribute("value");

                    this.markers.replaceInDocument(this.Doc.Document, name, value);
                }
            }
        }
    }
}
