using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{
    public static class FeatureContextExtensions
    {
        public static IWebDriver Browser(this FeatureContext context)
        {
            if(!context.ContainsKey(@"browser")) throw new ApplicationException("The browser has not been added to the features context");
            return (IWebDriver) context[@"browser"];
        }

        public static IWebDriver Browser(this FeatureContext context, IWebDriver browser)
        {
            context.Add(@"browser", browser);
            return context.Browser();
        }

    }
}
