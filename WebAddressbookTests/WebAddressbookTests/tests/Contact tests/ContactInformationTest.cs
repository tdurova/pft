using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            int contactForAssert = 0;

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(contactForAssert);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(contactForAssert);

            //verifications
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactView()
        {
            int contactForAssert = 0;
            
            string fromView = app.Contacts.GetContactInformationFromView(contactForAssert);
            string replaceWith = "";
            fromView = fromView.Replace("\r\n", "").Replace("\n", replaceWith).Replace("\r", replaceWith).Replace(" ", replaceWith);
           // fromView = fromView.trim();

            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(contactForAssert);
            string stringFromForm = fromForm.AllContactInfoFromForm;
            stringFromForm = stringFromForm.Replace("\r\n", "").Replace("\n", replaceWith).Replace("\r", replaceWith).Replace(" ", replaceWith);
            //stringFromForm = stringFromForm.trim();

            Console.WriteLine("Expected:\n" + fromView);
            Console.WriteLine("Was:\n" + fromForm.AllContactInfoFromForm);
            Assert.AreEqual(fromView, stringFromForm);
        }
    }
}
