using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Pages
{
    public class AuthorizationPage : BasePage
    {
        private readonly By _login = By.XPath("//*[@id='message23']/.//preceding-sibling::input");
        private readonly By _password = By.XPath("//*[@id='message18']/.//preceding-sibling::input");
        private readonly By _logInButton = By.XPath("//*[@name='btnLogin']");

        private readonly string _url = "http://demo.guru99.com/V1/index.php";

        public AuthorizationPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public void GoToPage() => Driver.Navigate().GoToUrl(_url);

        public void SetLogin(string text)
        {
            IWebElement login = Wait.Until(ExpectedCondition.IsElementVisible(_login));
            login.SendKeys(text);
        }

        public void SetPassword(string text)
        {
            IWebElement password = Wait.Until(ExpectedCondition.IsElementVisible(_password));
            password.SendKeys(text);
        }

        public AccountPage LogIn()
        {
            IWebElement logInButton = Wait.Until(ExpectedCondition.IsElementVisible(_logInButton));
            logInButton.Click();
            return new AccountPage(Driver, Wait);
        }
    }
}
