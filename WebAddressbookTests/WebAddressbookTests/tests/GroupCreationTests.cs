using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("aaa");
            group.Header = "aaa";
            group.Footer = "fff";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
        }
    }
}
