using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk
{
    static class Constant
    {
        public static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string OldKozaName = "RYBA";
        public static string TempIniFile = System.IO.Path.GetTempPath() + @"koza_temp.ini";
        public static string TempDocxFile = System.IO.Path.GetTempPath() + @"template.docx";
        public static string TempXmlFile = System.IO.Path.GetTempPath() + @"template.xml";
        public static string ApplcationStorage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KozaDisk\";
        public static string ApplcationPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\";

        //my documents
        public static int MyDocumentsBlockTab = 2;
        public static int MyDocumentsListTab = 3;
    }
}
