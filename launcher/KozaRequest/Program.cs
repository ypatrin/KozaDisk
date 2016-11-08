using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Text;
using System.Security.Cryptography;

namespace KozaRequest
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ManagementObjectSearcher searcher;

            string pc_codes = "";
            string pc_id = "";
            string sURL = "http://mcfr.ua/index/koza/?pcid=";

            //gen PC id

            try
            {
                //процессор
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject queryObj in searcher.Get()) pc_codes += "processor:"+queryObj["ProcessorId"].ToString()+";";

                //мать
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM CIM_Card");
                foreach (ManagementObject queryObj in searcher.Get()) pc_codes += "mainboard:" + queryObj["SerialNumber"].ToString()+";";

                //UUID
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT UUID FROM Win32_ComputerSystemProduct");
                foreach (ManagementObject queryObj in searcher.Get()) pc_codes += "UUID:"+queryObj["UUID"].ToString()+";";

                pc_id = Base64Encode(pc_codes);
                sURL += pc_id;
            }
            catch(Exception e) { }

            try
            {
                WebRequest wrGETURL = WebRequest.Create(sURL);
                Stream objStream = objStream = wrGETURL.GetResponse().GetResponseStream();

                run();
            }
            catch(Exception e)
            {
                run();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        static void run()
        {
            //copy Koza folder
            string md = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//путь к Документам
            if (Directory.Exists(md + @"\RYBA\koza") == true && Directory.Exists(md + @"\RYBA\app") == false)
            {
                CopyDir(md + @"\RYBA\koza", md + @"\RYBA\app");
            }

            //run application
            string kozaFile = AppDomain.CurrentDomain.BaseDirectory + @"app.exe";
            Process.Start(kozaFile);
        }

        static void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

    }
}
