using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
    static class Constant
    {
        public static string ApplcationStorage = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KozaDisk\";
        public static string ApplcationPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\";
    }
}
