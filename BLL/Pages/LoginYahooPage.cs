using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class LoginYahooPage :BasePage
    {
        public By EmailFieldBy => By.XPath("//input[contains(@class, 'phone')]");
        public IWebElement EmailField => WebDriver.FindElement(EmailFieldBy);
        public By PasswordFieldBy => By.XPath("//input[@class='password']");
        public IWebElement PasswordField => WebDriver.FindElement(PasswordFieldBy);
        public By NextButtonBy => By.XPath("//input[contains(@id, 'login-signin')]");
        public IWebElement NextButton => WebDriver.FindElement(NextButtonBy);
        public By SignNextButtonBy => By.XPath("//button[contains(@id, 'login-signin')]");
        public IWebElement SignNextButton => WebDriver.FindElement(SignNextButtonBy);      

        public LoginYahooPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
