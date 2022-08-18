using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class MainProtonPage : BasePage
    {
        public By SignInButtonBy => By.XPath("//a[text()='Sign in']");
        public IWebElement SignInButton => WebDriver.FindElement(SignInButtonBy);
      

        public MainProtonPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
