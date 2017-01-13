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
                markerComment = MarkerNode.Attributes["comment"].Value.Replace("\"", "'");
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
                        "<span class='marker'><img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\question.png'/></span>" +
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
                        "<span class='marker'><img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\text.png'/></span>"
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
                        "<span class='marker'><img class='comment' comment=\"{1}\" src='{2}\\icon\\comments\\calendar.png'/></span>"
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
                        "<span class='marker'><img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\formula.png'/></span>"
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
                            markerComment = marker.Attributes["comment"].Value.Replace("\"","'");
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
                            "<span class='marker'><img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/></span>" +
                            "<input type='text' name='{1}' id='{1}'>"+
                            "<span class='marker'><img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\text.png'/></span>"
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
                            "<span class='marker'><img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\question.png'/></span>" +
                            "<input type='text' name='{1}' id='{1}' class='date' onfocus='this.blur()' readonly='readonly'>"+
                            "<span class='marker'><img class='comment' comment=\"{2}\" src='{0}\\icon\\comments\\calendar.png'/></span>"
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
                            "<span class='marker'><img class='comment' comment=\"{4}\" src='{0}\\icon\\comments\\question.png'/></span>" +
                            "<input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>"+
                            "<span class='marker'><img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\autofill.png'/></span>"
                        , Environment.CurrentDirectory, markerName, val, markerComment, markerCommentDyn)
                    );
                }
                if (type == "")
                {
                    html = html.Replace(
                        "$$" + markerName + "$$",
                        String.Format(""+
                            "<input type='checkbox' checked='checked' name='{1}' id='dyn_{1}'/>"+
                            "<span class='marker'><img class='comment' comment=\"{4}\" src='{0}\\icon\\comments\\question.png'/></span>" +
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

                if (MarkerNode.Attributes["field"].Value != "")
                {
                    if (this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText != null)
                    {
                        val = this.userDataXml[MarkerNode.Attributes["field"].Value].InnerText;
                    }
                }

                html = html.Replace(
                    "$$" + markerName + "$$",
                    String.Format(""+
                        "<input type='text' class='static' disabled='disabled' name='{1}' id='{1}' value='{2}'>"+
                        "<span class='marker'><img class='comment' comment=\"{3}\" src='{0}\\icon\\comments\\autofill.png'/></span>"
                    , Environment.CurrentDirectory, markerName, val, markerComment)
                );
            }

            return html;
        }

        private string getStaticComment(string fieldName)
        {
            string val = Properties.Resources.comment_default_static;

            if (fieldName == "FullName") val = "<b>Повна назва організації</b> проставляється автоматично з даних реєстраційної картки. Назва організації — автора документа — має відповідати назві, зазначеній в установчих документах (статуті, положенні про організацію).";
            if (fieldName == "FullNameGenitive") val = "<b>Повна назва</b> організації в родовому відмінку (з малої літери) проставляється автоматично з даних реєстраційної картки. ";
            if (fieldName == "Abbreviation") val = "<b>Скорочена назва</b> організації проставляється автоматично з даних реєстраційної картки. Скорочену назву організації зазначають тоді, коли її офіційно зафіксовано в статуті (положенні про організацію).";
            if (fieldName == "AbbreviationGenitive") val = "<b>Скорочена назва</b> навчального закладу в родовому відмінку проставляється автоматично з даних реєстраційної картки. ";
            if (fieldName == "Subordination") val = "<b>Назва організації вищого рівня</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "SubordinationGenitive") val = "<b>Назва організації вищого рівня</b> у родовому відмінку проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "Unit") val = "<b>Назва структурного підроздіту організації</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "Place") val = "<b>Місце складання документа</b> проставляється автоматично з даних реєстраційної картки. Якщо відомості про географічне місцезнаходження входять до назви навчального закладу, то реквізит «місце складання документа» не зазначають. ";
            if (fieldName == "Code") val = "<b>Код ЄДРПОУ</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "Bank") val = "<b>Банківські реквізити</b> (номер банківського рахунку, назва установи банку, її код) проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "LegalAddress") val = "<b>Юридична адреса</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefName") val = "<b>Прізвище, ім’я, по батькові</b> керівника проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefNameGenitive") val = "<b>Прізвище, імя, по батькові керівника</b> у родовому відмінку проставляються автоматично з даних реєстраційної картки";
            if (fieldName == "ChiefSurname") val = "<b>Прізвище та ініціали керівника</b> проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefSurnameDative") val = "<b>Прізвище та ініціали керівника</b> у давальному відмінку проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefInitials") val = "<b>Ініціали та прізвище керівника</b> навчального закладу проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefPosition") val = "<b>Посада керівника</b> навчального закладу (з великої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefPositionDative") val = "<b>Посада керівника у давальному відмінку</b> (з великої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "ChiefPositionLower") val = "<b>Посада керівника у родовому відмінку</b> (з малої літери) проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "PositionCadre") val = "<b>Назва посади керівника кадрової служби</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "PositionCadreGenitive") val = "<b>Назва посади керівника кадрової служби</b> в родовому відмінку проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "InitialsCadre") val = "<b>Ініціали та прізвище керівника кадрової служби</b> проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "SurnameCadre") val = "<b>Прізвище, ініціали керівника кадрової служби</b> проставляються автоматично з даних реєстраційної картки.";
            if (fieldName == "Address") val = "<b>Поштова адреса</b> організації проставляється автоматично з даних реєстраційної картки. Реквізити поштової адреси у реєстраційній картці слід зазначати у <b>такій послідовності:</b> назва вулиці, номер будинку, назва населеного пункту, району, області, поштовий індекс.";
            if (fieldName == "Tel") val = "<b>Номер телефону</b> організації проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "Fax") val = "<b>Номер факсу</b> організації проставляється автоматично з даних реєстраційної картки.";
            if (fieldName == "Email") val = "<b>Електронна адреса</b> організації проставляється автоматично з даних реєстраційної картки.";

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
