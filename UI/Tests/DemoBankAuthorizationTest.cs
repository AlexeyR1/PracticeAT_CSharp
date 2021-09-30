using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UI.Pages;

namespace UI.Tests
{
    public class DemoBankAuthorizationTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            _driver = new ChromeDriver(chromeOptions);
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 3));
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [TestCase("mngr356377", "demUdez", ExpectedResult = true)]
        [TestCase("someLogin", "demUdez", ExpectedResult = false)]
        [TestCase("mngr356377", "somePassword", ExpectedResult = false)]
        public bool LogIn(string login, string password)
        {
            AuthorizationPage authorizationPage = new(_driver, _wait);
            authorizationPage.GoToPage();
            authorizationPage.SetLogin(login);
            authorizationPage.SetPassword(password);
            AccountPage accountPage = authorizationPage.LogIn();
            return accountPage.IsLoaded();
        }
    }
}