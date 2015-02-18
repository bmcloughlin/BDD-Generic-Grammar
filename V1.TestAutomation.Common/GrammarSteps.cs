using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


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

        [Given(@"I click the button with '(.*)' '(.*)'")]
        [When(@"I click the button with '(.*)' '(.*)'")]
        public void ClickTheButtonWithSpecificProperty(string p0, string p1)
        {
            switch (p0.ToUpper())
            {
                case "TITLE": ClickWithRetry(By.XPath(@"//input[@title='" + p1 + "']"));
                    break;
                case "LABEL": ClickWithRetry(By.XPath(@"//input[@value='" + p1 + "']"));
                    break;
                case "ID": ClickWithRetry(By.Id(p1));
                    break;
            }
        }

        [Given(@"I click the '(.*)' button with '(.*)' '(.*)'")]
        [When(@"I click the '(.*)' button with '(.*)' '(.*)'")]
        public void ClickTheNthButtonWithSpecificProperty(string p0, string p1, string p2)
        {
            var pos = int.Parse(GetIndexFromPosition(p0)) - 1;
            switch (p1.ToUpper())
            {
                case "TITLE":
                    Br.FindElements(By.XPath(@"//input[@title='" + p2 + "']"))[pos].Click();
                    break;
                case "LABEL":
                    Br.FindElements(By.XPath(@"//input[@value='" + p2 + "']"))[pos].Click();
                    break;
                case "ID":
                    Br.FindElements(By.Id(p2))[pos].Click();
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

        [Given(@"I Select '(.*)' from the dropdown '(.*)'")]
        [When(@"I Select '(.*)' from the dropdown '(.*)'")]
        public void SelectFromTheDropdown(string p0, string p1)
        {
            var xPath = string.Format(@".//option[contains(text(),'{0}')]",p0);
            var ddl = Br.FindElement(By.Id(p1));
            ddl.FindElement(By.XPath(xPath)).Click();
        }

        [Given(@"I Click the checkbox labelled '(.*)'")]
        [When(@"I Click the checkbox labelled '(.*)'")]
        public void ClickTheCheckboxLabelled(string p0)
        {
            var xPath = string.Format(@"//label[contains(text(),'{0}')]", p0);
            var label = Br.FindElement(By.XPath(xPath));
            Br.FindElement(By.Id(label.GetAttribute("for"))).Click();
        }

        [Given(@"I Select '(.*)' from the dropdown labelled '(.*)'")]
        [When(@"I Select '(.*)' from the dropdown labelled '(.*)'")]
        public void SelectFromTheDropdownLabelled(string p0, string p1)
        {
            var id = string.Empty;
            var xPath = string.Format(@"//label[contains(text(),'{0}')]", p1);
            var labels = Br.FindElements(By.XPath(xPath));
            
            foreach (var label in labels.Where(label => label.GetAttribute("for") != null))
            {
                id = label.GetAttribute("for");
                break;
            }

            xPath = string.Format(@".//option[contains(text(),'{0}')]", p0);
            var ddl = Br.FindElement(By.Id(id));
            ClickWithRetry(By.XPath(xPath));         
        }

        [Given(@"I select the '(.*)' checkbox")]
        [When(@"I select the '(.*)' checkbox")]
        public void SelectTheNthCheckbox(string p0)
        {
            var xPath = string.Format(@"//input[@type='checkbox'][{0}]", GetIndexFromPosition(p0));
            Br.FindElement(By.XPath(xPath)).Click();
        }

 
        [Given(@"I type '(.*)' into '(.*)'")]
        [When(@"I type '(.*)' into '(.*)'")]
        public void TypeTextInto(string p0, string p1)
        {
            ClearAndType(p0, p1);
        }

        [Given(@"I type '(.*)' into text box labelled '(.*)'")]
        [When(@"I type '(.*)' into text box labelled '(.*)'")]
        public void TypeIntoTextBoxLabelled(string p0, string p1)
        {
            var xPath = string.Format(@"//label[contains(text(),'{0}')]", p1);
            var label = Br.FindElement(By.XPath(xPath));
            ClearAndType(p0, label.GetAttribute("for"));
        }

   
        [Then(@"a validation message is displayed where the message ends with '(.*)'")]
        public void ValidationMessageIsDisplayedWhichEndsWith(string p0)
        {
            var msgs =
                Br.FindElements(
                    By.XPath("//div[contains(concat(' ', @class, ' '), ' validation-summary-errors ')]/ul/li"));
            Assert.IsTrue(msgs.Any(e => e.Text.EndsWith(p0)));
        }

        [Given(@"I fill the following input values:")]
        [When(@"I fill the following input values:")]
        public void FillTheFollowingInputValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                switch (row[1])
                {
                    case "text":
                        TypeIntoTextBoxLabelled(row[2], row[0]);
                        break;
                    case "select":
                        SelectFromTheDropdownLabelled(row[2], row[0]);
                        break;
                    case "checkbox":
                        ClickTheCheckboxLabelled(row[0]);
                        break;
                    default:
                        TypeTextInto(row[2], row[0]);
                        break;
                }

            }
        }

        [Then(@"the text '(.*)' should be displayed")]
        public void ThenTheTextShouldBeDisplayed(string p0)
        {
            var xPath = string.Format(@"//*[contains(text(),'{0}')]", p0);
            var list = Br.FindElements(By.XPath(xPath));
            Assert.IsTrue(list.Any());
        }

        [Then(@"the div with '(.*)' '(.*)' should contain the text '(.*)'")]
        public void ThenTheDivWithShouldContainTheText(string p0, string p1, string p2)
        {
            IWebElement div = null;
            switch (p0.ToUpper())
            {

                case "TITLE":
                    div = Br.FindElement(By.XPath(@"//div[@title='" + p1 + "']"));
                    break;
                case "ID":
                    div = Br.FindElement(By.Id(p1));
                    break;
            }
            Assert.IsNotNull(div);
            Assert.IsTrue(div.Text.Contains(p2));

        }

        [Then(@"I save a screenshot as '(.*)'")]
        public void ThenISaveAScreenshotAs(string p0)
        {
            var screenshotFolder = ConfigurationManager.AppSettings["screenshotFolder"];
            var fileName = string.Concat(screenshotFolder, p0, ".png");
            var ss = ((ITakesScreenshot)Br).GetScreenshot();
            ss.SaveAsFile(fileName, ImageFormat.Png);       
        }



    }
}
