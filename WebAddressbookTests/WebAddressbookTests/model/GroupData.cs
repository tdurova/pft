using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Name { set; get; }
        public string Header { set; get; }
        public string Footer { set; get; }

        public string Id { get; set; }

        //конструктор 1
        public GroupData(string name)
        {
            Name = name;
        }

        //конструктор 2
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
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

        public override string ToString()
        {
            return "name= " + Name + "\nheader= " + Header + "\nfooter= " + Footer;

        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1; //текущий объект больше
            }
            return Name.CompareTo(other.Name);
        }
    }
}
