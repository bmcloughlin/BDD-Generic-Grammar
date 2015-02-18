﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34003
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace V1.TestAutomation.SampleApp.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("RegisterUser")]
    public partial class RegisterUserFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegisterUser.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RegisterUser", "In order to use the sample app\nAs an authenticated user\nI want to register with t" +
                    "he sample app", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("I go to the \'Register User\' screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("the title of the page should start with \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Mandatory validation of Email fails")]
        public virtual void MandatoryValidationOfEmailFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mandatory validation of Email fails", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 11
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("a validation message is displayed with the message \'The Email field is required.\'" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Format validation of Email fails")]
        public virtual void FormatValidationOfEmailFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Format validation of Email fails", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 15
 testRunner.Given("I type \'badlyformattedemail\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("a validation message is displayed with the message \'The Email field is not a vali" +
                    "d e-mail address.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Mandatory validation of Password fails")]
        public virtual void MandatoryValidationOfPasswordFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mandatory validation of Password fails", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 20
 testRunner.Given("I type \'bmcloughlin@gmail.com\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("a validation message is displayed with the message \'The Password field is require" +
                    "d.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Length validation of Password fails")]
        public virtual void LengthValidationOfPasswordFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length validation of Password fails", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 25
 testRunner.Given("I type \'bmcloughlin@gmail.com\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
  testRunner.And("I type \'Pass\' into \'Password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("a validation message is displayed with the message \'The Password must be at least" +
                    " 6 characters long.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Confirmation validation of Password fails")]
        public virtual void ConfirmationValidationOfPasswordFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Confirmation validation of Password fails", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Label",
                        "Type",
                        "Value"});
            table1.AddRow(new string[] {
                        "Email",
                        "text",
                        "bmcloughlin@gmail.com"});
            table1.AddRow(new string[] {
                        "Password",
                        "text",
                        "Password123"});
            table1.AddRow(new string[] {
                        "ConfirmPassword",
                        "text",
                        "Password456"});
#line 31
 testRunner.Given("I fill the following input values:", ((string)(null)), table1, "Given ");
#line 36
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("a validation message is displayed with the message \'The password and confirmation" +
                    " password do not match.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Strength validation of Password fails")]
        public virtual void StrengthValidationOfPasswordFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Strength validation of Password fails", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 42
 testRunner.Given("I type \'bmcloughlin@gmail.com\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
  testRunner.And("I type \'Password123\' into \'Password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
  testRunner.And("I type \'Password123\' into \'ConfirmPassword\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("a validation message is displayed with the message \'Passwords must have at least " +
                    "one non letter or digit character.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successful Registration")]
        public virtual void SuccessfulRegistration()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successful Registration", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 50
 testRunner.Given("I type \'autotest.uniquevalue@gmail.com\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
  testRunner.And("I type \'Password123_\' into \'Password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("I type \'Password123_\' into \'ConfirmPassword\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("the title of the page should start with \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Already taken validation of Email fails")]
        public virtual void AlreadyTakenValidationOfEmailFails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Already taken validation of Email fails", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 58
 testRunner.Given("I add \'autotest.uniquevalue@gmail.com\' to the cache as \'email\' for reuse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
  testRunner.And("I type \'cache.email\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
  testRunner.And("I type \'Password123_\' into \'Password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("I type \'Password123_\' into \'ConfirmPassword\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
  testRunner.And("I click the \'Log off\' link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And("I click the \'Register\' link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And("I type \'cache.email\' into \'Email\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
  testRunner.And("I type \'Password123_\' into \'Password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
  testRunner.And("I type \'Password123_\' into \'ConfirmPassword\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And("I click the button with \'label\' \'Register\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.Then("a validation message is displayed where the message ends with \'is already taken.\'" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
