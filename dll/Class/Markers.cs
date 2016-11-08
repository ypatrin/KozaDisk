using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; //for debug only
using System.Xml;

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
                html = html.Replace("$$" + markerName + "$$", "<input type='text' name='" + markerName + "' id='" + markerName + "'>");
            }

            if (markerType == "date")
            {
                html = html.Replace("$$" + markerName + "$$", "<input type='text' class=\"date\" name='" + markerName + "' id='" + markerName + "'>");
            }

            if (markerType == "static")
            {
                string val = "";

                if (this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText != null)
                {
                    val = this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText;
                }

                html = html.Replace("$$" + markerName + "$$", "<input type='text' class=\"static\" disabled=\"disabled\" name='" + markerName + "' id='" + markerName + "' value='"+val+"'>");
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
