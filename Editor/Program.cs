using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Editor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string fileName = "";

            if (args != null && args.Length > 0)
            {
                fileName = args[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new DiskForm(fileName));
        }
    }
}
