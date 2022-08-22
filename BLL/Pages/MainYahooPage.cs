using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class MainYahooPage : BasePage
    {
        public By SignInButtonBy => By.XPath("//a[contains(@data-ylk, 'signin')]");
        public IWebElement SignInButton => WebDriver.FindElement(SignInButtonBy);
        public By MailButtonBy => By.XPath("//a[@id='ybarMailLink']");
        public IWebElement MailButton => WebDriver.FindElement(MailButtonBy);
        public By NickNameBy => By.XPath("//span[@role='presentation']");
        public IWebElement NickName => WebDriver.FindElement(NickNameBy);

       

        public MainYahooPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
