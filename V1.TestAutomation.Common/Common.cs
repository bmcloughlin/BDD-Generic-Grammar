using System.Collections;
using System.Configuration;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{
    public abstract class Common
    {
        
      
        protected void ClickWithRetry(By by) {
      
            var attempts = 0;

            while (attempts < 2)
            {
                try
                {
                    Br.FindElement(by).Click();
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                }
                attempts++;
            }
        }
 
        protected string GuidString()
        {
            return
                Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("=", "")
                    .Replace("+", "")
                    .Replace("/", "");
        }


        protected void ClearAndType(string p0, string p1)
        {
            Br.FindElement(By.Id(p1)).Clear();
            p0 = (p0.Contains(@"uniquevalue")) ? p0.Replace(@"uniquevalue", GuidString()) : p0;
            p0 = (p0.Contains(@"cache"))
                ? FeatureContext.Current.Get<string>(p0.Substring(p0.LastIndexOf('.') + 1))
                : p0;
            p0 = (p0.Contains(@"config"))
                ? ConfigurationManager.AppSettings[p0.Substring(p0.LastIndexOf('.') + 1)]
                : p0;

            Br.FindElement(By.Id(p1)).SendKeys(p0);

        }

        protected string GetIndexFromPosition(string pos)
        {
            var index = "0";
            switch (pos)
            {
                case "1st":
                    index = "1";
                    break;
                case "2nd":
                    index = "2";
                    break;
                case "3rd":
                    index = "3";
                    break;
                case "4th":
                    index = "4";
                    break;
                case "5th":
                    index = "5";
                    break;
                case "6th":
                    index = "6";
                    break;
                case "7th":
                    index = "7";
                    break;
                case "8th":
                    index = "8";
                    break;
                case "9th":
                    index = "9";
                    break;
                case "10th":
                    index = "10";
                    break;
                case "11th":
                    index = "11";
                    break;
                case "12th":
                    index = "12";
                    break;
                case "13th":
                    index = "13";
                    break;
                case "14th":
                    index = "14";
                    break;
                case "15th":
                    index = "15";
                    break;
                case "16th":
                    index = "16";
                    break;
                case "17th":
                    index = "17";
                    break;
                case "18th":
                    index = "18";
                    break;
                case "19th":
                    index = "19";
                    break;
                case "20th":
                    index = "20";
                    break;
            }
            return index;
        }

        protected static IWebDriver Br {
            get { return FeatureContext.Current.Browser(); }
        }
        protected FeatureContext Ctx
        {
            get { return FeatureContext.Current; }
        }
    }
}
