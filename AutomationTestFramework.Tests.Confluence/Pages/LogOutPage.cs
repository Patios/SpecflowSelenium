using AutomationTestFramework.Base;
using AutomationTestFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace AutomationTestFramework.Tests.Confluence.Pages
{
    public class LogOutPage : BasePage
    {
        public LogOutPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogInToAnotherAccountElement =>
            Driver.WaitAndFind(By.XPath("//*[contains(text(),'Log in to another account')]"));

        private IWebElement RedirectToLogoutElement => Driver.WaitAndFind(By.Id("redirect-to-logout"));


        public LogOutPage LoginToAnotherAccount()
        {
            Driver.ClickOnElement(LogInToAnotherAccountElement);
            return this;
        }

        public LoginFormPage RedirectToLogout()
        {
            Driver.ClickOnElement(RedirectToLogoutElement);
            return new LoginFormPage(Driver);
        }
    }
}