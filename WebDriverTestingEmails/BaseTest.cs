using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverTestingEmails
{
    [TestFixture]
    public class BaseTest
    {
        protected const double DEFAULT_TIMEOUT = 60;
        protected WebDriver driver;

        [SetUp]
        public void TestsSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
