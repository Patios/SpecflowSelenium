using AutomationTestFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationTestFramework.Helpers
{
    public class WebDriverSettings
    {
        public static ChromeOptions ChromeOptions(WebDriverConfiguration config)
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("start-maximized");
            options.AddArgument($"--lang={config.BrowserLanguage}");
            options.AddUserProfilePreference("intl.accept_languages", config.BrowserLanguage);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            if (config.Headless) options.AddArgument("--headless");

            return options;
        }

        public static FirefoxOptions FirefoxOptions(WebDriverConfiguration config)
        {
            var options = new FirefoxOptions {AcceptInsecureCertificates = true};
            options.SetPreference("intl.accept_languages", config.BrowserLanguage);

            if (config.Headless) options.AddArgument("-headless");

            return options;
        }

        public static InternetExplorerOptions InternetExplorerOptions()
        {
            return new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnsureCleanSession = true
            };
        }

        public static EdgeOptions EdgeOptions()
        {
            var edgeoptions = new EdgeOptions();
            edgeoptions.PageLoadStrategy = PageLoadStrategy.Normal;
            edgeoptions.AddArgument("inprivate");
            return edgeoptions;
        }

        public static EdgeDriverService GetEdgeDriverService()
        {
            var driverService =
                EdgeDriverService.CreateDefaultService("C:\\Windows\\SysWOW64\\", "MicrosoftWebDriver.exe");
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;
            return driverService;
        }

        public static FirefoxDriverService GetFirefoxService()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(Configuration.DriverPath);
            geckoService.Host = "::1";
            return geckoService;
        }

        public static ChromeOptions ChromeOptionsForRemote(WebDriverConfiguration config)
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("enableVNC", true, true);
            if (config.Video) options.AddAdditionalCapability("enableVideo", true, true);

            return options;
        }
    }
}