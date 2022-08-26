using BLL.Helpers;
using NUnit.Framework;
using System.Configuration;

namespace WebDriverTestingEmails
{
    [TestFixture]
    public class LoginTests : BaseTest
    {  
        [Test]
        [TestCase(@"https://yahoo.com/", "testingWebDriver1@yahoo.com", "2022testing2022", "Kylie")]
        public void TestSignInYahoo_WithCorrectEmailAndPassword_SignedIn(string url, string email, string password, string nickName)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualString = loginHelper.DoLoginYahoo(email, password, DEFAULT_TIMEOUT);

            Assert.AreEqual(nickName, actualString);
        }

        [Test]
        [TestCase(@"https://proton.me/", "testingWebDriver1@proton.me", "2022testing2022", "testingWebDriver1")]
        public void TestSignInProton_WithCorrectEmailAndPassword_SignedIn(string url, string email, string password, string nickName)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualString = loginHelper.DoLoginProton(email, password, DEFAULT_TIMEOUT);

            Assert.AreEqual(nickName, actualString);
        }

        [Test]
        [TestCase(@"https://yahoo.com/", "testingWebDriver12@yahoo.com", "Sorry, we don't recognize this email.")]
        public void TestSignInYahoo_WithIncorrectEmail_WarningMessageDisplayed(string url, string email, string errorMsg)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualError = loginHelper.DoWrongEmailYahoo(email, DEFAULT_TIMEOUT);

            Assert.AreEqual(errorMsg, actualError);
        }

        [Test]
        [TestCase(@"https://yahoo.com/", "testingWebDriver1@yahoo.com", "123123123", "Invalid password. Please try again")]
        public void TestSignInYahoo_WithCorrectEmailAndIncorrectPassword_WarningMessageDisplayed(string url, string email, string password, string errorMsg)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualError = loginHelper.DoWrongPasswordYahoo(email, password, DEFAULT_TIMEOUT);

            Assert.AreEqual(errorMsg, actualError);
        }

        [Test]
        [TestCase(@"https://proton.me/", "testingWebDriver12@proton.me", "2022testing2022", "Incorrect login credentials. Please try again")]
        [TestCase(@"https://proton.me/", "testingWebDriver12@proton.me", "123123123", "Incorrect login credentials. Please try again")]
        [TestCase(@"https://proton.me/", "testingWebDriver1@proton.me", "123123123", "Incorrect login credentials. Please try again")]
        public void TestSignInProton_WithInCorrectEmailAndOrPassword_WarningMessageDisplayed(string url, string email, string password, string errorMsg)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualError = loginHelper.DoWrongLoginProton(email, password, DEFAULT_TIMEOUT);

            Assert.AreEqual(errorMsg, actualError);
        }
    }
}