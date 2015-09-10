using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            int contactCountForGenerate = 5;

            for (int i = 0; i < contactCountForGenerate; i++)
            {
                // добавляем контакт с автосгенереным именем
                contacts.Add(new ContactData(GenerateRandomString(30)));
            }

            return contacts;
        }
        
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactListCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort(); 

            Assert.AreEqual(oldContacts, newContacts); 
        }
    }
}
