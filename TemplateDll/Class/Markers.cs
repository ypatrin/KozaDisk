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

        public string processMarkers(string html, XmlNode MarkerNode, XmlNodeList AllMarkers)
        {
            string markerName = MarkerNode.Attributes["name"].Value;
            string markerType = MarkerNode.Attributes["type"].Value;
            string markerComment = "";

            if (MarkerNode.Attributes["comment"] != null)
            {
                markerComment = MarkerNode.Attributes["comment"].Value;
            }

            if (markerType == "text")
            {
                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(@"
                        <input type='text' name='{0}' id='{0}'>
                        <img class='comment' comment='{1}' src='{2}\icon\comments\question.png'/>
                    ", markerName, markerComment, Environment.CurrentDirectory)
                );
            }

            if (markerType == "date")
            {
                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(@"
                        <input type='text' class='date' name='{0}' id='{0}'>
                        <img class='comment' comment='{1}' src='{2}\icon\comments\question.png'/>
                    ", markerName, markerComment, Environment.CurrentDirectory)
                );
            }

            if (markerType == "checkbox")
            {
                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format("<input type='checkbox' name='{0}' id='{0}'>", markerName)
                );
            }

            if (markerType == "dynamic")
            {
                string val = "";
                string type = "";

                if (MarkerNode.Attributes["value"] != null)
                {
                    val = MarkerNode.Attributes["value"].Value.Replace(@"$$","");
                }

                //search value from another markers
                foreach (XmlNode marker in AllMarkers)
                {
                    if (marker.Attributes["name"] == null) continue;

                    if (val == marker.Attributes["name"].Value)
                    {
                        //set type
                        type = marker.Attributes["type"].Value;

                        if (type == "text" || type == "date")
                        {
                            val = "";
                        }

                        if (type == "static")
                        {
                            if (this.userDataXml[marker.Attributes["field"].Value].InnerText != null)
                            {
                                val = this.userDataXml[marker.Attributes["field"].Value].InnerText;
                            }
                            else
                            {
                                val = "";
                            }
                        }   
                    }
                }

                if (type == "text")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"
                            <input type='checkbox' checked='checked' name='{0}' id='dyn_{0}'/>
                            <img class='comment' comment='{1}' src='{2}\icon\comments\question.png'/>
                            <input type='text' name='{0}' id='{0}'>
                        ", 
                        markerName, markerComment, Environment.CurrentDirectory)
                    );
                }
                if (type == "date")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"<input type='checkbox' checked='checked' name='{0}' id='dyn_{0}'/><img class='comment' comment='На друк виводитимуться лише ті пункти, які позначено «галочкою». Якщо пункти виявилися зайвими, зніміть біля них «галочки»' src='{1}\icon\comments\question.png'/><input type='text' name='{0}' id='{0}' class='date'>", markerName, Environment.CurrentDirectory)
                    );
                }
                if (type == "static")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"<input type='checkbox' checked='checked' name='{0}' id='dyn_{0}'/><img class='comment' comment='На друк виводитимуться лише ті пункти, які позначено «галочкою». Якщо пункти виявилися зайвими, зніміть біля них «галочки»' src='{2}\icon\comments\question.png'/><input type='text' class='static' disabled='disabled' name='{0}' id='{0}' value='{1}'>", markerName, val, Environment.CurrentDirectory)
                    );
                }
                if (type == "")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"<input type='checkbox' checked='checked' name='{0}' id='dyn_{0}'/><img class='comment' comment='На друк виводитимуться лише ті пункти, які позначено «галочкою». Якщо пункти виявилися зайвими, зніміть біля них «галочки»' src='{2}\icon\comments\question.png'/>{1}<input type='text' style='display:none' disabled='disabled' name='{0}' id='{0}' value='{1}'>", markerName, val, Environment.CurrentDirectory)
                    );
                }

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
