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
    [Xunit.TraitAttribute("Category", "golfclubadministrator")]
    public partial class GetClubMembersListFeature : Xunit.IClassFixture<GetClubMembersListFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GetClubMembersList.feature"
#line hidden
        
        public GetClubMembersListFeature(GetClubMembersListFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetClubMembersList", null, ProgrammingLanguage.CSharp, new string[] {
                        "base",
                        "golfclub",
                        "golfclubadministrator"});
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
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "EmailAddress",
                        "GivenName",
                        "MiddleName",
                        "FamilyName",
                        "Password",
                        "ConfirmPassword",
                        "TelephoneNumber"});
            table13.AddRow(new string[] {
                        "1",
                        "admin@testgolfclub1.co.uk",
                        "Admin",
                        "",
                        "User1",
                        "123456",
                        "123456",
                        "01234567890"});
#line 5
 testRunner.Given("the following golf club administrators have been registered", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
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
            table14.AddRow(new string[] {
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
 testRunner.And("the following golf clubs exist", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlayerNumber",
                        "EmailAddress",
                        "GivenName",
                        "MiddleName",
                        "FamilyName",
                        "Age",
                        "Gender",
                        "ExactHandicap"});
            table15.AddRow(new string[] {
                        "1",
                        "testplayer1@players.co.uk",
                        "Test",
                        "",
                        "Player1",
                        "16",
                        "M",
                        "2"});
            table15.AddRow(new string[] {
                        "2",
                        "testplayer2@players.co.uk",
                        "Test",
                        "",
                        "Player2",
                        "18",
                        "M",
                        "4"});
            table15.AddRow(new string[] {
                        "3",
                        "testplayer3@players.co.uk",
                        "Test",
                        "",
                        "Player3",
                        "18",
                        "M",
                        "10"});
            table15.AddRow(new string[] {
                        "4",
                        "testplayer4@players.co.uk",
                        "Test",
                        "",
                        "Player4",
                        "19",
                        "M",
                        "12"});
            table15.AddRow(new string[] {
                        "5",
                        "testplayer5@players.co.uk",
                        "Test",
                        "",
                        "Player5",
                        "20",
                        "M",
                        "1"});
            table15.AddRow(new string[] {
                        "6",
                        "testplayer6@players.co.uk",
                        "Test",
                        "",
                        "Player6",
                        "22",
                        "M",
                        "28"});
            table15.AddRow(new string[] {
                        "7",
                        "testplayer7@players.co.uk",
                        "Test",
                        "",
                        "Player7",
                        "24",
                        "M",
                        "24"});
            table15.AddRow(new string[] {
                        "8",
                        "testplayer8@players.co.uk",
                        "Test",
                        "",
                        "Player8",
                        "26",
                        "M",
                        "18"});
            table15.AddRow(new string[] {
                        "9",
                        "testplayer9@players.co.uk",
                        "Test",
                        "",
                        "Player9",
                        "35",
                        "M",
                        "18"});
            table15.AddRow(new string[] {
                        "10",
                        "testplayer10@players.co.uk",
                        "Test",
                        "",
                        "Player10",
                        "64",
                        "M",
                        "6"});
            table15.AddRow(new string[] {
                        "11",
                        "testplayer11@players.co.uk",
                        "Test",
                        "",
                        "Player11",
                        "65",
                        "M",
                        "9"});
            table15.AddRow(new string[] {
                        "12",
                        "testplayer12@players.co.uk",
                        "Test",
                        "",
                        "Player12",
                        "70",
                        "M",
                        "0"});
#line 11
 testRunner.And("the following players have registered", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "GolfClubNumber",
                        "PlayerNumber"});
            table16.AddRow(new string[] {
                        "1",
                        "1"});
            table16.AddRow(new string[] {
                        "1",
                        "2"});
            table16.AddRow(new string[] {
                        "1",
                        "3"});
            table16.AddRow(new string[] {
                        "1",
                        "4"});
            table16.AddRow(new string[] {
                        "1",
                        "5"});
            table16.AddRow(new string[] {
                        "1",
                        "6"});
            table16.AddRow(new string[] {
                        "1",
                        "7"});
            table16.AddRow(new string[] {
                        "1",
                        "8"});
            table16.AddRow(new string[] {
                        "1",
                        "9"});
            table16.AddRow(new string[] {
                        "1",
                        "10"});
            table16.AddRow(new string[] {
                        "1",
                        "11"});
            table16.AddRow(new string[] {
                        "1",
                        "12"});
#line 25
 testRunner.And("the following players are club members of the following golf clubs", ((string)(null)), table16, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Get List of Golf Club Members")]
        [Xunit.TraitAttribute("FeatureTitle", "GetClubMembersList")]
        [Xunit.TraitAttribute("Description", "Get List of Golf Club Members")]
        public virtual void GetListOfGolfClubMembers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get List of Golf Club Members", null, ((string[])(null)));
#line 40
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 41
 testRunner.When("I request a list of members for golf club number 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("the a list of 12 members is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetClubMembersListFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetClubMembersListFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
