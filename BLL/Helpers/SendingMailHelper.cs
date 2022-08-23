using BLL.Pages;
using OpenQA.Selenium;
using System.Linq;

namespace BLL.Helpers
{
    public class SendingMailHelper : BaseHelper
    {
        public SendingMailHelper(IWebDriver webDriver) : base(webDriver) { }

        public (string, string) SendMailFromProtonToYahoo(string urlProton, string urlYahoo, string protonEmail, string protonPassword, string yahooEmail, string yahooPassword, string title, string message, double waitTime)
        {
            webDriver.Navigate().GoToUrl(urlProton);
            LoginHelper loginHelper = new LoginHelper(webDriver);
            loginHelper.DoLoginProton(protonEmail, protonPassword, waitTime);
            MailingProtonPage mailingProtonPage = new MailingProtonPage(webDriver);
            mailingProtonPage.WaitForPageLoadComplete(waitTime);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.NewMailButton);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.MailingHeaderBy);
            mailingProtonPage.EnterInput(mailingProtonPage.EmailToInput, yahooEmail);
            mailingProtonPage.EnterInput(mailingProtonPage.TitleInput, title);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.AdditionalParametersButton);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.CommonTextSettingsBy);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.CommonTextSettings);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.WritingAreaBy);
            mailingProtonPage.ClearWebElement(mailingProtonPage.WritingArea);
            mailingProtonPage.EnterInput(mailingProtonPage.WritingArea, message);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.SendMailButton);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.SuccesInfoBy);
            mailingProtonPage.OpenNewTab();
            mailingProtonPage.SwitchToLastTab();
            webDriver.Navigate().GoToUrl(urlYahoo);
            loginHelper.DoLoginYahoo(yahooEmail, yahooPassword, waitTime);
            MainYahooPage mainYahooPage = new MainYahooPage(webDriver);
            mainYahooPage.ClickTheWebElement(mainYahooPage.MailButton);
            MailingYahooPage mailingYahooPage = new MailingYahooPage(webDriver);
            mailingYahooPage.WaitForPageLoadComplete(waitTime);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.SavedMailButtonBy);
            mailingYahooPage.ClickTheWebElement(mailingYahooPage.SavedMailButton);

            try
            {
                mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.CountOfMailsInboxBy);
                webDriver.Navigate().Refresh();
                if (mailingYahooPage.CountOfMailsInbox.Text.Contains("1"))
                {
                    mailingYahooPage.ClickTheWebElement(mailingYahooPage.IncomeButton);
                }
            }
            catch (NoSuchElementException)
            {
                webDriver.Navigate().Refresh();
                mailingYahooPage.ClickTheWebElement(mailingYahooPage.SpamButton);
            }

            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.MailsContainerBy);
            mailingYahooPage.ImplicitWait(waitTime);
            mailingYahooPage.ClickTheWebElement(mailingYahooPage.Mails.First());
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.TitleMailBy);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.MessageMailBy);

            return (mailingYahooPage.TitleMail.Text, mailingYahooPage.MessageMail.Text);
        }

        public (string, string) SendMailFromYahooToProton(string urlProton, string urlYahoo, string protonEmail, string protonPassword, string yahooEmail, string yahooPassword, string title, string message, double waitTime)
        {
            webDriver.Navigate().GoToUrl(urlYahoo);
            LoginHelper loginHelper = new LoginHelper(webDriver);
            loginHelper.DoLoginYahoo(yahooEmail, yahooPassword, waitTime);
            MainYahooPage mainYahooPage = new MainYahooPage(webDriver);
            mainYahooPage.ClickTheWebElement(mainYahooPage.MailButton);
            MailingYahooPage mailingYahooPage = new MailingYahooPage(webDriver);
            mailingYahooPage.WaitForPageLoadComplete(waitTime);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.SavedMailButtonBy);
            mailingYahooPage.ClickTheWebElement(mailingYahooPage.CreateMessage);
            mailingYahooPage.EnterInput(mailingYahooPage.SendMailTo, protonEmail);
            mailingYahooPage.EnterInput(mailingYahooPage.TitleInput, title);
            mailingYahooPage.EnterInput(mailingYahooPage.MessageInput, message);
            mailingYahooPage.ClickTheWebElement(mailingYahooPage.SendMailButton);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.SuccessSendingMessageBy);
            mailingYahooPage.OpenNewTab();
            mailingYahooPage.SwitchToLastTab();
            webDriver.Navigate().GoToUrl(urlProton);
            loginHelper.DoLoginProton(protonEmail, protonPassword, waitTime);
            MailingProtonPage mailingProtonPage = new MailingProtonPage(webDriver);
            mailingProtonPage.WaitForPageLoadComplete(waitTime);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.CountOfNewMailsBy);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.ReceivedMails.First());
            //mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.MailInfoContainerBy);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.SelectionButtonBy);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.SelectionButton);
            mailingProtonPage.ClickTheWebElement(mailingProtonPage.SelectionHtmlViewButton);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.ReceivedMailMessageBy);
            
            return (mailingProtonPage.ReceivedMailTitle.Text, mailingProtonPage.ReceivedMailMessage.Text);
        }
    }
}
