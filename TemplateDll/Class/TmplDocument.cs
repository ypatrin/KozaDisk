using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.Collections;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Drawing;

namespace templates
{
    class TmplDocument
    {
        private static TmplDocument instance;
        private RichEditControl Doc = new RichEditControl();
        private WebBrowser browser;
        private Markers markers = new Markers();
        private string templateName;

        private TmplDocument()
        { }

        public static TmplDocument getInstance()
        {
            if (instance == null)
                instance = new TmplDocument();
            return instance;
        }

        public void setDocument(string documentPath)
        {
            this.Doc.LoadDocument(documentPath);
            this.templateName = Path.GetFileName(documentPath);
        }

        public void setBrowser(WebBrowser browser)
        {
            this.browser = browser;
        }

        public Document getDocument()
        {
            return Doc.Document;
        }

        public void saveToHtml(string htmlFileName)
        {
            Doc.Options.Export.Html.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Inline;
            Doc.Options.Export.Html.HtmlNumberingListExportFormat = DevExpress.XtraRichEdit.Export.Html.HtmlNumberingListExportFormat.PlainTextFormat;
            Doc.Options.Export.Html.UseHtml5 = true;
            Doc.SaveDocument(htmlFileName, DocumentFormat.Html);
        }

        public void processMarkers()
        {
            this.processTextMarkers();
        }

        public void save()
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = this.templateName;
            saveDialog.Filter = "MS Word Document|*.docx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                this.Doc.Document.SaveDocument(saveDialog.FileName, DocumentFormat.OpenXml);
            }
        }

        private string getValueById(string id)
        {
            string val = "";

            // get all input element
            var elements = this.browser.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in elements)
            {
                if (input.GetAttribute("id") == id)
                {
                    val = input.GetAttribute("value");
                }
            }

            return val;
        }

        private void processTextMarkers()
        {
            // get all input element
            var elements = this.browser.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in elements)
            {
                // process only text elements
                if (input.GetAttribute("type") == "text")
                {
                    var name = input.GetAttribute("name");
                    var value = input.GetAttribute("value");

                    //check if it's chart
                    if (input.GetAttribute("text_type") != null && input.GetAttribute("text_type") == "chart")
                    {
                        ArrayList listDataSource = new ArrayList();

                        ChartControl myChart = new ChartControl();
                        myChart.DataSource = listDataSource;

                        //prepare data
                        foreach (string line in value.Split(';'))
                        {
                            string row_count = line.Split(':')[0];
                            string cols = line.Split(':')[1];

                            int col_count = 1;

                            foreach(string col in cols.Split(','))
                            {
                                string colVal = this.getValueById(col);
                                listDataSource.Add(new ChartRecord(Int32.Parse(row_count), Int32.Parse(colVal), col_count.ToString()));

                                col_count++;
                            }

                            // Create a series, and add it to the chart. 
                            Series chartSeries = new Series("My Series", ViewType.Line);
                            myChart.Series.Add(chartSeries);

                            // Adjust the series data members. 
                            chartSeries.ArgumentDataMember = "name";
                            chartSeries.ValueDataMembers.AddRange(new string[] { "val" });

                            // Access the view-type-specific options of the series. 
                            ((LineSeriesView)chartSeries.View).ColorEach = true;
                            chartSeries.LegendPointOptions.Pattern = "{A}";
                        }

                        myChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        myChart.Width = 645;

                        //export to image
                        Image image = null;

                        using (MemoryStream s = new MemoryStream())
                        {
                            myChart.ExportToImage(s, ImageFormat.Png);
                            image = Image.FromStream(s);
                        }


                        this.markers.replaceImgInDocument(this.Doc.Document, name, image);
                        
                    }

                    // check if it's formula
                    if (input.GetAttribute("text_type") != null && input.GetAttribute("text_type") == "formula")
                    {
                        var formula = input.GetAttribute("formula");
                        int fn = 0;

                        // plus formuls
                        if (formula.Split('+').Length > 2)
                        {
                            foreach (string f in formula.Split('+'))
                            {
                                foreach (HtmlElement cInput in elements)
                                {
                                    if (f == cInput.GetAttribute("name"))
                                    {
                                        int n;
                                        if (cInput.GetAttribute("value") != null && cInput.GetAttribute("value") != "" && int.TryParse(cInput.GetAttribute("value"), out n))
                                        {
                                            if (fn == 0) fn = Int32.Parse(cInput.GetAttribute("value"));
                                            else fn += Int32.Parse(cInput.GetAttribute("value"));
                                        }
                                    }
                                }
                            }
                        }

                        // minus dormuls
                        if (formula.Split('-').Length > 2)
                        {
                            foreach (string f in formula.Split('+'))
                            {
                                foreach (HtmlElement cInput in elements)
                                {
                                    if (f == cInput.GetAttribute("name"))
                                    {
                                        if (fn == 0) fn = Int32.Parse(cInput.GetAttribute("value"));
                                        else fn -= Int32.Parse(cInput.GetAttribute("value"));
                                    }
                                }
                            }
                        }

                        // set field value to formula resut
                        value = fn.ToString();
                    } 

                    // check dynamic markers checkboxes
                    bool isHaveCheckbox = false;
                    bool isChecked = false;

                    foreach (HtmlElement cInput in elements)
                    {
                        //dynamic markers allready have checkbox. is this marker has checkbox?
                        if (cInput.GetAttribute("type") == "checkbox" && cInput.GetAttribute("name") == name)
                        {
                            isHaveCheckbox = true;

                            //if this marker have checkbox - this is dynamic marker, check if it checked
                            if (cInput.GetAttribute("checked") == "True")
                                isChecked = true;
                        }
                    }

                    if (isHaveCheckbox && isChecked)
                    {
                        this.markers.replaceInDocument(this.Doc.Document, name, value);
                    }
                    if (isHaveCheckbox && !isChecked)
                    {
                        this.markers.deleteLineInDocument(this.Doc.Document, name);
                        this.markers.replaceInDocument(this.Doc.Document, name, "");
                    }
                    if (!isHaveCheckbox)
                    {
                        this.markers.replaceInDocument(this.Doc.Document, name, value);
                    }
                }
            }
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
    }
}
