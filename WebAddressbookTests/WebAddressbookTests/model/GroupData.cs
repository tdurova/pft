using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        //конструктор 1
        public GroupData(string name)
        {
            this.name = name;
        }

        //конструктор 2
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.name = header;
            this.name = footer;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Header
        {
            get { return header; }
            set { name = value; }
        }

        public string Footer
        {
            get { return footer; }
            set { name = value; }
        }
    }
}
