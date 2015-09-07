using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        //конструктор 1
        public GroupData(string name)
        {
            this.name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
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
