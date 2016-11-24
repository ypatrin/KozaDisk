using DevExpress.Office.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace templates
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class TemplateForm : Form
    {
        PrintableComponentLink link;
        RichEditControl richEditControl;

        public TemplateForm()
        {
            InitializeComponent();

            webBrowser1.AllowWebBrowserDrop = false;
            //webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
            //webBrowser1.ScriptErrorsSuppressed = true;

            webBrowser2.AllowWebBrowserDrop = false;
            webBrowser2.WebBrowserShortcutsEnabled = false;
            webBrowser2.ObjectForScripting = this;
            webBrowser2.ScriptErrorsSuppressed = true;
            webBrowser2.IsWebBrowserContextMenuEnabled = false;
        }

        public void loadHTML(string html)
        {
            webBrowser1.Navigate("about:blank");
            webBrowser1.DocumentText = "0";
            webBrowser1.Document.OpenNew(true);
            webBrowser1.Document.Write(html);
            webBrowser1.Refresh();

            //Wait for document to finish loading
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(5);
            }

            this.runJs();
        }

        public void runJs()
        {
            webBrowser1.Document.InvokeScript("procCalendar");
        }

        public void injectModules(string htmlFile)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.Load(htmlFile);
            HtmlNode head = htmlDocument.DocumentNode.SelectSingleNode("/html/head");

            // inject calendar module
            HtmlNode calendarJs = htmlDocument.CreateElement("script");
            calendarJs.SetAttributeValue("type", "text/javascript");
            calendarJs.SetAttributeValue("src", Environment.CurrentDirectory + @"\js\lib\calendar\dhtmlxcalendar.js");
            head.AppendChild(calendarJs);

            HtmlNode calendarCss = htmlDocument.CreateElement("link");
            calendarCss.SetAttributeValue("rel", "stylesheet");
            calendarCss.SetAttributeValue("href", Environment.CurrentDirectory + @"\js\lib\calendar\dhtmlxcalendar.css");
            head.AppendChild(calendarCss);

            //inject jquery
            HtmlNode jqueryJs = htmlDocument.CreateElement("script");
            jqueryJs.SetAttributeValue("type", "text/javascript");
            jqueryJs.SetAttributeValue("src", Environment.CurrentDirectory + @"\js\jquery.js");
            head.AppendChild(jqueryJs);

            //inject page js
            HtmlNode pageJs = htmlDocument.CreateElement("script");
            pageJs.SetAttributeValue("type", "text/javascript");
            pageJs.SetAttributeValue("src", Environment.CurrentDirectory + @"\js\page.js");
            head.AppendChild(pageJs);

            //inject page css
            HtmlNode pageCss = htmlDocument.CreateElement("link");
            pageCss.SetAttributeValue("rel", "stylesheet");
            pageCss.SetAttributeValue("href", Environment.CurrentDirectory + @"\css\page.css");
            head.AppendChild(pageCss);

            htmlDocument.Save(htmlFile);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            TmplDocument tmplDocument = TmplDocument.getInstance();
            Markers markers = new Markers();

            // set browser
            tmplDocument.setBrowser(webBrowser1);
            tmplDocument.processMarkers();
            tmplDocument.save();
        }

        public void showComment(String comment)
        {
            string html = string.Format("<html><head><script type=\"text/javascript\" src=\"{0}\"></script><script type=\"text/javascript\" src=\"{1}\"></script></head><body>{2}</body></html>",
                Environment.CurrentDirectory + @"\js\jquery.js", Environment.CurrentDirectory + @"\js\comment.js", comment
            );

            webBrowser2.Navigate("about:blank");
            webBrowser2.DocumentText = "0";
            webBrowser2.Document.OpenNew(true);
            webBrowser2.Document.Write(html);
            webBrowser2.Refresh();
        }

        public void openUrl(String url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TmplDocument tmplDocument = TmplDocument.getInstance();
            Markers markers = new Markers();

            // set browser
            tmplDocument.setBrowser(webBrowser1);
            // process markers
            tmplDocument.processMarkers();
            // get richedit control
            this.richEditControl = tmplDocument.getRichEditControl();

            //printing
            this.richEditControl.ShowPrintDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
                  
            TmplDocument tmplDocument = TmplDocument.getInstance();
            Markers markers = new Markers();

            // set browser
            tmplDocument.setBrowser(webBrowser1);
            // process markers
            tmplDocument.processMarkers();
            // get richedit control
            this.richEditControl = tmplDocument.getRichEditControl();
            

            PrintForm printForm = new PrintForm(this.richEditControl);
            printForm.Show();

            /*
            //open preview window
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = richEditControl;
            link.ShowRibbonPreviewDialog(richEditControl.LookAndFeel);
            */
        }
    }
}
