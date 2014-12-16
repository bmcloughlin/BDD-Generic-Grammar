using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{

    [Binding]
    public class GrammarSteps : Common
    {
      
        
        [Given(@"I add '(.*)' to the cache as '(.*)' for reuse")]
        public void AddValueToCache(string p0, string p1)
        {
            p0 = (p0.Contains(@"uniquevalue")) ? p0.Replace(@"uniquevalue", GuidString()) : p0;        
            FeatureContext.Current.Add(p1, p0);
        }


        [Given(@"I go to the '(.*)' screen")]
        [Then(@"I go to the '(.*)' screen")]
        [When(@"I go to the '(.*)' screen")]
        public void GoToTheScreen(string p0)
        {
            string url;
            Assert.IsTrue(RouteCache.TryGetUrl(p0, out url), "The supplied route key not found in the route cache");
            Br.Navigate().GoToUrl(url);
        }

        
        [Then(@"the title of the page should start with '(.*)'")]
        public void TheTitleStartsWith(string p0)
        {
            Assert.IsTrue(Br.Title.StartsWith(p0));
        }


        [When(@"I click the button with '(.*)' '(.*)'")]
        public void ClickTheButtonWithSpecificProperty(string p0, string p1)
        {
            switch (p0.ToUpper())
            {
                case "LABEL": Br.FindElement(By.XPath(@"//input[@value='" + p1 + "']")).Click();
                    break;
                case "ID": Br.FindElement(By.Id(p1)).Click();
                    break;
            }
        }

        [When(@"I click the '(.*)' link")]
        public void ClickHyperLink(string p0)
        {
            Br.FindElement(By.XPath(@"//a[text()='" + p0 + "']")).Click();
        }

        [Then(@"a validation message is displayed with the message '(.*)'")]
        public void ValidationMessageIsDisplayed(string p0)
        {
            var msgs =
                Br.FindElements(
                    By.XPath("//div[contains(concat(' ', @class, ' '), ' validation-summary-errors ')]/ul/li"));
            Assert.IsTrue(msgs.Any(e => e.Text == p0));
        }

        
        [Given(@"I type '(.*)' into '(.*)'")]
        [When(@"I type '(.*)' into '(.*)'")]
        public void TypeTextInto(string p0, string p1)
        {
            ClearAndType(p0, p1);
        }

     
        
        [Then(@"a validation message is displayed where the message ends with '(.*)'")]
        public void ValidationMessageIsDisplayedWhichEndsWith(string p0)
        {
            var msgs =
                Br.FindElements(
                    By.XPath("//div[contains(concat(' ', @class, ' '), ' validation-summary-errors ')]/ul/li"));
            Assert.IsTrue(msgs.Any(e => e.Text.EndsWith(p0)));
        }
    }
}
