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
                if (connection.State != System.Data.ConnectionState.Open)
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

        public int getTemplateType(string templateId)
        {
            int templateType = 1;

            string query = $"SELECT * FROM document_templates WHERE id = '{templateId}' ORDER BY position";

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    dataReader.Read();
                    templateType = Int32.Parse(dataReader["mechanic_id"].ToString());
                }
            }

            if (templateType == 2)
                return 1;
            else
                return 0;
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
                    doc.type = Int32.Parse(dataReader["mechanic_id"].ToString());
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
                        Serializer serializer = new Serializer();
                        Dictionary<System.Object, System.Object> phpFormula = (Dictionary<System.Object, System.Object>)serializer.Deserialize(markerFormula);

                        Dictionary<System.Object, System.Object> args = (Dictionary<System.Object, System.Object>)phpFormula["args"];

                        int fieldID = (Int32)args["id"];
                        string fieldName = this.getFiledName(fieldID);

                        xml += $"<marker name=\"{markerAlias}\" type=\"static\" field=\"{fieldName}\" comment=\"{markerComment}\" />";
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

        private string getFiledName(int id)
        {
            switch(id)
            {
                // organization

                case 1:
                    return "FullName";
                    break;
                case 2:
                    return "FullNameGenitive";
                    break;
                case 3:
                    return "Abbreviation";
                    break;
                case 4:
                    return "AbbreviationGenitive";
                    break;
                case 5:
                    return "Subordination";
                    break;
                case 6:
                    return "SubordinationGenitive";
                    break;
                case 7:
                    return "Place";
                    break;
                case 8:
                    return "Code";
                    break;
                case 9:
                    return "Bank";
                    break;
                case 10:
                    return "LegalAddress";
                    break;
                case 11:
                    return "ChiefName";
                    break;
                case 12:
                    return "ChiefNameGenitive";
                    break;
                case 13:
                    return "ChiefSurname";
                    break;
                case 14:
                    return "ChiefSurnameDative";
                    break;
                case 15:
                    return "ChiefInitials";
                    break;
                case 16:
                    return "ChiefPosition";
                    break;
                case 17:
                    return "ChiefPositionDative";
                    break;
                case 18:
                    return "ChiefPositionLower";
                    break;
                case 53:
                    return "Unit";
                    break;

                //hidden
                case 19:
                    return "PositionCadre";
                    break;
                case 20:
                    return "PositionCadreGenitive";
                    break;
                case 21:
                    return "InitialsCadre";
                    break;
                case 22:
                    return "SurnameCadre";
                    break;

                //chief 
                case 23:
                    return "Address";
                    break;
                case 24:
                    return "Telephone";
                    break;
                case 25:
                    return "Fax";
                    break;
                case 26:
                    return "Email";
                    break;

                //default
                default:
                    return "";
                    break;
            }
        }
    }
}
