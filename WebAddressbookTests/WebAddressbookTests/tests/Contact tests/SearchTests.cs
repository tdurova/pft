using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {

        [Test]
        public void TestSearchPositiveResult()
        {
            string stringForSearch = "ivan";

            int numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);
            int contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);

            Assert.AreEqual(numberOfSearchResults, contactRowsFromSearch);

            Console.WriteLine("stringForSearch: " + stringForSearch);
            Console.WriteLine("app.Contacts.GetContactInformationFromTable(): " +
                              app.Contacts.GetContactInformationFromTable(0));

            for (int i = 0; i < numberOfSearchResults; i++)
            {
                ContactData contact = app.Contacts.GetContactInformationFromTable(i);
                Assert.IsTrue(contact.ShouldBeFound(stringForSearch, i));
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
