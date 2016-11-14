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

            if (markerType == "comment")
            {
                string val = "";

                if (MarkerNode.Attributes["value"] != null)
                {
                    val = MarkerNode.Attributes["value"].Value;
                }

                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(@"
                        <img class='comment' comment='{1}' src='{2}\icon\comments\question.png'/>
                        <input type='text' name='{0}' id='{0}' val='' style='display:none'>
                    ", markerName, val, Environment.CurrentDirectory)
                );
            }

            if (markerType == "text")
            {
                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_text;

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
                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_date;

                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(@"
                        <input type='text' class='date' name='{0}' id='{0}'>
                        <img class='comment' comment='{1}' src='{2}\icon\comments\question.png'/>
                    ", markerName, markerComment, Environment.CurrentDirectory)
                );
            }

            if (markerType == "formula")
            {
                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_formula;

                string val = "";

                if (MarkerNode.Attributes["value"] != null)
                {
                    val = MarkerNode.Attributes["value"].Value;
                }

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format(@"
                        <input type='text' name='{1}' id='{1}' text_type='formula' formula='{3}' disabled='disabled'>
                        <img class='comment' comment='{2}' src='{0}\icon\comments\question.png'/>
                    ", Environment.CurrentDirectory, markerName, markerComment, val)
                );
            }

            if (markerType == "dynamic")
            {
                string val = "";
                string type = "";

                string markerCommentDyn = Properties.Resources.comment_default_checkbox;

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

                        if (marker.Attributes["comment"] != null)
                        {
                            markerComment = marker.Attributes["comment"].Value;
                        }

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
                    if (markerComment == "")
                        markerComment = Properties.Resources.comment_default_text;

                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"
                            <input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>
                            <img class='comment' comment='{3}' src='{0}\icon\comments\question.png'/>
                            <input type='text' name='{1}' id='{1}'>
                            <img class='comment' comment='{2}' src='{0}\icon\comments\question.png'/>
                        ", 
                        Environment.CurrentDirectory, markerName, markerComment, markerCommentDyn)
                    );
                }
                if (type == "date")
                {
                    if (markerComment == "")
                        markerComment = Properties.Resources.comment_default_date;

                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"
                            <input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>
                            <img class='comment' comment='{3}' src='{0}\icon\comments\question.png'/>
                            <input type='text' name='{1}' id='{1}' class='date'>
                            <img class='comment' comment='{2}' src='{0}\icon\comments\question.png'/>
                        ", Environment.CurrentDirectory, markerName, markerComment, markerCommentDyn)
                    );
                }
                if (type == "static")
                {
                    if (markerComment == "")
                        markerComment = Properties.Resources.comment_default_static;

                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"
                            <input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>
                            <img class='comment' comment='{4}' src='{0}\icon\comments\question.png'/>
                            <input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>
                            <img class='comment' comment='{3}' src='{0}\icon\comments\question.png'/>
                        ", Environment.CurrentDirectory, markerName, val, markerComment, markerCommentDyn)
                    );
                }
                if (type == "")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(@"
                            <input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>
                            <img class='comment' comment='{4}' src='{0}\icon\comments\question.png'/>
                            {2}
                            <input type='text' style='display:none' disabled='disabled' name='{1}' id='{1}' value='{2}'>
                        ", Environment.CurrentDirectory, markerName, val, markerComment, markerCommentDyn)
                    );
                }

            }

            if (markerType == "static")
            {
                string val = "";

                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_static;

                if (this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText != null)
                {
                    val = this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText;
                }

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format(@"
                        <input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>
                        <img class='comment' comment='{3}' src='{0}\icon\comments\question.png'/>
                    ", Environment.CurrentDirectory, markerName, val, markerComment)
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

        public Document deleteLineInDocument(Document document, string textToFind)
        {
            document.BeginUpdate();
            try
            {
                
                DocumentRange[] ranges = document.FindAll("$$" + textToFind + "$$", SearchOptions.None);

                foreach (DocumentRange range in ranges)
                {
                    //document.Replace(ranges[range.Length - 1], string.Empty);
                    document.Delete(range);
                    Paragraph pp = document.GetParagraph(range.Start);
                    document.RemoveNumberingFromParagraph(pp);

                    document.Delete(pp.Range);
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
