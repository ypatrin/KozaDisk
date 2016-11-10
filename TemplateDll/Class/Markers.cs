using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DevExpress.XtraRichEdit.API.Native;

namespace templates
{
    class Markers
    {
        private XmlElement userDataXml;

        public void setUserData(XmlElement userDataXml)
        {
            this.userDataXml = userDataXml;
        }

        public string processMarkers(string html, XmlNode MarkerNode)
        {
            string markerName = MarkerNode.Attributes["name"].Value;
            string markerType = MarkerNode.Attributes["type"].Value;

            if (markerType == "text")
            {
                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format("<input type='text' name='{0}' id='{0}'>", markerName)
                );
            }

            if (markerType == "date")
            {
                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format("<input type='text' class='date' name='{0}' id='{0}'>", markerName)
                );
            }

            if (markerType == "checkbox")
            {
                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format("<input type='checkbox' name='{0}' id='{0}'>", markerName)
                );
            }

            if (markerType == "no_marker")
            {
                string val = "";

                if (MarkerNode.Attributes["value"] != null)
                {
                    val = MarkerNode.Attributes["value"].Value;
                }

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format("<br/>{1}<input type='text' name='{0}' id='{0}' style='display:none' val='{1}'>", markerName, val)
                );
            }

            if (markerType == "static")
            {
                string val = "";

                if (this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText != null)
                {
                    val = this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText;
                }

                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format("<input type='text' class='static' disabled='disabled' name='{0}' id='{0}' value='{1}'>", markerName, val)
                );
            }

            return html;
        }

        public Document replaceInDocument(Document document, string from, string to)
        {
            document.BeginUpdate();
            try
            {
                DocumentRange[] ranges = document.FindAll("$$" + from + "$$", SearchOptions.None);

                foreach (DocumentRange range in ranges)
                {
                    document.Replace(range, to);
                }
            }
            finally
            {
                document.EndUpdate();
            }
            return document;
        }
    }
}
