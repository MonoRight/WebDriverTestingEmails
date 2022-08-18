using BLL.Pages;
using OpenQA.Selenium;
using System.Threading;

namespace BLL.Helpers
{
    public class LoginHelper
    {
        private readonly WebDriver webDriver;
        public LoginHelper(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string DoLoginYahoo(string email, string password, double waitTime)
        {
            MainYahooPage mainPage = new MainYahooPage(webDriver);
            mainPage.ClickTheWebElement(mainPage.SignInButton);
            LoginYahooPage loginYahooPage = new LoginYahooPage(webDriver);
            loginYahooPage.EnterInput(loginYahooPage.EmailField, email);
            loginYahooPage.ClickTheWebElement(loginYahooPage.NextButton);
            //Thread.Sleep(10000); //captcha problem!!!
            loginYahooPage.WaitForPageLoadComplete(waitTime);
            loginYahooPage.WaitVisibilityOfElement(waitTime, loginYahooPage.PasswordFieldBy);
            loginYahooPage.EnterInput(loginYahooPage.PasswordField, password);
            loginYahooPage.ClickTheWebElement(loginYahooPage.SignNextButton);
            loginYahooPage.WaitForPageLoadComplete(waitTime);
            mainPage = new MainYahooPage(webDriver);

            return mainPage.NickName.Text; 
        }

        public string DoLoginProton(string email, string password, double waitTime)
        {
            MainProtonPage mainPage = new MainProtonPage(webDriver);
            mainPage.ClickTheWebElement(mainPage.SignInButton);
            mainPage.WaitForPageLoadComplete(waitTime);
            LoginProtonPage loginProtonPage = new LoginProtonPage(webDriver);
            loginProtonPage.WaitVisibilityOfElement(waitTime, loginProtonPage.SignButtonBy);
            loginProtonPage.EnterInput(loginProtonPage.EmailField, email);
            loginProtonPage.EnterInput(loginProtonPage.PasswordField, password);
            loginProtonPage.ClickTheWebElement(loginProtonPage.SignButton);
            MailingProtonPage mailingProtonPage = new MailingProtonPage(webDriver);
            mailingProtonPage.WaitForPageLoadComplete(waitTime);
            mailingProtonPage.WaitVisibilityOfElement(waitTime, mailingProtonPage.NickNameBy);

            return mailingProtonPage.NickName.Text;
        }

        public string DoWrongEmailYahoo(string email, double waitTime)
        {
            MainYahooPage mainPage = new MainYahooPage(webDriver);
            mainPage.ClickTheWebElement(mainPage.SignInButton);
            LoginYahooPage loginYahooPage = new LoginYahooPage(webDriver);
            loginYahooPage.EnterInput(loginYahooPage.EmailField, email);
            loginYahooPage.ClickTheWebElement(loginYahooPage.NextButton);
            loginYahooPage.WaitVisibilityOfElement(waitTime, loginYahooPage.ErrorEmailMessageBy);

            return loginYahooPage.ErrorEmailMessage.Text;
        }

        public string DoWrongPasswordYahoo(string email, string password, double waitTime)
        {
            MainYahooPage mainPage = new MainYahooPage(webDriver);
            mainPage.ClickTheWebElement(mainPage.SignInButton);
            LoginYahooPage loginYahooPage = new LoginYahooPage(webDriver);
            loginYahooPage.EnterInput(loginYahooPage.EmailField, email);
            loginYahooPage.ClickTheWebElement(loginYahooPage.NextButton);
            loginYahooPage.WaitForPageLoadComplete(waitTime);
            loginYahooPage.WaitVisibilityOfElement(waitTime, loginYahooPage.PasswordFieldBy);
            loginYahooPage.EnterInput(loginYahooPage.PasswordField, password);
            loginYahooPage.ClickTheWebElement(loginYahooPage.SignNextButton);
            loginYahooPage.WaitForPageLoadComplete(waitTime);
            loginYahooPage.WaitVisibilityOfElement(waitTime, loginYahooPage.ErrorEmailMessageBy);

            return loginYahooPage.ErrorEmailMessage.Text;
        }
    }
}
