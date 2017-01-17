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
        private RichEditControl Doc = new RichEditControl(), newDoc = null;
        private WebBrowser browser;
        private Markers markers = new Markers();
        private string templateName;
        private string templatePath = "";

        private TmplDocument()
        { }

        public static TmplDocument getInstance()
        {
            if (instance == null)
                instance = new TmplDocument();
            return instance;
        }

        public void setName(string templateName)
        {
            this.templateName = templateName;
        }

        public void setDocument(string templatePath)
        {
            this.templatePath = templatePath;
            this.Doc.LoadDocument(templatePath);
        }

        public void setBrowser(WebBrowser browser)
        {
            this.browser = browser;
        }

        public Document getDocument()
        {
            return this.newDoc.Document;
        }

        public void prepareDocument()
        {
            //clear
            this.newDoc = null;
            this.newDoc = new RichEditControl();

            //open template
            this.newDoc.LoadDocument(this.templatePath);
        }

        public RichEditControl getRichEditControl()
        {
            return this.newDoc;
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
            this.newDoc.BeginUpdate();
            this.processTextMarkers();
            this.newDoc.EndUpdate();
        }

        public void save()
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = this.templateName;
            saveDialog.Filter = "MS Word Document|*.docx";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                this.newDoc.Document.SaveDocument(saveDialog.FileName, DocumentFormat.OpenXml);
                MessageBox.Show("Документ успішно збережений!", "Koza Disk", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                        this.markers.replaceImgInDocument(this.newDoc.Document, name, image);
                        
                    }

                    // check if it's formula
                    if (input.GetAttribute("text_type") != null && input.GetAttribute("text_type") == "formula")
                    {
                        var formula = input.GetAttribute("formula");
                        value = input.GetAttribute("value");
                    } 
                    
                    // check dynamic markers checkboxes
                    bool isHaveCheckbox = false;
                    bool isChecked = false;
                    bool isEmptyTextBox = false;

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

                        if (cInput.GetAttribute("type") == "text" && cInput.GetAttribute("name") == name)
                        {
                            if (cInput.GetAttribute("value") == "")
                                isEmptyTextBox = true;
                        }
                    }

                    if (isHaveCheckbox && isChecked)
                    {
                        this.markers.replaceInDocument(this.newDoc.Document, name, value);
                    }
                    if (isHaveCheckbox && !isChecked && !isEmptyTextBox)
                    {
                        //this.markers.deleteLineInDocument(this.newDoc.Document, name);
                        this.markers.replaceInDocument(this.newDoc.Document, name, "");
                    }
                    if (isHaveCheckbox && !isChecked && isEmptyTextBox)
                    {
                        this.markers.deleteLineInDocument(this.newDoc.Document, name);
                        this.markers.replaceInDocument(this.newDoc.Document, name, "");
                    }
                    if (!isHaveCheckbox)
                    {
                        this.markers.replaceInDocument(this.newDoc.Document, name, value);
                    }
                }
            }

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

                            foreach (string col in cols.Split(','))
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


                        this.markers.replaceImgInDocument(this.newDoc.Document, name, image);

                    }

                    // check if it's formula
                    if (input.GetAttribute("text_type") != null && input.GetAttribute("text_type") == "formula")
                    {
                        var formula = input.GetAttribute("formula");
                        value = input.GetAttribute("value");
                    }

                    // check dynamic markers checkboxes
                    bool isHaveCheckbox = false;
                    bool isChecked = false;
                    bool isEmptyTextBox = false;

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

                        if (cInput.GetAttribute("type") == "text" && cInput.GetAttribute("name") == name)
                        {
                            if (cInput.GetAttribute("value") == "")
                                isEmptyTextBox = true;
                        }
                    }

                    if (isHaveCheckbox && isChecked)
                    {
                        this.markers.replaceInDocument2(this.newDoc.Document, name, value);
                    }
                    if (isHaveCheckbox && !isChecked && !isEmptyTextBox)
                    {
                        //this.markers.deleteLineInDocument(this.newDoc.Document, name);
                        this.markers.replaceInDocument2(this.newDoc.Document, name, "");
                    }
                    if (isHaveCheckbox && !isChecked && isEmptyTextBox)
                    {
                        this.markers.deleteLineInDocument(this.newDoc.Document, name);
                        this.markers.replaceInDocument2(this.newDoc.Document, name, "");
                    }
                    if (!isHaveCheckbox)
                    {
                        this.markers.replaceInDocument2(this.newDoc.Document, name, value);
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
