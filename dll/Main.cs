using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;

namespace templates
{
    public class Templates
    {
        private string templateFilePath = "", templateXmlFilePath = "", htmlFilePath = "", userXmlFilePath = "";

        private string tempPath = System.IO.Path.GetTempPath();
        private TmplDocument tmplDocument = TmplDocument.getInstance();

        private TemplateForm template = new TemplateForm();
        private Markers markers = new Markers();

        public void setTemplate(String TemplateFilePath, String XmlFilePath)
        {
            this.templateFilePath = TemplateFilePath;
            this.templateXmlFilePath = XmlFilePath;
        }

        public void setUserXmlFile(String userXmlFilePath)
        {
            this.userXmlFilePath = userXmlFilePath;
        }

        public void open()
        {
            //prepare html file path
            this.htmlFilePath = this.tempPath + this.getRandomString(10) + ".html";

            //load document and save to html
            this.tmplDocument.setDocument(this.templateFilePath);
            this.tmplDocument.saveToHtml(this.htmlFilePath);

            //inject JS
            template.injectModules(this.htmlFilePath);

            //read html
            string html = System.IO.File.ReadAllText(this.htmlFilePath, Encoding.GetEncoding("windows-1251"));

            //destroy temp html file
            File.Delete(this.htmlFilePath);

            //read user xml
            XmlDocument userXml = new XmlDocument();
            userXml.Load(this.userXmlFilePath);
            XmlElement userDataXml = userXml.DocumentElement;

            this.markers.setUserData(userDataXml);

            //read template xml
            XmlDocument doc = new XmlDocument();
            doc.Load(this.templateXmlFilePath);
            XmlNodeList markers = doc.DocumentElement.SelectNodes("/markers/marker");

            foreach (XmlNode marker in markers)
            {
                html = this.markers.processMarkers(html, marker);
            }

            //open form
            template.loadHTML(html);
            template.Show();
        }

        private string getRandomString(int length)
        {
            string ch = "qwertyuiopasdfghjklzxcvbnm0123456789";
            Random rndGen = new Random();

            char[] letters = ch.ToCharArray();
            string s = "";
            for (int i = 0; i < length; i++)
            {
                s += letters[rndGen.Next(letters.Length)].ToString();
            }
            return s;
        }

        ~Templates()
        {
            ;
        }
    }

    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
            webBrowser1.IsWebBrowserContextMenuEnabled = true; // WebBrowser Menu
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
    }
}
