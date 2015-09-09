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
        public void TestSearchEmptyResul()
        {
            string stringForSearch = "ThisIsBadStringForSeach";
         
            int numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);
            int contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);

            Console.WriteLine("numberOfSearchResults: " + numberOfSearchResults);
            Console.WriteLine("contactRowsFromSearch: " + contactRowsFromSearch);

            Assert.AreEqual(numberOfSearchResults, contactRowsFromSearch);
            
        }

        [Test]
        public void TestSearchGoodResult()
        {
            string stringForSearch = "rwe";

            int numberOfSearchResults = app.Contacts.GetNumberOfSearchResults(stringForSearch);
            int contactRowsFromSearch = app.Contacts.GetContactRowsFromSearch(stringForSearch);

            Console.WriteLine("numberOfSearchResults: " + numberOfSearchResults);
            Console.WriteLine("contactRowsFromSearch: " + contactRowsFromSearch);

            Assert.AreEqual(numberOfSearchResults, contactRowsFromSearch);
        }
    }
}
