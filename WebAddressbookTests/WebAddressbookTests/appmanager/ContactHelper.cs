using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        
        private bool _acceptNextAlert = true;
        
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

        public ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            SelelectContact();
            RemoveContact();
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
                _contactCash = null;
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
                _contactCash = null;
            }
            else
            {
                Assert.Fail("Не могу кнопку 'Update' для обновления данных контакта.");
            }
            return this;
        }


        private ContactHelper RemoveContact()
        {
            if (IsElementPresent(By.XPath("//div[@id='content']/form[2]/div[2]/input")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form[2]/div[2]/input")).Click();
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
                _contactCash = null;
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

        private ContactHelper SelelectContact()
        {
            if (IsElementPresent(By.XPath("//input[@name='selected[]']")) == false)
            {
                Console.Out.Write("Нет ни одного контакта! Начинаем создание!");
                ContactData contact = new ContactData("Ivan");
                Create(contact);
            }
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int p)
        {
            if (IsElementPresent(By.XPath("//tr[@name='entry']//img[@alt='Edit']")) == false)
            {
                Console.Out.Write("Нет ни одного контакта! Начинаем создание!");
                ContactData contact = new ContactData("Ivan");
                Create(contact);
            }
            manager.Navigator.GoToHomePage();

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(
                ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[@name='entry']//img[@alt='Edit']")));
            
            driver.FindElements(By.XPath("//tr[@name='entry']//img[@alt='Edit']"))[p].Click();
            return this;
        }

        public bool AcceptNextAlert
        {
            get { return _acceptNextAlert; }
            set { _acceptNextAlert = value; }
        }

        private List<ContactData> _contactCash = null;
        
        public List<ContactData> GetContactList(bool displayedOnly = false)
        {
                if (_contactCash == null)
            {
                _contactCash = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement element in elements.Where(D => (D.Displayed || !displayedOnly)))
                {
                        List<IWebElement> cells = new List<IWebElement>(element.FindElements(By.TagName("td")));

                      //  _contactCash.Add(new ContactData(cells[2].Text)
                        _contactCash.Add(new ContactData()
                        {
                            Firstname = cells[2].Text,
                            Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                        });                                 
                }
            }
            
            return _contactCash;
        }

        public int GetContactListCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPrhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.XPath("//select[@name='bday']//option[@selected='selected']")).Text;
            string bmonth = driver.FindElement(By.XPath("//select[@name='bmonth']//option[@selected='selected']")).Text;
            string byear = driver.FindElement(By.XPath("//input[@name='byear']")).GetAttribute("value");

            string aday = driver.FindElement(By.XPath("//select[@name='aday']//option[@selected='selected']")).Text;
            string amonth = driver.FindElement(By.XPath("//select[@name='amonth']//option[@selected='selected']")).Text;
            string ayear = driver.FindElement(By.XPath("//input[@name='ayear']")).GetAttribute("value");
            
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            int age = GetYearsDiffers(String.Format("{0}.{1}.{2}",bday,bmonth,byear));
            int anniversaryAge = GetYearsDiffers(String.Format("{0}.{1}.{2}", aday, amonth, ayear));
            
            return new ContactData(firstName)
            {
                Middlename = middlename,
                Lastname = lastName,
                Nickname = nickname,
                Title = title,
                Company = company,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPrhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes,
                Age = age,
                AnniversaryAge = anniversaryAge
            };
        }

        private int GetYearsDiffers(string date)
        {
            DateTime now = DateTime.Now;
            if (date != null && date != "-.-." && date != "")
            {
                DateTime dateTime = Convert.ToDateTime(date);
                if (dateTime > now)
                {
                    Assert.Fail("Человек еще не родился! " + dateTime + " > " + now);
                }
                else
                    return new DateTime((now - dateTime).Ticks).Year - 1;
            }
            return 0;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.XPath("//tr[@name='entry']"))[index].
                FindElements(By.TagName("td"));

            /*
             
                      ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                               
                foreach (IWebElement element in elements.Where(D => D.Displayed))
                {
                        List<IWebElement> cells = new List<IWebElement>(element.FindElements(By.TagName("td")));

                        _contactCash.Add(new ContactData(cells[2].Text)
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                        });                                 
                }
             
             */

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allemails = cells[4].Text;
            string allPhones = cells[5].Text;
            
            return new ContactData(firstName)
            {
                Lastname = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allemails
            };
        }

        public string GetContactInformationFromView(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactView(index);
            string contactViewInfo = driver.FindElement(By.XPath("id('content')")).Text;

            return contactViewInfo;
        }

        public ContactHelper OpenContactView(int index)
        {
            Type(By.XPath("//input[@name='searchstring']"), ""); // очистим строку для поиска, чтобы увидеть все контакты
            if (IsElementPresent(By.XPath("//tr[@name='entry']//img[@alt='Details']")) == false)
            {
                Console.Out.Write("Нет ни одного контакта! Начинаем создание!");
                ContactData contact = new ContactData("Ivan");
                Create(contact);
            }
            manager.Navigator.GoToHomePage();
            driver.FindElements(By.XPath("//tr[@name='entry']//img[@alt='Details']"))[index].Click();
            return this;
        }

        public int GetNumberOfSearchResults(string stringForSearch)
        {
            manager.Navigator.GoToHomePage();

            Type(By.XPath("//input[@name='searchstring']"), stringForSearch);
            if (IsElementPresent(By.XPath("//tr[@name='entry']//img[@alt='Edit']")) == false)
            {
                Console.Out.Write("Нет ни одного контакта! Начинаем создание с подходящим именем " + stringForSearch);
                ContactData contact = new ContactData(stringForSearch);
                Create(contact);
                manager.Navigator.GoToHomePage();
            }

            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public int GetContactRowsFromSearch(string stringForSearch)
        {
            manager.Navigator.GoToHomePage();
            Type(By.XPath("//input[@name='searchstring']"), stringForSearch);
            if (IsElementPresent(By.XPath("//tr[@name='entry']//img[@alt='Edit']")) == false)
            {
                Console.Out.Write("Нет ни одного контакта! Начинаем создание с подходящим именем " + stringForSearch);
                ContactData contact = new ContactData(stringForSearch);
                Create(contact);
                manager.Navigator.GoToHomePage();
            }

            int rowCount = driver.FindElements(By.XPath("//tr[@name='entry']")).Count - 
                driver.FindElements(By.XPath("//tr[@name='entry'][@style='display: none;']")).Count;
            return rowCount;
        }
    }
}
