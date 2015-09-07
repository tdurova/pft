using System.Collections.Generic;
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
            _groupCash = null;
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
                _groupCash = null;
            }
            else
            {
                Assert.Fail("Не могу найти КНОПКУ удаления группы 'Delete'");
            }
            
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.XPath("id(\"content\")/form[1]/span[" + (index+1) + "]/input[1]")) == false)
            {
                GroupData group = new GroupData("rrr");
                Create(group);
            }

           manager.Navigator.GoToGroupsPage();
           driver.FindElement(By.XPath("id(\"content\")/form[1]/span[" + (index+1) + "]/input[1]")).Click();
           return this;
        }

        public GroupHelper submitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            _groupCash = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }


        private List<GroupData> _groupCash = null;
        
        public List<GroupData> GetGroupList()
        {
            if (_groupCash == null)
            {
                _groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    _groupCash.Add(new GroupData(element.Text));
                }
            }

            //отдаем не сам кэш, а только его копию, чтобы никто не повредил оригинал
            return new List<GroupData>(_groupCash);
        }

        public int GetGroupListCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count; 
        }
    }
}
