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
            List<ContactData> oldContacts = app.Contact.GetContactList();
            
            app.Contact.Remove();

            List<ContactData> newComtacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newComtacts);

        }

    }
}
