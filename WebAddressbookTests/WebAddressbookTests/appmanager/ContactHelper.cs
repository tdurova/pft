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
            initContactModification();
            FillNewContactForm(newContact);
            submitContactModification();
            return this;
        }

        public ContactHelper Remove(string p)
        {
            manager.Navigator.GoToHomePage();
            SelelectContact(p);
            RemoveContact(p);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillNewContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
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
            return this;
        }

        public ContactHelper SubmitNewContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        private ContactHelper submitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper initContactModification()
        {
            driver.FindElement(By.XPath("id(\"maintable\")/tbody[1]/tr[7]/td[8]/a[1]/img[1]")).Click();
            return this;
        }

        private ContactHelper RemoveContact(string p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/div[2]/input")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
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

        private void SelelectContact(string p)
        {
            driver.FindElement(By.Id(p)).Click();
        }

        public bool AcceptNextAlert
        {
            get { return _acceptNextAlert; }
            set { _acceptNextAlert = value; }
        }
    }
}
