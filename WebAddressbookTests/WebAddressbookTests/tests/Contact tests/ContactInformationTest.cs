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
            Console.Write("Expected:\n" + fromTable.AllPhones);
            Console.Write("Was:\n" + fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactView()
        {
            int contactForAssert = 0;
            
            string fromView = app.Contacts.GetContactInformationFromView(contactForAssert);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(contactForAssert);
            Console.WriteLine("Was:\n" + fromForm.AllContactInfoFromForm);
            Console.WriteLine("Expected:\n" + fromView);
            //Assert.AreEqual(fromView, fromForm.AllContactInfoFromForm);
        }
    }
}
