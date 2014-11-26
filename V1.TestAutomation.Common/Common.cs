using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace V1.TestAutomation.Common
{
    public abstract class Common
    {
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
            Br.FindElement(By.Id(p1)).SendKeys(p0);

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
