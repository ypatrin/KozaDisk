using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Web;

namespace Editor.Class
{
    class DB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// MySQL DB Class Constructor
        /// </summary>
        public DB()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize 
        /// </summary>
        private void Initialize()
        {
            this.server = "194.247.12.67";
            this.database = "kozaonline_db";
            this.uid = "yury.patrin";
            this.password = "ClearMeaN";

            string connectionString = $"SERVER={this.server}; DATABASE={this.database}; UID={this.uid}; PASSWORD={this.password};";
            this.connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Open connection to DB
        /// </summary>
        /// <returns>Status</returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show(ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }

        /// <summary>
        /// Close connection to DB
        /// </summary>
        /// <returns>status</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get List of catalogs
        /// </summary>
        /// <returns>list of catalogs</returns>
        public List<Catalog> getCatalogs()
        {
            string query = "SELECT * FROM admin_catalog_parts ORDER BY position";

            //Create a list to store the result
            List<Catalog> list = new List<Catalog>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Catalog cat = new Catalog();
                    cat.id = dataReader["id"].ToString();
                    cat.name = dataReader["name"].ToString();
                    cat.parentId = dataReader["parent_id"].ToString();
                    cat.position = dataReader["position"].ToString();

                    list.Add(cat);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// Get list of documents by Catalog ID
        /// </summary>
        /// <param name="catalogId">Catalog ID</param>
        public List<Document> getDocuments(string catalogId)
        {
            string query = $"SELECT * FROM document_templates WHERE catalog_part_id = '{catalogId}' ORDER BY position";

            //Create a list to store the result
            List<Document> list = new List<Document>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Document doc = new Document();
                    doc.id = dataReader["id"].ToString();
                    doc.categoryId = dataReader["catalog_part_id"].ToString();
                    doc.name = dataReader["name"].ToString();
                    doc.fileName = dataReader["file_name"].ToString();

                    list.Add(doc);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public string getTemplateFileName(string documentId)
        {
            string fileName = null;
            string query = $"SELECT * FROM document_templates WHERE id = '{documentId}'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    fileName = dataReader["file_name"].ToString();
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return fileName;
            }

            return null;
        }

        /// <summary>
        /// Get list of documents by Document Name
        /// </summary>
        /// <param name="catalogId">Catalog ID</param>
        public List<Document> getDocumentsById(string documentId)
        {
            string query = $"SELECT * FROM document_templates WHERE id = '{documentId}' ORDER BY position";

            //Create a list to store the result
            List<Document> list = new List<Document>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Document doc = new Document();
                    doc.id = dataReader["id"].ToString();
                    doc.categoryId = dataReader["catalog_part_id"].ToString();
                    doc.name = dataReader["name"].ToString();
                    doc.fileName = dataReader["file_name"].ToString();

                    list.Add(doc);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// Get markers XML file
        /// </summary>
        /// <param name="documentId">Document ID</param>
        public string getDocumentXml(string documentId)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            xml += "<markers>";
            xml += this._getMarkers(documentId);
            xml += this._getDynMarkers(documentId);         
            xml += @"</markers>";

            return xml;
        }

        private string _getDynMarkers(string documentId)
        {
            string query = $"SELECT * FROM dynamic_markers dm WHERE dm.template_id = '{documentId}';";
            string xml = "";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string markerName = dataReader["alias"].ToString().Trim();
                    string markerComment = dataReader["comment"].ToString().Trim();
                    string markerText = dataReader["text"].ToString().Trim();

                    markerText = markerText.Replace("\n", "<br/>");
                    markerText = markerText.Replace("<", "&lt;");
                    markerText = markerText.Replace(">", "&gt;");
                    markerText = markerText.Replace("\"", "&quot;");
                    markerText = markerText.Replace("\t", "");
                    markerText = markerText.Replace("&nbsp;", " ");

                    if (markerText != "")
                        markerText = System.Web.HttpUtility.HtmlEncode(markerText);

                    markerComment = markerComment.Replace("<", "&lt;");
                    markerComment = markerComment.Replace(">", "&gt;");
                    markerComment = markerComment.Replace("\"", "&quot;");
                    markerComment = markerComment.Replace("\n", "");
                    markerComment = markerComment.Replace("\t", "");
                    markerComment = markerComment.Replace("&nbsp;", " ");

                    if (markerComment != "")
                        markerComment = System.Web.HttpUtility.HtmlEncode(markerComment);

                    xml += $"<marker name=\"{markerName}\" type=\"dynamic\" value=\"{markerText}\" />";
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return xml;
        }

        private string _getMarkers(string documentId)
        {
            string query = $"SELECT * FROM marker WHERE template_id = '{documentId}';";
            string xml = "";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string markerName = dataReader["name"].ToString().Trim();
                    string markerAlias = dataReader["alias"].ToString().Trim();
                    string markerComment = dataReader["comment"].ToString().Trim();
                    string markerFormula = dataReader["formula"].ToString().Trim();

                    markerComment = markerComment.Replace("<", "&lt;");
                    markerComment = markerComment.Replace(">", "&gt;");
                    markerComment = markerComment.Replace("\"", "&quot;");
                    markerComment = markerComment.Replace("\n", "");
                    markerComment = markerComment.Replace("\t", "");

                    if (markerComment != "")
                    markerComment = System.Web.HttpUtility.HtmlEncode(markerComment);

                    if (dataReader["type_id"].ToString() == "1")
                    {
                        Serializer serializer = new Serializer();
                        Dictionary<System.Object, System.Object> phpFormula = (Dictionary<System.Object, System.Object>)serializer.Deserialize(markerFormula);

                        Dictionary<System.Object, System.Object> args = (Dictionary<System.Object, System.Object>)phpFormula["args"];
                        string formula = (string)args["commernt"];

                        formula = formula.Replace("<", "&lt;");
                        formula = formula.Replace(">", "&gt;");
                        formula = formula.Replace("\"", "&quot;");
                        formula = formula.Replace("\n", "");
                        formula = formula.Replace("\t", "");
                        formula = System.Web.HttpUtility.HtmlEncode(formula);

                        xml += $"<marker name=\"{markerAlias}\" type=\"formula\" value=\"{formula}\" comment=\"{markerComment}\" />";
                    }
                    if (dataReader["type_id"].ToString() == "2")
                    {
                        xml += $"<marker name=\"{markerAlias}\" type=\"static\" field=\"{this.getFiledName(markerName)}\" comment=\"{markerComment}\" />";
                    }
                    if (dataReader["type_id"].ToString() == "3")
                    {
                        xml += $"<marker name=\"{markerAlias}\" type=\"text\" comment=\"{markerComment}\" />";
                    }
                    if (dataReader["type_id"].ToString() == "4")
                    {
                        xml += $"<marker name=\"{markerAlias}\" type=\"date\" comment=\"{markerComment}\" />";
                    }
                    if (dataReader["type_id"].ToString() == "5")
                    {
                        Serializer serializer = new Serializer();
                        Dictionary<System.Object, System.Object> phpFormula = (Dictionary<System.Object, System.Object>)serializer.Deserialize(markerFormula);

                        Dictionary<System.Object, System.Object> args = (Dictionary<System.Object, System.Object>)phpFormula["args"];
                        string comment = (string)args["commernt"];

                        comment = comment.Replace("<", "&lt;");
                        comment = comment.Replace(">", "&gt;");
                        comment = comment.Replace("\"", "&quot;");
                        comment = comment.Replace("\n", "");
                        comment = comment.Replace("\t", "");

                        if (comment != "")
                            comment = System.Web.HttpUtility.HtmlEncode(comment);

                        xml += $"<marker name=\"{markerAlias}\" type=\"comment\" value=\"{comment}\" />";
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return xml;
        }

        private string getFiledName(string name)
        {
            if (name == "s_1_full_name") return "FullName";
            if (name == "s_2_full_name") return "FullNameGenitive";
            if (name == "s_2_full_name1") return "FullNameGenitive";
            if (name == "s_3_abbreviation") return "Abbreviation";
            if (name == "s_4_abbreviation") return "AbbreviationGenitive";
            if (name == "s_5_subordination") return "Subordination";
            if (name == "s_6_subordination") return "SubordinationGenitive";
            if (name == "s_7_unit") return "Unit";
            if (name == "s_8_place") return "Place";
            if (name == "s_9_code") return "Code";
            if (name == "s_10_bank") return "Bank";
            if (name == "s_11_legal_address") return "LegalAddress";
            if (name == "s_12_chief_name") return "ChiefName";
            if (name == "s_13_chief_name") return "ChiefNameGenitive";
            if (name == "s_14_chief_surname") return "ChiefSurname";
            if (name == "s_15_chief_surname") return "ChiefSurnameDative";
            if (name == "s_16_chief_initials") return "ChiefInitials";
            if (name == "s_17_chief_position") return "ChiefPosition";
            if (name == "s_18_chief_position") return "ChiefPositionDative";
            if (name == "s_19_chief_position") return "ChiefPositionLower";
            if (name == "s_20_position_cadre") return "PositionCadre";
            if (name == "s_21_position_cadre") return "PositionCadreGenitive";
            if (name == "s_22_initials_cadre") return "InitialsCadre";
            if (name == "s_23_surname_cadre") return "SurnameCadre";
            if (name == "s_24_address") return "Address";
            if (name == "s_25_tel") return "Telephone";
            if (name == "s_26_fax") return "Fax";
            if (name == "s_27_e-mail") return "Email";

            return "";
        }
    }
}
