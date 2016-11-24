using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace templates
{
    class ChartRecord
    {
        int id, val;
        string name;

        public ChartRecord(int id, int val, string name)
        {
            this.id = id;
            this.val = val;
            this.name = name;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Val
        {
            get { return val; }
            set { val = value; }
        }
    }
}
