using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace WebDriverTestingEmails.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;
        private static string browser = ConfigurationManager.AppSettings["browser"];

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        break;
                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;
                    default:
                        driver = new ChromeDriver();
                        break;
                }
            }
                   
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
