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

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[0];
           
            app.Contacts.Modify(1, newContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactListCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContact.Firstname = newContact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                }
            }

        }
    }
}
