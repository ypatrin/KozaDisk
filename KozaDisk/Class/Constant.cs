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
        public static string ApplcationStorage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KozaDisk\";
        public static string ApplcationPath = Environment.CurrentDirectory + @"\";
    }
}
