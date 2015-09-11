using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearchPositiveResult()
        {
            string stringForSearch = "Vasya";

            int numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);

            /*если не найден ни один нужный нам контакт, то начнем модификацию существующего 
             так как это всегда позитивный тест*/

            if (numberOfSearchResults < 1)
            {
                app.Contacts.Type(By.XPath("//input[@name='searchstring']"), " ");

                WebDriverWait wait = new WebDriverWait(app.Driver, new TimeSpan(0, 0, 5));
                wait.Until(
                    ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[@name='entry']//img[@alt='Edit']")));

                ContactData contact = new ContactData(stringForSearch);
                app.Contacts.Modify(0, contact);
                
                numberOfSearchResults = 1;
            }

            int contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);

            Assert.AreEqual(numberOfSearchResults, contactRowsFromSearch);

            Console.WriteLine("stringForSearch: " + stringForSearch);
            Console.WriteLine("app.Contacts.GetContactInformationFromTable(): " +
                              app.Contacts.GetContactInformationFromTable(0));

            List <ContactData> contactList = app.Contacts.GetContactList(true);
            
            Assert.IsNotNull(contactList);
            var i = 0;
            foreach (var contact in contactList)
            {
                if (contact.ShouldBeFound(stringForSearch, contact.Id))
                {
                    i++;
                }
            }
        }
        
        
        [Test]
        public void TestSearchNegativeResult()
        {
            string stringForSearch = "ThisIsBadStringForSeach";

            int numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);
            int contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);

            if (numberOfSearchResults > 0 || contactRowsFromSearch > 0)
            {
                Console.WriteLine("Тест стал позитивным, найдены совпадения при поиске! (хотя мы делали негативную проверку!)");
                Console.WriteLine("изменим строку для поиска!)");
                stringForSearch = "~``~Ё";
                numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);
                contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);
            }

            Console.WriteLine("numberOfSearchResults: " + numberOfSearchResults);
            Console.WriteLine("contactRowsFromSearch: " + contactRowsFromSearch);

            Assert.AreEqual(numberOfSearchResults, contactRowsFromSearch);
            
        }
    }
}
