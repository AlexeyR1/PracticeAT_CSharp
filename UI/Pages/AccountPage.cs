using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Pages
{
    public class AccountPage : BasePage
    {
        private readonly By _welcomeText = By.XPath("//*[contains(text(), \"Welcome To Manager's Page of GTPL Bank\")]");

        public AccountPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public bool IsLoaded()
        {
            try
            {
                return Wait.Until(ExpectedCondition.IsElementVisible(_welcomeText)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
