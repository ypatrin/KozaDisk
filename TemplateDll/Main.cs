using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Windows.Threading;
using System.Windows.Forms;

namespace templates
{
    public class Templates
    {
        private string templateFilePath = "", templateXmlFilePath = "", htmlFilePath = "", userXmlFilePath = "";
        private string tempPath = System.IO.Path.GetTempPath();

        private TmplDocument tmplDocument = TmplDocument.getInstance();
        private Markers markers = new Markers();

        private Progress progress = new Progress();

        /*
        delegate void StatusDelegate();
        StatusDelegate StatusFormDelegate = new StatusDelegate(UpdateProgressStatus);
        StatusDelegate CloseFormDelegate = new StatusDelegate(CloseProgressForm);
        StatusDelegate SetMaxFormDelegate = new StatusDelegate(SetMaxProgressStatus);

        Thread threadProgressForm;
        Thread workThread;

        static volatile int progressStatus = 0;
        static private ProgressForm progressForm = new ProgressForm(); 
        */

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
            //threadProgressForm = new Thread(OpenProgressForm);
            //threadProgressForm.Start();

            openProc();
        }

        /*
        public void OpenProgressForm()
        {
            progressForm.ShowDialog();
        }

        static void CloseProgressForm()
        {
            progressForm.Close();
        }

        static void UpdateProgressStatus()
        {
            progressForm.setProgress(progressStatus);
        }

        static void SetMaxProgressStatus()
        {
            progressForm.setMax(12);
        }
        */

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

        void openProc()
        {
            this.progress.Open();
            TemplateForm template = new TemplateForm();

            this.progress.setMax(12);
            this.progress.setCurrent(0);
            
            //prepare html file path
            this.htmlFilePath = this.tempPath + this.getRandomString(10) + ".html";
            this.progress.setCurrent(1);

            //load document and save to html
            this.tmplDocument.setDocument(this.templateFilePath);
            this.progress.setCurrent(2);
            this.tmplDocument.saveToHtml(this.htmlFilePath);
            this.progress.setCurrent(3);

            //inject JS
            template.injectModules(this.htmlFilePath);
            this.progress.setCurrent(4);

            //read html
            string html = System.IO.File.ReadAllText(this.htmlFilePath, Encoding.GetEncoding("windows-1251"));
            html = html.Replace(@"margin:0pt 0pt 0pt 50pt", @"margin:0pt 0pt 0pt 7pt");
            this.progress.setCurrent(5);

            //destroy temp html file
            File.Delete(this.htmlFilePath);
            this.progress.setCurrent(6);

            //read user xml
            XmlDocument userXml = new XmlDocument();
            userXml.Load(this.userXmlFilePath);
            XmlElement userDataXml = userXml.DocumentElement;
            this.progress.setCurrent(7);

            this.markers.setUserData(userDataXml);
            this.progress.setCurrent(8);

            //read template xml
            XmlDocument doc = new XmlDocument();
            doc.Load(this.templateXmlFilePath);
            XmlNodeList markers = doc.DocumentElement.SelectNodes("/markers/marker");
            this.progress.setCurrent(9);

            foreach (XmlNode marker in markers)
            {
                html = this.markers.processMarkers(html, marker, markers);
            }
            this.progress.setCurrent(10);

            //open form
            template.loadHTML(html);
            this.progress.setCurrent(11);
            template.Show();
            this.progress.setCurrent(12);
            this.progress.Close();
        }

        ~Templates()
        {
            
        }
    }
}
