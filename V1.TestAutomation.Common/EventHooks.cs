
using System;
using System.Drawing;
using Autofac;
using Autofac.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{
    [Binding]
    public class EventHooks
    {
        private static IContainer Container { get; set; }
        private static ILifetimeScope Scope { get; set; }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            Container = builder.Build();
            Scope = Container.BeginLifetimeScope();
        }

        [BeforeFeature(new string[] {})]
        public static void BeforeFeature()
        {
            var browser = Scope.Resolve<IWebDriver>();
            browser.Manage().Window.Position = new Point(0, 0);
            browser.Manage().Window.Size = new Size(1024, 768);
            browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(10000));
            FeatureContext.Current.Browser(browser);
        }

        [AfterFeature(new string[] { })]
        public static void AfterFeature()
        {
            FeatureContext.Current.Browser().Quit();            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Scope.Dispose();
        }

    }
}
