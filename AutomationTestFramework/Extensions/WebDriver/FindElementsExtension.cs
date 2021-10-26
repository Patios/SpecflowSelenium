using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace AutomationTestFramework.Extensions.WebDriver
{
    public static class FindElementsExtension
    {
        public static IWebElement WaitAndFind(this IWebDriver driver, By by)
        {
            driver.WaitForClickable(by);
            return driver.FindElement(by);
        }

        public static IList<IWebElement> FindElementsGraterThenZero(this IWebDriver driver, By by)
        {
            driver.Wait().Until(x => x.FindElements(by).Count > 0);
            return driver.FindElements(by);
        }

        public static IWebElement GetElementByDefineTextFromList(this IWebDriver driver, By by, string text)
        {
            driver.Wait().Until(x => x.FindElements(by).First(y => y.Text == text));
            return driver.FindElements(by).First(x => x.Text == text);
        }

        public static bool TryToFindElement(this IWebDriver driver, By by, out IWebElement element)
        {
            try
            {
                element = driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                element = null;
                return false;
            }

            return true;
        }

        public static bool IsElementVisible(this IWebDriver driver, IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static bool IsPresent(this IWebDriver driver, By by)
        {
            var isPresent = driver.FindElements(by).Count > 0;
            return isPresent;
        }
    }
}