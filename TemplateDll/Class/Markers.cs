using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DevExpress.XtraRichEdit.API.Native;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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
                    String.Format(""+
                        "<img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\question.png'/>"+
                        "<input type='text' name='{0}' id='{0}' val='' style='display:none'>"
                    , markerName, val, Environment.CurrentDirectory)
                );
            }

            if (markerType == "chart")
            {
                string val = "";

                int count_rows = 1;
                XmlNodeList rows = MarkerNode.SelectNodes("rows/row");

                foreach(XmlNode row in rows)
                {
                    val += count_rows + ":";
                    foreach (XmlNode col in row.SelectNodes("col"))
                    {
                       val += col.InnerText + ",";
                    }

                    val = val.Trim(',');

                    val += ";";

                    count_rows++;
                }

                val = val.Trim(';');

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format("" +
                        "<input type='text' name='{0}' id='{0}' text_type='chart' value='{1}' style='display:none'>"
                    , markerName, val, Environment.CurrentDirectory)
                );
            }

            if (markerType == "text")
            {
                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_text;

                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(""+
                        "<input type='text' name='{0}' id='{0}'>"+
                        "<img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\question.png'/>"
                    , markerName, markerComment, Environment.CurrentDirectory)
                );
            }

            if (markerType == "date")
            {
                if (markerComment == "")
                    markerComment = Properties.Resources.comment_default_date;

                html = html.Replace(
                    "$$" + markerName + "$$", 
                    String.Format(""+
                        "<input type='text' class='date' name='{0}' id='{0}' onfocus='this.blur()' readonly='readonly'>"+
                        "<img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\calendar.png'/>"
                    , markerName, markerComment, Environment.CurrentDirectory)
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
                    String.Format(""+
                        "<input type='text' name='{1}' id='{1}' text_type='formula' formula='{3}' disabled='disabled'>"+
                        "<img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\formula.png'/>"
                    , Environment.CurrentDirectory, markerName, markerComment, val)
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

                string markerCommentDyn = Properties.Resources.comment_default_checkbox;

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
                            markerComment = this.getStaticComment(marker.Attributes["field"].Value);

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
                        String.Format(""+
                            "<input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>"+
                            "<img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/>"+
                            "<input type='text' name='{1}' id='{1}'>"+
                            "<img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\question.png'/>"
                        , Environment.CurrentDirectory, markerName, markerComment, markerCommentDyn)
                    );
                }
                if (type == "date")
                {
                    if (markerComment == "")
                        markerComment = Properties.Resources.comment_default_date;

                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(""+
                            "<input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>"+
                            "<img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/>"+
                            "<input type='text' name='{1}' id='{1}' class='date' onfocus='this.blur()' readonly='readonly'>"+
                            "<img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\calendar.png'/>"
                        , Environment.CurrentDirectory, markerName, markerComment, markerCommentDyn)
                    );
                }
                if (type == "static")
                {
                    
                    if (markerComment == "")
                        markerComment = Properties.Resources.comment_default_static;


                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(""+
                            "<input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>"+
                            "<img class='comment' comment=\"{4}\" src='{0}\\icon\\comments\\question.png'/>"+
                            "<input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>"+
                            "<img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/>"
                        , Environment.CurrentDirectory, markerName, val, markerComment, markerCommentDyn)
                    );
                }
                if (type == "")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(""+
                            "<input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>"+
                            "<img class='comment' comment=\"{4}\" src='{0}\\icon\\comments\\question.png'/>"+
                            "{2}"+
                            "<input type='text' style='display:none' disabled='disabled' name='{1}' id='{1}' value='{2}'>"
                        , Environment.CurrentDirectory, markerName, val, markerComment, markerCommentDyn)
                    );
                }

            }

            if (markerType == "static")
            {
                string val = "";

                if (markerComment == "")
                    markerComment = this.getStaticComment(MarkerNode.Attributes["field"].Value);

                if (this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText != null)
                {
                    val = this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText;
                }

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format(""+
                        "<input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>"+
                        "<img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/>"
                    , Environment.CurrentDirectory, markerName, val, markerComment)
                );
            }

            return html;
        }

        private string getStaticComment(string fieldName)
        {
            string val = Properties.Resources.comment_default_static;

            if (fieldName == "full_name") val = "<b>Повна назва організації</b> проставляється автоматично з даних реєстраційної картки. Назва організації — автора документа — має відповідати назві, зазначеній в установчих документах (статуті, положенні про організацію).";
            if (fieldName == "full_name_genitive") val = "<b>Повна назва</b> організації в родовому відмінку (з малої літери) проставляється автоматично з даних реєстраційної картки. ";
            if (fieldName == "abbreviation") val = "<b>Скорочена назва</b> організації проставляється автоматично з даних реєстраційної картки. Скорочену назву організації зазначають тоді, коли її офіційно зафіксовано в статуті (положенні про організацію).";
            if (fieldName == "abbreviation_genitive") val = "<b>Скорочена назва</b> навчального закладу в родовому відмінку проставляється автоматично з даних реєстраційної картки. ";
            if (fieldName == "subordination") val = "<b>Назва організації вищого рівня</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "subordination_genitive") val = "<b>Назва організації вищого рівня</b> у родовому відмінку проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "unit") val = "<b>Назва структурного підроздіту організації</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "place") val = "<b>Місце складання документа</b> проставляється автоматично з даних реєстраційної картки. Якщо відомості про географічне місцезнаходження входять до назви навчального закладу, то реквізит «місце складання документа» не зазначають. ";
            if (fieldName == "code") val = "<b>Код ЄДРПОУ</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "bank") val = "<b>Банківські реквізити</b> (номер банківського рахунку, назва установи банку, її код) проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "legal_address") val = "<b>Юридична адреса</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_name") val = "<b>Прізвище, ім’я, по батькові</b> керівника проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_name_genitive") val = "<b>Прізвище, імя, по батькові керівника</b> у родовому відмінку проставляються автоматично з даних реєстраційної картки";
            if (fieldName == "chief_surname") val = "<b>Прізвище та ініціали керівника</b> проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_surname_dative") val = "<b>Прізвище та ініціали керівника</b> у давальному відмінку проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_initials") val = "<b>Ініціали та прізвище керівника</b> навчального закладу проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_position") val = "<b>Посада керівника</b> навчального закладу (з великої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_position_dative") val = "<b>Посада керівника у давальному відмінку</b> (з великої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "chief_position_lower") val = "<b>Посада керівника у родовому відмінку</b> (з малої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "position_cadre") val = "<b>Назва посади керівника кадрової служби</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "position_cadre_genitive") val = "<b>Назва посади керівника кадрової служби</b> в родовому відмінку проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "initials_cadre") val = "<b>Ініціали та прізвище керівника кадрової служби</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "surname_cadre") val = "<b>Прізвище, ініціали керівника кадрової служби</b> проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "address") val = "<b>Поштова адреса</b> організації проставляється автоматично з даних реєстраційної картки. Реквізити поштової адреси у реєстраційній картці слід зазначати у <b>такій послідовності:</b> назва вулиці, номер будинку, назва населеного пункту, району, області, поштовий індекс.";
            if (fieldName == "tel") val = "<b>Номер телефону</b> організації проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "fax") val = "<b>Номер факсу</b> організації проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "e-mail") val = "<b>Електронна адреса</b> організації проставляється автоматично з даних реєстраційної картки.";

            return val;
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

        public Document replaceImgInDocument(Document document, string from, Image chart)
        {
            document.BeginUpdate();

            try
            {
                DocumentRange[] ranges = document.FindAll("$$" + from + "$$", SearchOptions.None);

                foreach (DocumentRange range in ranges)
                {
                    document.Replace(range, "");
                    document.Images.Insert(range.Start, chart);
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
