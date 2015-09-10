using System;
using System.Text;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupApplicationManager()
        {
            app =   ApplicationManager.GetInstance();
        }

        public static Random Rnd = new Random();
        
        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(Rnd.NextDouble() * max); // получили число от 0 до максимального
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(Rnd.NextDouble()*223)));
            }
            return builder.ToString();
        }
    }
}
