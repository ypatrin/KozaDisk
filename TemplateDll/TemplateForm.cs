using DevExpress.Office.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace templates
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class TemplateForm : Form
    {
        string ApplicationPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\";

        PrintableComponentLink link;
        RichEditControl richEditControl;
        Progress progress = Progress.getInstance();

        string templateName = "";
        string userName = "";
        string dbName = "";
        int docId = 0;
        int myDocId = 0;
        string orientation = "portrait";

        public TemplateForm()
        {
            InitializeComponent();

            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = true;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = true;

            webBrowser2.AllowWebBrowserDrop = false;
            webBrowser2.WebBrowserShortcutsEnabled = false;
            webBrowser2.ObjectForScripting = this;
            webBrowser2.ScriptErrorsSuppressed = true;
            webBrowser2.IsWebBrowserContextMenuEnabled = false;
        }

        public void setTemplateName(String templateName)
        {
            this.templateName = templateName;
            this.TemplateNameBox.Text = templateName;
        }

        public void setUserName(string userName)
        {
            this.userName = userName;
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

        public void setTemplateOrientation(string orientation)
        {
            this.orientation = orientation;
        }

        public void loadHTML(string html)
        {
            webBrowser1.Navigate("about:blank");
            webBrowser1.DocumentText = "0";
            webBrowser1.Document.OpenNew(true);
            webBrowser1.Document.Write(html);
            webBrowser1.Refresh();

            webBrowser2.Navigate("about:blank");
            webBrowser2.DocumentText = "0";
            webBrowser2.Document.OpenNew(true);
            webBrowser2.Document.Write("<html><body style=\"background: #F5F5F5\"></body></html>");
            webBrowser2.Refresh();

            //Wait for document to finish loading
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(5);
            }

            this.runJs();
        }

        public void loadHtmlElementsValue(string documentHtmlValues)
        {
            try
            {
                foreach (string htmlElement in documentHtmlValues.Split(';'))
                {
                    try
                    {
                        if (htmlElement == "")
                            continue;

                        string[] element = htmlElement.Split(':');

                        if (element.Length < 3)
                            continue;

                        string type = element[0];
                        string name = element[1];
                        string val = element[2];

                        foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
                        {
                            try
                            {
                                if (HtmlElement1.Name == name)
                                {
                                    if (type == "text")
                                    {
                                        HtmlElement1.SetAttribute("value", val);
                                    }
                                    if (type == "checkbox")
                                    {
                                        if (val == "False")
                                            HtmlElement1.SetAttribute("checked", "");
                                    }
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }
                    catch (Exception e) { }
                }
            }
            catch (Exception Error) { }
        }

        public void runJs()
        {
            webBrowser1.Document.InvokeScript("procCalendar");
        }

        public void injectModules(string htmlFile)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.Load(htmlFile);
            HtmlNode head = htmlDocument.DocumentNode.SelectSingleNode("/html/head");

            // inject calendar module
            HtmlNode calendarJs = htmlDocument.CreateElement("script");
            calendarJs.SetAttributeValue("type", "text/javascript");
            calendarJs.SetAttributeValue("src", ApplicationPath + @"\js\lib\calendar\dhtmlxcalendar.js");
            head.AppendChild(calendarJs);

            HtmlNode calendarCss = htmlDocument.CreateElement("link");
            calendarCss.SetAttributeValue("rel", "stylesheet");
            calendarCss.SetAttributeValue("href", ApplicationPath + @"\js\lib\calendar\dhtmlxcalendar.css");
            head.AppendChild(calendarCss);

            //inject jquery
            HtmlNode jqueryJs = htmlDocument.CreateElement("script");
            jqueryJs.SetAttributeValue("type", "text/javascript");
            jqueryJs.SetAttributeValue("src", ApplicationPath + @"\js\jquery.js");
            head.AppendChild(jqueryJs);

            //inject page js
            HtmlNode pageJs = htmlDocument.CreateElement("script");
            pageJs.SetAttributeValue("type", "text/javascript");
            pageJs.SetAttributeValue("src", ApplicationPath + @"\js\page.js");
            head.AppendChild(pageJs);

            //inject page css
            if (this.orientation == "portrait")
            {
                HtmlNode pageCss = htmlDocument.CreateElement("link");
                pageCss.SetAttributeValue("rel", "stylesheet");
                pageCss.SetAttributeValue("href", ApplicationPath + @"\css\page-portrait.css");
                head.AppendChild(pageCss);
            }
            else
            {
                HtmlNode pageCss = htmlDocument.CreateElement("link");
                pageCss.SetAttributeValue("rel", "stylesheet");
                pageCss.SetAttributeValue("href", ApplicationPath + @"\css\page-album.css");
                head.AppendChild(pageCss);
            }

            htmlDocument.Save(htmlFile);
        }

        private void DownloadClick(object sender, EventArgs e)
        {
            try
            {
                this.progress.Open();
                this.progress.setMax(4);
                this.progress.setCurrent(0);

                TmplDocument tmplDocument = TmplDocument.getInstance();
                Markers markers = new Markers();

                tmplDocument.prepareDocument();
                this.progress.setCurrent(1);

                tmplDocument.setBrowser(webBrowser1);
                this.progress.setCurrent(2);

                tmplDocument.processMarkers();
                this.progress.setCurrent(3);

                tmplDocument.setName(this.TemplateNameBox.Text);
                tmplDocument.save();
                this.progress.Close();
            }
            catch(Exception ex) { }
        }

        public void showComment(String comment)
        {
            string html = string.Format("<html><head><script type=\"text/javascript\" src=\"{0}\"></script><script type=\"text/javascript\" src=\"{1}\"></script></head><body style=\"background: #F5F5F5\">{2}</body></html>",
                ApplicationPath + @"\js\jquery.js", ApplicationPath + @"\js\comment.js", comment
            );

            webBrowser2.Navigate("about:blank");
            webBrowser2.DocumentText = "0";
            webBrowser2.Document.OpenNew(true);
            webBrowser2.Document.Write(html);
            webBrowser2.Refresh();
        }

        public void openUrl(String url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void PrintClick(object sender, EventArgs e)
        {
            this.progress.Open();
            this.progress.setMax(4);
            this.progress.setCurrent(0);

            TmplDocument tmplDocument = TmplDocument.getInstance();
            Markers markers = new Markers();
            
            //prepare document
            tmplDocument.prepareDocument();
            this.progress.setCurrent(1);

            // set browser
            tmplDocument.setBrowser(webBrowser1);
            this.progress.setCurrent(2);

            // process markers
            tmplDocument.processMarkers();
            this.progress.setCurrent(3);

            PrintForm printForm = new PrintForm(tmplDocument.getRichEditControl());
            this.progress.Close();
            printForm.ShowDialog();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = (panel1.Width-200);
            size.Height = this.TemplateNameBox.Size.Height;
            this.TemplateNameBox.Size = size;

            Point point = new Point(0, (panel3.Height / 2)-50 );

            this.ShowCommentBtn.Location = new Point(0, (panel3.Height / 2) - 50);
            this.HideCommentBtn.Location = new Point(0, (panel3.Height / 2) - 50 - 61);

            this.Activate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel3.Size = new Size(30, 348);
            this.panel13.Visible = false;
            this.HideCommentBtn.Visible = false;
            this.ShowCommentBtn.Visible = true;

            this.panel3.BackColor = Color.White;
            this.panel3.BorderStyle = BorderStyle.None;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.panel3.Size = new Size(300, 348);
            this.panel13.Visible = true;
            this.HideCommentBtn.Visible = true;
            this.ShowCommentBtn.Visible = false;

            this.panel3.BackColor = Color.FromArgb(245,245,245);
            this.panel3.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string htmlElements = "";
                var elements = webBrowser1.Document.GetElementsByTagName("input");

                foreach (HtmlElement element in elements)
                {
                    if (element.GetAttribute("type") == "text")
                    {
                        htmlElements += $"text:{element.Name}:{element.GetAttribute("value")};";
                    }

                    if (element.GetAttribute("type") == "checkbox")
                    {
                        string isChecked = element.GetAttribute("checked");
                        htmlElements += $"checkbox:{element.Name}:{isChecked};";
                    }
                }

                string encHtml = Base64Encode(htmlElements);

                string AppStorage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\KozaDisk\\";
                string DocumentsDB = AppStorage + $"users\\{this.userName}\\documents.db";
                string db = this.dbName;
                int docId = this.docId;

                //save doc to DB

                if (!System.IO.File.Exists(DocumentsDB))
                {
                    SQLiteConnection.CreateFile(DocumentsDB);
                    SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};", DocumentsDB));
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE documents (id INTEGER PRIMARY KEY AUTOINCREMENT, db_name STRING(255), doc_id INTEGER(13), doc_name STRING(255), doc_html TEXT, created_at DATETIME); ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", DocumentsDB));
                connection.Open();

                if (this.myDocId > 0)
                {
                    //delete old
                    SQLiteCommand c = new SQLiteCommand($"DELETE FROM documents WHERE id = '{this.myDocId}'", connection);
                    c.ExecuteNonQuery();
                }

                //add
                string sql = $"INSERT INTO documents (db_name, doc_id, doc_name, doc_html, created_at) values ('{db}', '{docId}', '{this.TemplateNameBox.Text}', '{encHtml}', datetime('now'))";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Збережено в розділі «Мої документи»", "КОЗА-ДИСК", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(0, 189, 156);
            button.ForeColor = Color.White;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(27, 30, 37);
            button.ForeColor = Color.FromArgb(227, 227, 229);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
