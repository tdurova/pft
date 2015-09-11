using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList(true);
            ContactData oldContact = oldContacts[0];
            app.Contacts.Remove();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactListCount());

            List<ContactData> newContacts = app.Contacts.GetContactList(true);

            foreach (ContactData group in newContacts)
            {
                Assert.AreNotEqual(group.Id, oldContact.Id);
            } 
            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
       }
    }
}
