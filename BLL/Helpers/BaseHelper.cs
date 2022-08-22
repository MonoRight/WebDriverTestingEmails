using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public abstract class BaseHelper
    {
        protected readonly IWebDriver webDriver;

        protected BaseHelper(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}
