using BLL.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            Thread.Sleep(25000); //because of waiting for sending mails
            mainYahooPage.ClickTheWebElement(mainYahooPage.MailButton);
            MailingYahooPage mailingYahooPage = new MailingYahooPage(webDriver);
            mailingYahooPage.WaitForPageLoadComplete(waitTime);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.SpamButtonBy);
            mailingYahooPage.ClickTheWebElement(mailingYahooPage.SavedMailButton);

            try
            {
                if (mailingYahooPage.CountOfMailsInbox.Text.Contains("1"))
                {
                    mailingYahooPage.ClickTheWebElement(mailingYahooPage.IncomeButton);
                }
            }
            catch (Exception)
            {
                mailingYahooPage.ClickTheWebElement(mailingYahooPage.SpamButton);
            }

            mailingYahooPage.ClickTheWebElement(mailingYahooPage.Mails.First());
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.TitleMailBy);
            mailingYahooPage.WaitVisibilityOfElement(waitTime, mailingYahooPage.MessageMailBy);

            return (mailingYahooPage.TitleMail.Text, mailingYahooPage.MessageMail.Text);
        }
    }
}
