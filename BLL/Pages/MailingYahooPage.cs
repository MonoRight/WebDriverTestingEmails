using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Pages
{
    public class MailingYahooPage : BasePage
    {
        public By SpamButtonBy => By.XPath("//a[@data-test-folder-name='Bulk']");
        public IWebElement SpamButton => WebDriver.FindElement(SpamButtonBy); //when message goes to spam
        public By SavedMailButtonBy => By.XPath("//a[@data-test-folder-name='Draft']");
        public IWebElement SavedMailButton => WebDriver.FindElement(SavedMailButtonBy); //when message goes to spam
        public By CountOfMailsInboxBy => By.XPath("//a[@data-test-folder-name='Inbox']//span[@data-test-id='displayed-count']");
        public IWebElement CountOfMailsInbox => WebDriver.FindElement(CountOfMailsInboxBy);
        

        public By IncomeButtonBy => By.XPath("//div[@data-test-folder-container='Inbox']");
        public IWebElement IncomeButton => WebDriver.FindElement(IncomeButtonBy); //when message goes to income
        public By MailsBy => By.XPath("//div[@data-test-id='senders']");
        public IList<IWebElement> Mails => WebDriver.FindElements(MailsBy);
        public By SpamMailsUnreadedBy => By.XPath("//button[@data-test-id = 'icon-btn-read']/*[local-name()='svg']");
        public IList<IWebElement> SpamMailsUnreaded => WebDriver.FindElements(SpamMailsUnreadedBy);
        public By ReceivedMailBy(string title) => By.XPath($"span[@title='{title}']");
        public IWebElement ReceivedMail(string title) => WebDriver.FindElement(ReceivedMailBy(title));
        public By TitleMailBy => By.XPath("//span[@data-test-id='message-group-subject-text']");
        public IWebElement TitleMail => WebDriver.FindElement(TitleMailBy);
        public By MessageMailBy => By.XPath("//div[@dir='ltr']");
        public IWebElement MessageMail => WebDriver.FindElement(MessageMailBy);
        public By MailsContainerBy => By.XPath("//div[@data-test-id='full-pane']");
        public IWebElement MailsContainer => WebDriver.FindElement(MailsContainerBy);

        

        public MailingYahooPage(IWebDriver webDriver) : base(webDriver) { }
    }
}
