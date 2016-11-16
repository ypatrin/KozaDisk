using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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

            html = html.Replace(@"margin:0pt 0pt 0pt 50pt", @"margin:0pt 0pt 0pt 7pt");

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
                html = this.markers.processMarkers(html, marker, markers);
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
            
        }
    }
}
