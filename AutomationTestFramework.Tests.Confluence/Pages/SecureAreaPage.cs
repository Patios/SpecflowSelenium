using System.Collections.Generic;
using System.Linq;
using AutomationTestFramework.Base;
using AutomationTestFramework.Extensions.WebDriver;
using AutomationTestFramework.Tests.Confluence.Extensions;
using OpenQA.Selenium;

namespace AutomationTestFramework.Tests.Confluence.Pages
{
    public class SecureAreaPage : BasePage
    {
        private const string PageListXpath = "//*[@id=\"AkSideNavigation\"]//*[contains(text(),'QA Workshop - ')]";
        private const string YourDashboardCSS = "#main > ul:nth-child(11) > li:nth-child(2) > a";

        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogoutMenu => Driver.WaitAndFind(By.XPath("//*[@class='css-1ujqpe8']/div"));

        private IWebElement LogoutButton => Driver.WaitAndFind(
            By.XPath("//*[@id=\"com-atlassian-confluence\"]/div[2]/div[3]/div/div/div/div/div[3]/a/div/span/span"));

        private IWebElement SuccessMessageElement =>
            Driver.WaitAndFind(
                By.XPath("//*[@data-testid=\"space-tiles-container\"]//*[contains(text(),'QA Workshop')]"));

        private IWebElement RestrictionsElement =>
            Driver.WaitAndFind(By.CssSelector("#system-content-items-extracted"));

        private IList<IWebElement> PagesList => Driver.FindElementsGraterThenZero(By.XPath(PageListXpath));


        private IWebElement RestrictionsMenuElement => Driver.WaitAndFind(By.XPath(
            "//*[@id=\"com-atlassian-confluence\"]//*[contains(text(),'Only specific people can view or edit')]"));

        private IWebElement CloseRestrictionsMenuButton =>
            Driver.WaitAndFind(
                By.XPath("//*[@data-test-id=\"restrictions-dialog-footer\"]//*[contains(text(),'Cancel')]"));

        public string SuccessMessage => SuccessMessageElement.GetAttribute("innerText").RemoveNewLines();
        public string RestrictedPageMessage => RestrictionsMenuElement.GetAttribute("innerText").RemoveNewLines();

        public LogOutPage Logout()
        {
            Driver.MoveToElement(LogoutMenu);
            Driver.ClickOnElement(LogoutMenu);
            Driver.MoveToElement(LogoutButton);
            Driver.ClickOnElement(LogoutButton);
            return new LogOutPage(Driver);
        }

        public SecureAreaPage GoToDashboard()
        {
            // sometimes "Page Not Found occurrs, so double check if it is possible to open user dashboard"
            if (!Driver.WaitForClickableIgnoreException(By.CssSelector(YourDashboardCSS)) &&
                !Driver.TryToFindElement(By.CssSelector(YourDashboardCSS), out var element)) return this;
            var yourDashboardElements = Driver.FindElementsGraterThenZero(By.CssSelector(YourDashboardCSS));
            Driver.MoveToElement(yourDashboardElements.ElementAtOrDefault(0));
            Driver.ClickOnElement(yourDashboardElements.ElementAtOrDefault(0));
            return this;
        }

        public SecureAreaPage OpenWorkspace()
        {
            Driver.ClickOnElement(SuccessMessageElement);
            return this;
        }

        public IList<IWebElement> GetListOfPages()
        {
            return PagesList;
        }

        public IWebElement SearchPageByName(string pageName)
        {
            return Driver.GetElementByDefineTextFromList(By.XPath(PageListXpath), pageName);
        }

        public SecureAreaPage OpenRestrictions()
        {
            Driver.MoveToElement(RestrictionsElement);
            Driver.ClickOnElement(RestrictionsElement);
            return this;
        }

        public SecureAreaPage CloseRestrictionsMenu()
        {
            Driver.ClickOnElement(CloseRestrictionsMenuButton);
            return this;
        }
    }
}