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
            System.Console.Write("myOutput:" + fromTable.AllPhones);
        }

        [Test]
        public void TestContactView()
        {
            int contactForAssert = 0;
            
            string fromView = app.Contacts.GetContactInformationFromView(contactForAssert);
            Console.WriteLine("string fromView:\n" + fromView);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(contactForAssert);
            Console.WriteLine("fromForm.AllContactInfoFromForm:\n" + fromForm.AllContactInfoFromForm);
            Assert.AreEqual(fromView, fromForm.AllContactInfoFromForm);
        }
    }
}
