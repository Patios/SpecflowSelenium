using System;
using System.IO;
using AutomationTestFramework.Helpers;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;

namespace AutomationTestFramework.Base
{
    [Binding]
    public class BaseTest
    {
        public BaseTest()
        {
            var driverConfig = Configuration.WebDriver;
            var logger = new L();
            Driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        protected IWebDriver Driver { get; set; }

        [AfterScenario]
        public void TearDown(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
                Driver.TakeScreenshot()
                    .SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"),
                        ScreenshotImageFormat.Png);

            Driver.Dispose();
            Driver.Quit();
        }
    }
}