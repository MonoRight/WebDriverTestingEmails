using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class LoginProtonPage : BasePage
    {
        public By EmailFieldBy => By.XPath("//label[@for='username']//input");
        public IWebElement EmailField => WebDriver.FindElement(EmailFieldBy);
        public By PasswordFieldBy => By.XPath("//label[@for='password']//input");
        public IWebElement PasswordField => WebDriver.FindElement(PasswordFieldBy);
        public By SignButtonBy => By.XPath("//button[text()='Sign in']");
        public IWebElement SignButton => WebDriver.FindElement(SignButtonBy);
        
        public LoginProtonPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
