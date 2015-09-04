using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool _acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillNewContactForm(contact);
            SubmitNewContactCreation();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(p);
            FillNewContactForm(newContact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelelectContact(p);
            RemoveContact(p);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            if (IsElementPresent(By.LinkText("add new")))
            {
                driver.FindElement(By.LinkText("add new")).Click();
            }
            else
            {
                Assert.Fail("Не могу найти кнопку добавления нового контакта с помощью By.LinkText(\"add new\")");
            }
            return this;
        }

        public ContactHelper FillNewContactForm(ContactData contact)
        {
            if (IsElementPresent(By.Name("firstname")))
            {
                Type(By.Name("firstname"), contact.Firstname);

               /* if (IsElementPresent(By.Name("middlename")) 
                    && IsElementPresent(By.Name("lastname"))
                    && IsElementPresent(By.Name("nickname"))
                    && IsElementPresent(By.Name("photo"))
                    && IsElementPresent(By.Name("company"))
                    && IsElementPresent(By.Name("title"))
                    && IsElementPresent(By.Name("address"))
                    && IsElementPresent(By.Name("home"))
                    && IsElementPresent(By.Name("email"))
                    && IsElementPresent(By.Name("bday"))
                    && IsElementPresent(By.Name("bmonth"))
                    && IsElementPresent(By.Name("byear"))
                    && IsElementPresent(By.Name("address2"))
                    && IsElementPresent(By.Name("phone2"))
                    && IsElementPresent(By.Name("notes"))
                    )
                {
                    Type(By.Name("middlename"), contact.Middlename);
                    Type(By.Name("lastname"), contact.Lastname);
                    Type(By.Name("nickname"), contact.Nickname);
                    Type(By.Name("photo"), contact.Photo);
                    Type(By.Name("company"), contact.Company);
                    Type(By.Name("title"), contact.Title);
                    Type(By.Name("address"), contact.Address);
                    Type(By.Name("home"), contact.Home);
                    Type(By.Name("mobile"), contact.Mobile);
                    Type(By.Name("work"), contact.Work);
                    Type(By.Name("email"), contact.Email);
                    SelectElementInList(By.Name("bday"), contact.Bday);
                    SelectElementInList(By.Name("bmonth"), contact.Bmonth);
                    //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);       
                    Type(By.Name("byear"), contact.Byear);
                    Type(By.Name("address2"), contact.Address2);
                    Type(By.Name("phone2"), contact.Phone2);
                    Type(By.Name("notes"), contact.Notes);
                } */
            }

            return this;
        }

        public ContactHelper SubmitNewContactCreation()
        {
            if (IsElementPresent(By.XPath("//div[@id='content']/form/input[21]")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            }
            else
            {
                Assert.Fail("Не могу найти кнопку подтверждения создания контакта, Submit");
            }

            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            if (IsElementPresent(By.Name("update")))
            {
                driver.FindElement(By.Name("update")).Click();
            }
            else
            {
                Assert.Fail("Не могу кнопку 'Update' для обновления данных контакта.");
            }
            return this;
        }

        private ContactHelper InitContactModification(int p)
        {
            if (IsElementPresent(By.CssSelector("a[href*='edit.php?id=" + p + "']")))
            {
                driver.FindElement(By.CssSelector("a[href*='edit.php?id=" + p + "']")).Click();
            }
            else
            {
                Assert.Fail("Не могу найти контакт с id = " + p);
            }

            return this;
        }

        private ContactHelper RemoveContact(int p)
        {
            if (IsElementPresent(By.XPath("//div[@id='content']/form[2]/div[2]/input")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form[2]/div[2]/input")).Click();
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            }
            else
            {
                Assert.Fail("Не могу найти кнопку 'Delete', чтобы удалить контакт.");
            }

            return this;
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (AcceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                AcceptNextAlert = true;
            }
        }

        private void SelelectContact(int p)
        {
            if (IsElementPresent(By.XPath("//input[@name='selected[]']")) == false)
            {
                System.Console.Out.Write("Нет ни одного контакта! Начинаем создание!");

                ContactData contact = new ContactData("Ivan");
                Create(contact);

            }
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
        }

        public bool AcceptNextAlert
        {
            get { return _acceptNextAlert; }
            set { _acceptNextAlert = value; }
        }
    }
}
