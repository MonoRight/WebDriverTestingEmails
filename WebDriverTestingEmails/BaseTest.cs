using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTestingEmails.Driver;

namespace WebDriverTestingEmails
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected const double DEFAULT_TIMEOUT = 180;
        protected IWebDriver driver;

        [SetUp]
        public void TestsSetUp()
        {
            driver = DriverInstance.GetInstance();
        }

        [TearDown]
        public void TearDown()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
