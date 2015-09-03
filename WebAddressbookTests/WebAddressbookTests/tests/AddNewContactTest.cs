using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContactCreationTest : TestBase
    {
        [Test]
        public void AddNewContactTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret")); 
            
            //Создаем объект класса ContactData и задаем значения переменных
            ContactData contact = new ContactData("Ivan")
            {
                Title = "",
                Company = "",
                Nickname = "",
                Lastname = "",
                Middlename = "Vitalievich",
                Work = "",
                Address2 = "",
                Bmonth = "January",
                Bday = "1",
                //пыталась прицепить картинку локальную - не получилось =(
                Photo = "",
                Address = "",
                Mobile = "",
                Home = "",
                Phone2 = "",
                Byear = "1990",
                Notes = "testnotes",
                Email = ""
            };

            app.Contact
                .InitContactCreation()
                .FillNewContactForm(contact)
                .SubmitNewContactCreation();
        }
    }
}
