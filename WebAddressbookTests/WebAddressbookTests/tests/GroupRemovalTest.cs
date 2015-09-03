using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {        
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
    }
    
}
