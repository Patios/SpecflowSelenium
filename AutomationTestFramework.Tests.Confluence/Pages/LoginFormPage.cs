using AutomationTestFramework.Base;
using AutomationTestFramework.Extensions.WebDriver;
using AutomationTestFramework.Tests.Confluence.Providers;
using OpenQA.Selenium;

namespace AutomationTestFramework.Tests.Confluence.Pages
{
    public class LoginFormPage : BasePage
    {
        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameField => Driver.WaitAndFind(By.CssSelector("#username"));
        private IWebElement PasswordField => Driver.WaitAndFind(By.CssSelector("#password"));
        private IWebElement LoginButton => Driver.WaitAndFind(By.Id("login-submit"));

        public LoginFormPage Go()
        {
            Driver.Navigate().GoToUrl(UrlProvider.Login);
            return this;
        }

        public LoginFormPage FillLoginForm(string login)
        {
            Driver.SendKeysWithWait(UsernameField, login);
            Driver.ClickOnElement(LoginButton);
            return this;
        }

        public LoginFormPage FillPasswordForm(string password)
        {
            Driver.SendKeysWithWait(PasswordField, password);
            return this;
        }

        public SecureAreaPage Submit()
        {
            Driver.ClickOnElement(LoginButton);
            return new SecureAreaPage(Driver);
        }
    }
}