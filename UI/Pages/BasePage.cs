using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Pages
{
    public abstract class BasePage
    {
        protected BasePage(IWebDriver driver, WebDriverWait wait)
        {
            Driver = driver;
            Wait = wait;
        }

        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }
    }
}
