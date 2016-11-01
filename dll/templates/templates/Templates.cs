using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace templates
{
    public class Templates
    {
        private string templateFile = "", xmlFile = "", htmlFile = "";
        private string tempPath = System.IO.Path.GetTempPath();
        private Markers markers = new Markers();
        private TmplDocument tmplDocument = TmplDocument.getInstance();

        public void setTemplateFile(String TemplateFile)
        {
            this.templateFile = TemplateFile;
        }

        public void setXMLFile(String XMLFile)
        {
            this.xmlFile = XMLFile;
        }

        public void open()
        {
            //prepare html file path
            htmlFile = this.tempPath + this.getRandomString(10) + ".html";

            //load document and save to html
            this.tmplDocument.setDocument(this.templateFile);
            this.tmplDocument.saveToHtml(htmlFile);

            //read html
            string html = System.IO.File.ReadAllText(htmlFile, Encoding.GetEncoding("windows-1251"));

            //destroy temp html file
            File.Delete(this.htmlFile);

            //read xml
            XmlDocument doc = new XmlDocument();
            doc.Load(this.xmlFile);
            XmlNodeList markers = doc.DocumentElement.SelectNodes("/markers/marker");

            foreach (XmlNode marker in markers)
            {
                string name = marker.Attributes["name"].Value;
                string type = marker.Attributes["type"].Value;

                html = this.markers.processMarkers(html, name, type);
            }

            //open form
            TemplateForm tempate = new TemplateForm();
            tempate.loadHTML(html);
            tempate.Show();
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
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        public void loadHTML(string html)
        {
            webBrowser1.DocumentText = html;
        }
    }
}
