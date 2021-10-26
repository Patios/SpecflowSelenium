using System.Collections.Generic;
using System.Linq;
using AutomationTestFramework.Base;
using AutomationTestFramework.Tests.Confluence.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationTestFramework.Tests.Confluence.Tests.Steps
{
    [Binding]
    public class TestLoginSteps : BaseTest
    {
        private readonly LoginFormPage _loginFormPage;
        private readonly LogOutPage _logOutPage;
        private readonly SecureAreaPage _secureAreaPage;
        private IList<IWebElement> _listOfAvailablePages;


        public TestLoginSteps()
        {
            _loginFormPage = new LoginFormPage(Driver);
            _secureAreaPage = new SecureAreaPage(Driver);
            _logOutPage = new LogOutPage(Driver);
        }

        [Given(@"Navigate to Login Page to Put Credentials")]
        public void GivenPutCredentials()
        {
            _loginFormPage.Go();
        }

        [Given(@"Fill Login Form as username '(.*)' with password '(.*)' successfully")]
        public void GivenFillLoginForm(string username, string password)
        {
            _loginFormPage.FillLoginForm(username);
            _loginFormPage.FillPasswordForm(password);
            _loginFormPage.Submit();
        }

        [Given(@"Go to restricted pages and check Page name: ""(.*)"" has enabled restrictions")]
        public void GivenGoToRestrictedPagesAndCheckPageNameHasEnabledRestrictions(string restrictedPageName)
        {
            _secureAreaPage.SearchPageByName("QA Workshop - Getting started").Click();
            _secureAreaPage.SearchPageByName(restrictedPageName).Click();
            _secureAreaPage.OpenRestrictions();
            _secureAreaPage.RestrictedPageMessage.Should().Contain("Only specific people can view or edit");
        }

        [Given(@"Close Restrictions Menu")]
        public void GivenCloseRestrictionsMenu()
        {
            _secureAreaPage.CloseRestrictionsMenu();
        }

        [Given(@"Go to pages and check list of available user pages")]
        public void GivenGoToPagesAndCheckListOfAvailableUserPages()
        {
            _secureAreaPage.SearchPageByName("QA Workshop - Getting started").Click();
            _listOfAvailablePages = _secureAreaPage.GetListOfPages();
        }

        [Given(@"Page name : ""(.*)"" is not displayed\.")]
        public void GivenPageNameIsNotDisplayed_(string pageNameText)
        {
            Assert.IsNull(_listOfAvailablePages.FirstOrDefault(x => x.Text == pageNameText)?.Text);
        }

        [Given(@"User Logged To Confluence Dashboard")]
        public void GivenUserLoggedToConfluenceDashboard()
        {
            _secureAreaPage.GoToDashboard();
            _secureAreaPage.SuccessMessage.Should().Contain("QA Workshop");
            _secureAreaPage.OpenWorkspace();
        }


        [Then(@"Logout")]
        public void ThenLogout()
        {
            _secureAreaPage.Logout();
            _logOutPage.LoginToAnotherAccount();
            _logOutPage.RedirectToLogout();
        }
    }
}