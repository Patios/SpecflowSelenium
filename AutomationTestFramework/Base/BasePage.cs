using OpenQA.Selenium;

namespace AutomationTestFramework.Base
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}