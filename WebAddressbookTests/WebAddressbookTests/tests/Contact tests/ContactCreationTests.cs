using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            //Создаем объект класса ContactData и задаем значения переменных
            ContactData contact = new ContactData("Ivan")
            {
                Title = "", Company = "", Nickname = "", Lastname = "", Middlename = "Vitalievich", 
                Work = "", Address2 = "", Bmonth = "January", Bday = "1", Photo = "", Address = "", 
                Mobile = "", Home = "", Phone2 = "", Byear = "1990", Notes = "testnotes", Email = ""
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactListCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort(); 

          //  Assert.AreEqual(oldContacts, newContacts); 
        }
    }
}
