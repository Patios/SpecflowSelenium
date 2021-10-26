using System;
using AutomationTestFramework.Helpers;

namespace AutomationTestFramework.Tests.Confluence.Providers
{
    public class UrlProvider
    {
        private static Uri BaseUrl => new Uri(Configuration.Environment.ApplicationUrl);
        public static Uri Login => new Uri(BaseUrl, "login");
    }
}