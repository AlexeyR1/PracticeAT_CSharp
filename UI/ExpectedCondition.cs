using System;
using OpenQA.Selenium;

namespace UI
{
    public static class ExpectedCondition
    {
        public static Func<IWebDriver, IWebElement> IsElementVisible(By by)
        {
            return (driver) =>
            {
                IWebElement webElement = driver.FindElement(by);
                return webElement.Displayed ? webElement : null;
            };
        }
    }
}
