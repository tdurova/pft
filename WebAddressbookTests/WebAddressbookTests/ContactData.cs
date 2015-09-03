using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string photo = "";
        private string company = "";
        private string title = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string email = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
       
        //конструктор 1
        public ContactData(string firstname)
        {
            Work = "";
            this.Firstname = firstname;
        }

        //конструктор 2
        public ContactData(string firstname, string middlename, string lastname, string nickname, string photo, string company, string title, string address, 
            string home, string mobile, string work, string email, string bday, string bmonth, string byear, string address2, string phone2, string notes)
        {
            this.Firstname = firstname;
            this.Middlename = middlename;
            this.Lastname = lastname;
            this.Nickname = nickname;
            this.Photo = photo;
            this.Company = company;
            this.Title = title;
            this.Address = address;
            this.Home = home;
            this.Mobile = mobile;
            this.Work = work;
            this.Email = email;
            this.Bday = bday;
            this.Bmonth = bmonth;
            this.Byear = byear;
            this.Address2 = address2;
            this.Phone2 = phone2;
            this.Notes = notes;
        }

        public string Firstname { get; set; }

        //оставила в "в старом стиле" с дополнительным полем middlename, но можно и автопроперти { get; set; } использовать
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Email {get;set;}
        public string Bday {get;set;}    
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

    }
}
