using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        internal GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            submitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(i);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            if (IsElementPresent(By.XPath("(//input[@name='delete'])[2]")))
            {
                driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            }
            else
            {
                Assert.Fail("Не могу найти кнопку удаления группы 'Delete'");
            }
            
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.XPath("id(\"content\")/form[1]/span[" + index + "]/input[1]")) == false)
            {
                GroupData group = new GroupData("rrr");
                Create(group);
            }

           manager.Navigator.GoToGroupsPage();
           driver.FindElement(By.XPath("id(\"content\")/form[1]/span[" + index + "]/input[1]")).Click();
           return this;
        }

        public GroupHelper submitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
