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
namespace ManagementAPI.IntegrationTests.Reporting
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "base")]
    [Xunit.TraitAttribute("Category", "golfclub")]
    [Xunit.TraitAttribute("Category", "reporting")]
    public partial class GolfClubReportsFeature : Xunit.IClassFixture<GolfClubReportsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GolfClubReports.feature"
#line hidden
        
        public GolfClubReportsFeature(GolfClubReportsFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GolfClubReports", null, ProgrammingLanguage.CSharp, new string[] {
                        "base",
                        "golfclub",
                        "reporting"});
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
#line 4
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "EmailAddress",
                        "GivenName",
                        "MiddleName",
                        "FamilyName",
                        "Password",
                        "ConfirmPassword",
                        "TelephoneNumber"});
            table32.AddRow(new string[] {
                        "1",
                        "admin@testgolfclub1.co.uk",
                        "Admin",
                        "",
                        "User1",
                        "123456",
                        "123456",
                        "01234567890"});
#line 5
 testRunner.Given("the following golf club administrators have been registered", ((string)(null)), table32, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
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
            table33.AddRow(new string[] {
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
#line 8
 testRunner.And("the following golf clubs exist", ((string)(null)), table33, "And ");
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlayerNumber",
                        "EmailAddress",
                        "GivenName",
                        "MiddleName",
                        "FamilyName",
                        "Age",
                        "Gender",
                        "ExactHandicap"});
            table34.AddRow(new string[] {
                        "1",
                        "testplayer1@players.co.uk",
                        "Test",
                        "",
                        "Player1",
                        "16",
                        "M",
                        "2"});
            table34.AddRow(new string[] {
                        "2",
                        "testplayer2@players.co.uk",
                        "Test",
                        "",
                        "Player2",
                        "18",
                        "M",
                        "4"});
            table34.AddRow(new string[] {
                        "3",
                        "testplayer3@players.co.uk",
                        "Test",
                        "",
                        "Player3",
                        "18",
                        "M",
                        "10"});
            table34.AddRow(new string[] {
                        "4",
                        "testplayer4@players.co.uk",
                        "Test",
                        "",
                        "Player4",
                        "19",
                        "M",
                        "12"});
            table34.AddRow(new string[] {
                        "5",
                        "testplayer5@players.co.uk",
                        "Test",
                        "",
                        "Player5",
                        "20",
                        "M",
                        "1"});
            table34.AddRow(new string[] {
                        "6",
                        "testplayer6@players.co.uk",
                        "Test",
                        "",
                        "Player6",
                        "22",
                        "M",
                        "28"});
            table34.AddRow(new string[] {
                        "7",
                        "testplayer7@players.co.uk",
                        "Test",
                        "",
                        "Player7",
                        "24",
                        "M",
                        "24"});
            table34.AddRow(new string[] {
                        "8",
                        "testplayer8@players.co.uk",
                        "Test",
                        "",
                        "Player8",
                        "26",
                        "M",
                        "18"});
            table34.AddRow(new string[] {
                        "9",
                        "testplayer9@players.co.uk",
                        "Test",
                        "",
                        "Player9",
                        "35",
                        "M",
                        "18"});
            table34.AddRow(new string[] {
                        "10",
                        "testplayer10@players.co.uk",
                        "Test",
                        "",
                        "Player10",
                        "64",
                        "M",
                        "6"});
            table34.AddRow(new string[] {
                        "11",
                        "testplayer11@players.co.uk",
                        "Test",
                        "",
                        "Player11",
                        "65",
                        "M",
                        "9"});
            table34.AddRow(new string[] {
                        "12",
                        "testplayer12@players.co.uk",
                        "Test",
                        "",
                        "Player12",
                        "70",
                        "M",
                        "0"});
#line 11
 testRunner.And("the following players have registered", ((string)(null)), table34, "And ");
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "PlayerNumber"});
            table35.AddRow(new string[] {
                        "1",
                        "1"});
            table35.AddRow(new string[] {
                        "1",
                        "2"});
            table35.AddRow(new string[] {
                        "1",
                        "3"});
            table35.AddRow(new string[] {
                        "1",
                        "4"});
            table35.AddRow(new string[] {
                        "1",
                        "5"});
            table35.AddRow(new string[] {
                        "1",
                        "6"});
            table35.AddRow(new string[] {
                        "1",
                        "7"});
            table35.AddRow(new string[] {
                        "1",
                        "8"});
            table35.AddRow(new string[] {
                        "1",
                        "9"});
            table35.AddRow(new string[] {
                        "1",
                        "10"});
            table35.AddRow(new string[] {
                        "1",
                        "11"});
            table35.AddRow(new string[] {
                        "1",
                        "12"});
#line 25
 testRunner.And("the following players are club members of the following golf clubs", ((string)(null)), table35, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members Report")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members Report")]
        public virtual void GetNumberOfMembersReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members Report", null, ((string[])(null)));
#line 40
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 41
 testRunner.When("I request a number of members report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I am returned the number of members report data successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("the number of members count for club number 1 is 12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members By Handicap Category Report")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members By Handicap Category Report")]
        public virtual void GetNumberOfMembersByHandicapCategoryReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members By Handicap Category Report", null, ((string[])(null)));
#line 45
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 46
 testRunner.When("I request a number of members by handicap category report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("I am returned the number of members by handicap category report data successfully" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("the number of members by handicap category count for club number 1 handicap categ" +
                    "ory 1 is 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("the number of members by handicap category count for club number 1 handicap categ" +
                    "ory 2 is 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("the number of members by handicap category count for club number 1 handicap categ" +
                    "ory 3 is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("the number of members by handicap category count for club number 1 handicap categ" +
                    "ory 4 is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members By Time Period Report - By Day")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members By Time Period Report - By Day")]
        public virtual void GetNumberOfMembersByTimePeriodReport_ByDay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members By Time Period Report - By Day", null, ((string[])(null)));
#line 53
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 54
 testRunner.When("I request a number of members by time period \'day\' report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("I am returned the number of members by time period report data successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("the number of members for the period \'Today\' in the number of members by time per" +
                    "iod \'day\' report for club number 1 is 12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members By Time Period Report - By Month")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members By Time Period Report - By Month")]
        public virtual void GetNumberOfMembersByTimePeriodReport_ByMonth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members By Time Period Report - By Month", null, ((string[])(null)));
#line 58
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 59
 testRunner.When("I request a number of members by time period \'month\' report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("I am returned the number of members by time period report data successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("the number of members for the period \'This Month\' in the number of members by tim" +
                    "e period \'month\' report for club number 1 is 12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members By Time Period Report - By Year")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members By Time Period Report - By Year")]
        public virtual void GetNumberOfMembersByTimePeriodReport_ByYear()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members By Time Period Report - By Year", null, ((string[])(null)));
#line 63
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 64
 testRunner.When("I request a number of members by time period \'year\' report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("I am returned the number of members by time period report data successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("the number of members for the period \'This Year\' in the number of members by time" +
                    " period \'year\' report for club number 1 is 12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Get Number of Members By Age Category Report")]
        [Xunit.TraitAttribute("FeatureTitle", "GolfClubReports")]
        [Xunit.TraitAttribute("Description", "Get Number of Members By Age Category Report")]
        public virtual void GetNumberOfMembersByAgeCategoryReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Number of Members By Age Category Report", null, ((string[])(null)));
#line 68
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 69
 testRunner.When("I request a number of members by age category report for club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("I am returned the number of members by age category report data successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.And("the number of members by age category count for club number 1 age category \'Junio" +
                    "r\' is 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("the number of members by age category count for club number 1 age category \'Juven" +
                    "ile\' is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("the number of members by age category count for club number 1 age category \'Youth" +
                    "\' is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("the number of members by age category count for club number 1 age category \'Young" +
                    " Adult\' is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("the number of members by age category count for club number 1 age category \'Adult" +
                    "\' is 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("the number of members by age category count for club number 1 age category \'Senio" +
                    "r\' is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GolfClubReportsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GolfClubReportsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
