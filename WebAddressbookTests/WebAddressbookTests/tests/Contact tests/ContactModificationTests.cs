using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
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

            List<ContactData> oldContacts = app.Contact.GetContactList();
           
            app.Contact.Modify(1, newContact);


            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Title = newContact.Title;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
