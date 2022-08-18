using BLL.Helpers;
using NUnit.Framework;

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

            string actualString = loginHelper.DoWrongEmailYahoo(email, DEFAULT_TIMEOUT);

            Assert.AreEqual(errorMsg, actualString);
        }

        [Test]
        [TestCase(@"https://yahoo.com/", "testingWebDriver1@yahoo.com", "123123123", "Invalid password. Please try again")]
        public void TestSignInYahoo_WithCorrectEmailAndIncorrectPassword_WarningMessageDisplayed(string url, string email, string password, string errorMsg)
        {
            driver.Url = url;
            LoginHelper loginHelper = new LoginHelper(driver);

            string actualString = loginHelper.DoWrongPasswordYahoo(email, password, DEFAULT_TIMEOUT);

            Assert.AreEqual(errorMsg, actualString);
        }
    }
}