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
                WorkPhone = "",
                Address2 = "",
                Bmonth = "January",
                Bday = "1",
                //пыталась прицепить картинку локальную - не получилось =(
                Photo = "",
                Address = "",
                MobilePhone = "",
                HomePhone = "",
                Phone2 = "",
                Byear = "",
                Notes = "testnotes",
                Email = ""
            };

            int contactForChange = 0;

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[contactForChange];

            app.Contacts.Modify(contactForChange, newContact);

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
