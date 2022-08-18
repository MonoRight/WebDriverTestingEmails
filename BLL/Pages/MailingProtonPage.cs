using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class MailingProtonPage :BasePage
    {
        public By NickNameBy => By.XPath("//span[contains(@class, 'displayName')]");
        public IWebElement NickName => WebDriver.FindElement(NickNameBy);   

        public MailingProtonPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
