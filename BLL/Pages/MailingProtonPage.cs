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
        public By NewMailButtonBy => By.CssSelector("button[class*='button-large']"); //CSS Selector
        public IWebElement NewMailButton => WebDriver.FindElement(NewMailButtonBy);
        public By MailingHeaderBy => By.XPath("//header[contains(@class, 'title-bar')]");
        public IWebElement MailingHeader => WebDriver.FindElement(MailingHeaderBy);
        public By EmailToInputBy => By.XPath("//input[contains(@placeholder, 'Адреса')]");
        public IWebElement EmailToInput => WebDriver.FindElement(EmailToInputBy);
        public By TitleInputBy => By.XPath("//input[contains(@placeholder, 'Тема')]");
        public IWebElement TitleInput => WebDriver.FindElement(TitleInputBy);
        public By AdditionalParametersButtonBy => By.XPath("//button[@title='Дополнительные параметры']");
        public IWebElement AdditionalParametersButton => WebDriver.FindElement(AdditionalParametersButtonBy);
        public By CommonTextSettingsBy => By.XPath("//span[contains(text(), 'Простой текст')]");
        public IWebElement CommonTextSettings => WebDriver.FindElement(CommonTextSettingsBy);     
        public By WritingAreaBy => By.XPath("//textarea[@placeholder]");
        public IWebElement WritingArea => WebDriver.FindElement(WritingAreaBy);
        public By SendMailButtonBy => By.XPath("//button[contains(@data-testid, 'send-button')]");
        public IWebElement SendMailButton => WebDriver.FindElement(SendMailButtonBy);
        public By SuccesInfoBy => By.XPath("//span[contains(text(), 'Сообщение отправлено')]");
        public IWebElement SuccesInfo => WebDriver.FindElement(SuccesInfoBy);

        
        public MailingProtonPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
