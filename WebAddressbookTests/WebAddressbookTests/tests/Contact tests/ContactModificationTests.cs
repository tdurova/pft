using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Vasya2")
            {
                Title = "myNewTitle",
                Company = "",
                Nickname = "",
                Lastname = "",
                Middlename = "Vitalievich",
                Work = "",
                Address2 = "",
                Bmonth = "January",
                Bday = "1",
                //пыталась прицепить картинку локальную - не получилось =(
                Photo = "",
                Address = "",
                Mobile = "",
                Home = "",
                Phone2 = "",
                Byear = "",
                Notes = "testnotes",
                Email = ""
            };

            app.Contact.Modify(12, newContact);
        }
    }
}
