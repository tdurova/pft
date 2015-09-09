using System;
using NUnit.Framework.Constraints;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _allContactInfoFromForm;
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public object Aday { get; set; }
        public object Amonth { get; set; }
        public object Ayear { get; set; }
        public string Address2 { get; set; }
        public string Firstname { get; set; }
        public string Id { get; set; }
        public string Fax { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public int Age { get; set; }
        public int AnniversaryAge { get; set; }

        private string _allEmails;

        public string AllEmails
        {
            get
            {
                if (_allEmails != null)
                {
                    return _allEmails;
                }
                else
                {
                    return
                        (CleanupCode(Email) + CleanupCode(Email2) + CleanupCode(Email3)).Trim();
                }
            }
            set { _allEmails = value; }
        }

        public string AllPhones
        {
            get
            {
                if (_allPhones != null)
                {
                    return _allPhones;
                }
                else
                {
                    return (CleanupCode(HomePhone) + CleanupCode(MobilePhone) + CleanupCode(WorkPhone) + CleanupCode(Phone2)).Trim();
                }
            }
            set { _allPhones = value; }
        }


        public string AllContactInfoFromForm
        {
            get
            {
                if (_allContactInfoFromForm != null)
                {
                    return _allContactInfoFromForm;
                }

                string textToreturn = this + Middlename + Lastname;

                if (Nickname != "")
                {
                    textToreturn = textToreturn + Nickname;
                }
                if (Title != "")
                {
                    textToreturn = textToreturn + Title;
                }
                if (Company != "")
                {
                    textToreturn = textToreturn + Company;
                }
                if (Address != "")
                {
                    textToreturn = textToreturn + Address;
                }
                
                // Phones
                if (HomePhone != "")
                {
                    textToreturn = textToreturn + "H:" + HomePhone;
                }
                if (MobilePhone != "")
                {
                    textToreturn = textToreturn + "M:" + MobilePhone;
                }
                if (WorkPhone != "")
                {
                    textToreturn = textToreturn + "W:" + WorkPhone;
                }
                if (Fax != "")
                {
                    textToreturn = textToreturn + "F:" + Fax;
                }

                // Emails
                if (Email != "")
                {
                    textToreturn = textToreturn + Email;
                }
                if (Email2 != "")
                {
                    textToreturn = textToreturn + Email2;
                }
                if (Email3 != "")
                {
                    textToreturn = textToreturn + Email3;
                }
                if (Homepage != "")
                {
                    textToreturn = textToreturn + "Homepage:" + Homepage;
                }
                
                // dates birth
                if (Age != 0)
                {
                    textToreturn = textToreturn + String.Format("Birthday{0}.{1}{2}({3})",Bday,Bmonth,Byear,Age);
                }
                // anniversary
                if (AnniversaryAge != 0)
                {
                    textToreturn = textToreturn + String.Format("Anniversary{0}.{1}{2}({3})", Aday, Amonth, Ayear, AnniversaryAge);
                }

                if (Address2 != "")
                {
                    textToreturn = textToreturn + Address2;
                }
                if (Phone2 != "")
                {
                    textToreturn = textToreturn + "P:" + Phone2;
                }
                if (Notes != "")
                {
                    textToreturn = textToreturn + Notes;
                }


                return textToreturn;
            }
            set { _allContactInfoFromForm = value; }
        }

        private string CleanupCode(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
        }

        //конструктор 1
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        //конструктор 2
        public ContactData(string firstname, string middlename, string lastname, string nickname, string photo,
            string company, string title, string address,
            string homePhone, string mobilePhone, string workPhone, string email, string bday, string bmonth, string byear,
            string aday, string amonth, string ayear, string address2, string phone2, string notes)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            Photo = photo;
            Company = company;
            Title = title;
            Address = address;
            HomePhone = homePhone;
            MobilePhone = mobilePhone;
            WorkPhone = workPhone;
            Email = email;
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
            Aday = aday;
            Amonth = amonth;
            Ayear = ayear;
            Address2 = address2;
            Phone2 = phone2;
            Notes = notes;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1; //текущий объект больше
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public override string ToString()
        {
            return Firstname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }
    }
}
