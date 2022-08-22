using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace BLL.Pages
{
    public class BasePage
    {
        public IWebDriver WebDriver { get; private set; }
        public Actions Actions { get; private set; }
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Actions = new Actions(WebDriver);
        }

        public void ImplicitWait(double timeToWait)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }

        public void WaitForPageLoadComplete(double timeToWait)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeToWait)).Until(WebDriver => WebDriver.ExecuteJavaScript<string>("return document.readyState").Equals("complete"));
        }

        public void WaitForAjaxToComplete(double timeToWait)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeToWait)).Until(WebDriver => WebDriver.ExecuteJavaScript<string>("return window.jQuery != undefined && jQuery.active == 0;"));
        }

        public IWebElement WaitVisibilityOfElement(double timeToWait, By webElement)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.ElementIsVisible(webElement));
        }

        public void WaitVisibilityOfAllElementsLocatedBy(double timeToWait, By webElements)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(webElements));
        }

        public void MoveToElement(IWebElement webElement)
        {
            Actions.MoveToElement(webElement);
        }

        public void ScrollToElement(IWebElement webElement)
        {
            WebDriver.ExecuteJavaScript("arguments[0].scrollIntoView();", webElement);
        }

        public void ClickTheWebElement(IWebElement webElement)
        {
            webElement.Click();
        }

        public void ClickTheWebElementByJS(IWebElement webElement)
        {
            WebDriver.ExecuteJavaScript("arguments[0].click();", webElement);
        }

        public void EnterInput(IWebElement webElement, string message)
        {
            webElement.SendKeys(message);
        }

        public void SwitchToLastTab()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
        }

        public void SwitchToFirstTab()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }

        public void OpenNewTab()
        {
            EnterInput(WebDriver.FindElement(By.TagName("body")), Keys.Control + "t");
        }

        public void ClearWebElement(IWebElement webElement)
        {
            webElement.Clear();
        }
    }
}
