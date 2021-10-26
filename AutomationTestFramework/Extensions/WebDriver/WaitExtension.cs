using System;
using System.Reflection;
using AutomationTestFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTestFramework.Extensions.WebDriver
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver)
        {
            return new WebDriverWait(driver,
                TimeSpan.FromSeconds(Configuration.WebDriver.DefaultTimeout));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForClickable(this IWebDriver driver, IWebElement element)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static bool WaitForClickableIgnoreException(this IWebDriver driver, By by)
        {
            try
            {
                var fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                fluentWait.Until(webDriver =>
                {
                    try
                    {
                        driver.FindElement(by);
                    }
                    catch (Exception ex)
                    {
                        switch (ex)
                        {
                            case TargetInvocationException _:
                            case NoSuchElementException _:
                            case InvalidOperationException _:
                                return false;
                            default:
                                throw;
                        }
                    }

                    return true;
                });

                return true;
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case WebDriverTimeoutException _:
                        return false;
                    default:
                        throw;
                }
            }
        }
    }
}