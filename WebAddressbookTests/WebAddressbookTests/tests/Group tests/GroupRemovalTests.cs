using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupListCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldData.Id);
            }

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
