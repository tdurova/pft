using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        // Внимание, тест написан давно, и если ни одной группы нет то он падает, надо предварительно создать хотя бы одну группу. 
        // В тесте автоматическое создание не реализовано!
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldGroup = oldGroups[0];

            // выбираем группу с порядковым номером 1
            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupListCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroup.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroup.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
