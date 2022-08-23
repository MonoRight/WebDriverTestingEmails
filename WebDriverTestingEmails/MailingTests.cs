using BLL.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebDriverTestingEmails
{
    [TestFixture]
    public class MailingTests : BaseTest
    {
        #region helpFunctions
        private Random random = new Random();

        public string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        [Test]
        [TestCase(@"https://proton.me/", @"https://yahoo.com/", "testingWebDriver1@proton.me", "2022testing2022", "testingWebDriver1@yahoo.com", "2022testing2022")]
        public void TestMailingFromProtonToYahoo_MailIsSuccessfull(string urlProton, string urlYahoo, string protonEmail, string protonPassword, string yahooEmail, string yahooPassword)
        {
            SendingMailHelper sendingMailHelper = new SendingMailHelper(driver);
            string title = RandomString(10);
            string message = RandomString(20);

            (string, string) tuple = sendingMailHelper.SendMailFromProtonToYahoo(urlProton, urlYahoo, protonEmail, protonPassword, yahooEmail, yahooPassword, title, message, DEFAULT_TIMEOUT);

            Assert.AreEqual(title, tuple.Item1);
            Assert.AreEqual(message, tuple.Item2);
        }

        [Test]
        [TestCase(@"https://proton.me/", @"https://yahoo.com/", "testingWebDriver1@proton.me", "2022testing2022", "testingWebDriver1@yahoo.com", "2022testing2022")]
        public void TestMailingFromYahooToProton_MailIsSuccessfull(string urlProton, string urlYahoo, string protonEmail, string protonPassword, string yahooEmail, string yahooPassword)
        {
            SendingMailHelper sendingMailHelper = new SendingMailHelper(driver);
            string title = RandomString(10);
            string message = RandomString(20);

            (string, string) tuple = sendingMailHelper.SendMailFromYahooToProton(urlProton, urlYahoo, protonEmail, protonPassword, yahooEmail, yahooPassword, title, message, DEFAULT_TIMEOUT);

            Assert.AreEqual(title, tuple.Item1);
            Assert.IsTrue(tuple.Item2.Contains(message));
        }
    }
}
