// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ManagementAPI.IntegrationTests.GolfClub
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "base")]
    [Xunit.TraitAttribute("Category", "golfclub")]
    public partial class GetGolfClubFeature : Xunit.IClassFixture<GetGolfClubFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GetGolfClub.feature"
#line hidden
        
        public GetGolfClubFeature(GetGolfClubFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Get Golf Club", "\tIn order to run a golf club handicapping system\r\n\tAs a club administrator\r\n\tI wa" +
                    "nt to be able to get my golf club", ProgrammingLanguage.CSharp, new string[] {
                        "base",
                        "golfclub"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "EmailAddress",
                        "GivenName",
                        "MiddleName",
                        "FamilyName",
                        "Password",
                        "ConfirmPassword",
                        "TelephoneNumber"});
            table16.AddRow(new string[] {
                        "1",
                        "admin@testgolfclub1.co.uk",
                        "Admin",
                        "",
                        "User1",
                        "123456",
                        "123456",
                        "01234567890"});
#line 8
 testRunner.Given("the following golf club administrator has been registered", ((string)(null)), table16, "Given ");
#line 11
 testRunner.And("I am logged in as the administrator for golf club 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "GolfClubName",
                        "AddressLine1",
                        "AddressLine2",
                        "Town",
                        "Region",
                        "PostalCode",
                        "TelephoneNumber",
                        "EmailAddress",
                        "WebSite"});
            table17.AddRow(new string[] {
                        "1",
                        "Test Golf Club 1",
                        "Test Golf Club Address Line 1",
                        "Test Golf Club Address Line",
                        "TestTown1",
                        "TestRegion",
                        "TE57 1NG",
                        "01234567890",
                        "testclub1@testclub1.co.uk",
                        "www.testclub1.co.uk"});
#line 12
 testRunner.When("I create a golf club with the following details", ((string)(null)), table17, "When ");
#line 15
 testRunner.Then("the golf club is created successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Golf Club")]
        [Xunit.TraitAttribute("FeatureTitle", "Get Golf Club")]
        [Xunit.TraitAttribute("Description", "Get Golf Club")]
        public virtual void GetGolfClub()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Golf Club", null, ((string[])(null)));
#line 17
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
this.FeatureBackground();
#line 18
 testRunner.When("I request the details of the golf club 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("the golf club data will be returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetGolfClubFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetGolfClubFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
