﻿using System;
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
        private string templateName, dbName;
        private int docId;
        private int myDocId = 0;

        private TmplDocument tmplDocument = TmplDocument.getInstance();
        private Markers markers = new Markers();

        private Progress progress = Progress.getInstance();

        public void setTemplate(String TemplateFilePath, String XmlFilePath, string TemplateName)
        {
            this.templateFilePath = TemplateFilePath;
            this.templateXmlFilePath = XmlFilePath;
            this.templateName = TemplateName;
        }

        public void setUserXmlFile(String userXmlFilePath)
        {
            this.userXmlFilePath = userXmlFilePath;
        }

        public void setDbName(string DbName)
        {
            this.dbName = DbName;
        }

        public void setDocId(int docId)
        {
            this.docId = docId;
        }

        public void setMyDocId(int docId)
        {
            this.myDocId = docId;
        }

        public void open()
        {
            openProc();
        }

        public void open(string html)
        {
            openProc(html);
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

        void openProc()
        {
            this.progress.Open();
            TemplateForm template = new TemplateForm();
            template.setTemplateName(this.templateName);

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
            string userName = userDataXml.SelectSingleNode("/User/UserName").InnerText.ToString();
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

            foreach (XmlNode marker in markers)
            {
                html = this.markers.processMarkers(html, marker, markers);
            }      

            html = html.Replace("&rnbsp;", " ");
            html = html.Replace("&nbsp;", " ");
            html = html.Replace("'>'>", "'>");

            this.progress.setCurrent(10);

            template.setUserName(userName);
            template.setDbName(this.dbName);
            template.setDocId(this.docId);

            //open form
            template.loadHTML(html);
            this.progress.setCurrent(11);
            //template.Show();
            this.progress.setCurrent(12);
            this.progress.Close();

            template.ShowDialog();
        }

        public bool isClosed()
        {
            if (this.isClosed())
                return true;
            else
                return false;
        }

        void openProc(string documentHtmlValues)
        {
            this.progress.Open();
            TemplateForm template = new TemplateForm();
            template.setTemplateName(this.templateName);

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
            string userName = userDataXml.SelectSingleNode("/User/UserName").InnerText.ToString();
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

            foreach (XmlNode marker in markers)
            {
                html = this.markers.processMarkers(html, marker, markers);
            }

            html = html.Replace("&rnbsp;", " ");
            html = html.Replace("&nbsp;", " ");
            html = html.Replace("'>'>", "'>");

            this.progress.setCurrent(10);

            template.setUserName(userName);
            template.setDbName(this.dbName);
            template.setDocId(this.docId);
            template.setMyDocId(this.myDocId);

            //open form
            template.loadHTML(html);
            this.progress.setCurrent(11);

            //process html values
            template.loadHtmlElementsValue(documentHtmlValues);
          
            //template.Show();
            this.progress.setCurrent(12);
            this.progress.Close();

            template.ShowDialog();
        }

        ~Templates()
        {
            
        }
    }
}
