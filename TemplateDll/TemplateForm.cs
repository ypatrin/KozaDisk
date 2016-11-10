using HtmlAgilityPack;
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
    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
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

            //inject page js
            HtmlNode pageJs = htmlDocument.CreateElement("script");
            pageJs.SetAttributeValue("type", "text/javascript");
            pageJs.SetAttributeValue("src", Environment.CurrentDirectory + @"\js\page.js");
            head.AppendChild(pageJs);

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
    }
}
