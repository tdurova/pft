using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager.GetInstance();

            ApplicationManager.GetInstance().Navigator.GoToHomePage();
            ApplicationManager.GetInstance().Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }
    }
}
