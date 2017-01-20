using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace KozaDisk
{
    class Disks
    {
        public List<Disk> getDisksList()
        {
            List<Disk> disks = new List<Disk>();
            String[] disksXml = Directory.GetFiles(Constant.ApplcationStorage + @"db\xml");

            foreach (string diskXml in disksXml)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(diskXml.Trim());

                Disk disk = new Disk();

                disk.name = doc.DocumentElement.SelectSingleNode("/disk/name").InnerText;
                disk.description = doc.DocumentElement.SelectSingleNode("/disk/description").InnerText;
                disk.edition = doc.DocumentElement.SelectSingleNode("/disk/edition").InnerText; ;
                disk.db = doc.DocumentElement.SelectSingleNode("/disk/db").InnerText;

                disks.Add(disk);
                disk = null;
            }

            return disks;
        }
    }
}
