using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{

    [Binding]
    public class GrammarSteps : Common
    {
      
        [Given]
        public void Given_I_add_P0_to_the_cache_as_P1_for_reuse(string p0, string p1)
        {
            p0 = (p0.Contains(@"uniquevalue")) ? p0.Replace(@"uniquevalue", GuidString()) : p0;        
            FeatureContext.Current.Add(p1, p0);
        }

        [Given]
        public void Given_I_go_to_the_P0_screen(string p0)
        {
            string url;
            Assert.IsTrue(RouteCache.TryGetUrl(p0, out url), "The supplied route key not found in the route cache");
            Br.Navigate().GoToUrl(url);
        }

        [Then]
        public void Then_the_title_of_the_page_should_start_with_P0(string p0)
        {
            Assert.IsTrue(Br.Title.StartsWith(p0));
        }


        [When]
        public void When_I_click_the_button_with_P0_P1(string p0, string p1)
        {
            switch (p0.ToUpper())
            {
                case "LABEL": Br.FindElement(By.XPath(@"//input[@value='" + p1 + "']")).Click();
                    break;
                case "ID": Br.FindElement(By.Id(p1)).Click();
                    break;
            }
        }


        [When]
        public void When_I_click_the_P0_link(string p0)
        {
            Br.FindElement(By.XPath(@"//a[text()='" + p0 + "']")).Click();
        }

        [Then]
        public void Then_a_validation_message_is_displayed_with_the_message_P0(string p0)
        {
            var msgs =
                Br.FindElements(
                    By.XPath("//div[contains(concat(' ', @class, ' '), ' validation-summary-errors ')]/ul/li"));
            Assert.IsTrue(msgs.Any(e => e.Text == p0));
        }

        [Given]
        public void Given_I_type_P0_into_P1(string p0, string p1)
        {
            ClearAndType(p0, p1);
        }

        [When]
        public void When_I_type_P0_into_P1(string p0, string p1)
        {
            ClearAndType(p0, p1);
        }

        [Then]
        public void Then_a_validation_message_is_displayed_where_the_message_ends_with_P0(string p0)
        {
            var msgs =
                Br.FindElements(
                    By.XPath("//div[contains(concat(' ', @class, ' '), ' validation-summary-errors ')]/ul/li"));
            Assert.IsTrue(msgs.Any(e => e.Text.EndsWith(p0)));
        }
    }
}
