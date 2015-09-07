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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            app.Contacts.Remove();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactListCount());

            List<ContactData> newComtacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newComtacts);

        }

    }
}
