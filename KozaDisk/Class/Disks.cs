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

            if (!Directory.Exists(Constant.ApplcationStorage + @"db\xml"))
                Directory.CreateDirectory(Constant.ApplcationStorage + @"db\xml");

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

                if (doc.DocumentElement.SelectSingleNode("/disk/relation") != null)
                {
                    string relationDiskXml = Constant.ApplcationStorage + @"db\xml\" + doc.DocumentElement.SelectSingleNode("/disk/relation").InnerText;

                    XmlDocument relationDoc = new XmlDocument();
                    relationDoc.Load(relationDiskXml.Trim());

                    Disk relationDisk = new Disk();
                    relationDisk.name = relationDoc.DocumentElement.SelectSingleNode("/disk/name").InnerText;
                    relationDisk.description = relationDoc.DocumentElement.SelectSingleNode("/disk/description").InnerText;
                    relationDisk.edition = relationDoc.DocumentElement.SelectSingleNode("/disk/edition").InnerText; ;
                    relationDisk.db = relationDoc.DocumentElement.SelectSingleNode("/disk/db").InnerText;

                    disk.relationCd = relationDisk;
                }

                disks.Add(disk);
                disk = null;
            }

            return disks;
        }
    }
}
