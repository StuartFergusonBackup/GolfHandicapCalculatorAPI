﻿using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ManagementAPI.IntegrationTests.Specflow.Common;
using ManagementAPI.Service.DataTransferObjects;
using Newtonsoft.Json;
using Shouldly;
using TechTalk.SpecFlow;

namespace ManagementAPI.IntegrationTests.Specflow.Tournament
{
    [Binding]
    [Scope(Tag = "tournamentmanagement")]
    public class TournamentManagementSteps: GenericSteps
    {
        public TournamentManagementSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }
        
        [Given(@"The Golf Handicapping System Is Running")]
        public void GivenTheGolfHandicappingSystemIsRunning()
        {
            RunSystem();
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            StopSystem();
        }
        
        [Given(@"My Club configuration has been already created")]
        public async Task GivenMyClubConfigurationHasBeenAlreadyCreated()
        {
            var request = IntegrationTestsTestData.CreateClubConfigurationRequest; 
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");

                String requestSerialised = JsonConvert.SerializeObject(request);
                StringContent httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync("/api/ClubConfiguration", httpContent, CancellationToken.None);

                httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);

                var responseData = JsonConvert.DeserializeObject<CreateClubConfigurationResponse>(await httpResponse.Content.ReadAsStringAsync());

                this.ScenarioContext["ClubConfigurationId"] = responseData.ClubConfigurationId;
            }
        }
        
        [Given(@"the club has a measured course")]
        public async Task GivenTheClubHasAMeasuredCourse()
        {
            var clubConfigurationId = this.ScenarioContext.Get<Guid>("ClubConfigurationId");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");


                var addMeasuredCourseToClubRequest = IntegrationTestsTestData.AddMeasuredCourseToClubRequest;
                addMeasuredCourseToClubRequest.ClubAggregateId = clubConfigurationId;

                var requestSerialised = JsonConvert.SerializeObject(addMeasuredCourseToClubRequest);
                var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                var httpResponse = await client.PutAsync("/api/ClubConfiguration", httpContent, CancellationToken.None);

                httpResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            }
        }
        
        [Given(@"I have the details of the new tournament")]
        public void GivenIHaveTheDetailsOfTheNewTournament()
        {
            var clubConfigurationId = this.ScenarioContext.Get<Guid>("ClubConfigurationId");
            var addMeasuredCourseToClubRequest = IntegrationTestsTestData.AddMeasuredCourseToClubRequest;

            var createTournamentRequest = IntegrationTestsTestData.CreateTournamentRequest;
            createTournamentRequest.ClubConfigurationId = clubConfigurationId;
            createTournamentRequest.MeasuredCourseId = addMeasuredCourseToClubRequest.MeasuredCourseId;

            this.ScenarioContext["CreateTournamentRequest"] = createTournamentRequest;
        }
        
        [When(@"I call Create Tournament")]
        public async Task WhenICallCreateTournament()
        {
            var createTournamentRequest = this.ScenarioContext.Get<CreateTournamentRequest>("CreateTournamentRequest");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");

                var requestSerialised = JsonConvert.SerializeObject(createTournamentRequest);
                var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                this.ScenarioContext["CreateTournamentHttpResponse"] = await client.PostAsync("/api/Tournament", httpContent, CancellationToken.None);
            }
        }
        
        [Then(@"the tournament will be created")]
        public void ThenTheTournamentWillBeCreated()
        {
            var httpResponse = this.ScenarioContext.Get<HttpResponseMessage>("CreateTournamentHttpResponse");
            httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        
        [Then(@"I will get the new Tournament Id in the response")]
        public async Task ThenIWillGetTheNewTournamentIdInTheResponse()
        {
            var httpResponse = this.ScenarioContext.Get<HttpResponseMessage>("CreateTournamentHttpResponse");

            var responseData = JsonConvert.DeserializeObject<CreateTournamentResponse>(await httpResponse.Content.ReadAsStringAsync());

            responseData.TournamentId.ShouldNotBe(Guid.Empty);
        }
        
        [Given(@"I have created a tournament")]
        public async Task GivenIHaveCreatedATournament()
        {
            var clubConfigurationId = this.ScenarioContext.Get<Guid>("ClubConfigurationId");
            var addMeasuredCourseToClubRequest = IntegrationTestsTestData.AddMeasuredCourseToClubRequest;

            var createTournamentRequest = IntegrationTestsTestData.CreateTournamentRequest;
            createTournamentRequest.ClubConfigurationId = clubConfigurationId;
            createTournamentRequest.MeasuredCourseId = addMeasuredCourseToClubRequest.MeasuredCourseId;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");

                var requestSerialised = JsonConvert.SerializeObject(createTournamentRequest);
                var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync("/api/Tournament", httpContent, CancellationToken.None);

                httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);

                var createTournamentResponseData = JsonConvert.DeserializeObject<CreateTournamentResponse>(await httpResponse.Content.ReadAsStringAsync());

                this.ScenarioContext["CreateTournamentResponse"] = createTournamentResponseData;
            }
        }
        
        [When(@"a member records their score")]
        public async Task WhenAMemberRecordsTheirScore()
        {
            var createTournamentResponseData =
                this.ScenarioContext.Get<CreateTournamentResponse>("CreateTournamentResponse");

            var recordMemberTournamentScoreRequest = IntegrationTestsTestData.RecordMemberTournamentScoreRequest;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");
                var requestSerialised = JsonConvert.SerializeObject(recordMemberTournamentScoreRequest);
                var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                this.ScenarioContext["RecordMemberTournamentScoreHttpResponse"] =
                    await client.PutAsync($"api/Tournament/{createTournamentResponseData.TournamentId}/RecordMemberScore", httpContent,
                        CancellationToken.None);
            }
        }
        
        [Then(@"the score is recorded against the tournament")]
        public void ThenTheScoreIsRecordedAgainstTheTournament()
        {
            var httpResponse = this.ScenarioContext.Get<HttpResponseMessage>("RecordMemberTournamentScoreHttpResponse");

            httpResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [When(@"I request to cancel the tournament")]
        public async Task WhenIRequestToCancelTheTournament()
        {
            var createTournamentResponseData =
                this.ScenarioContext.Get<CreateTournamentResponse>("CreateTournamentResponse");

            var cancelTournamentRequest = IntegrationTestsTestData.CancelTournamentRequest;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");

                var requestSerialised = JsonConvert.SerializeObject(cancelTournamentRequest);
                var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                this.ScenarioContext["CancelTournamentHttpResponse"] =
                    await client.PutAsync($"/api/Tournament/{createTournamentResponseData.TournamentId}/Cancel", httpContent, CancellationToken.None);
            }
        }
        
        [Then(@"the tournament is cancelled")]
        public void ThenTheTournamentIsCancelled()
        {
            var httpResponse = this.ScenarioContext.Get<HttpResponseMessage>("CancelTournamentHttpResponse");

            httpResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Given(@"some scores have been recorded")]
        public async Task GivenSomeScoresHaveBeenRecorded()
        {
            for (Int32 i = 0; i < 5; i++)
            {
                var createTournamentResponseData =
                    this.ScenarioContext.Get<CreateTournamentResponse>("CreateTournamentResponse");

                var recordMemberTournamentScoreRequest = IntegrationTestsTestData.RecordMemberTournamentScoreRequest;
                recordMemberTournamentScoreRequest.MemberId = Guid.NewGuid();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");
                    var requestSerialised = JsonConvert.SerializeObject(recordMemberTournamentScoreRequest);
                    var httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                    var httpResponse =
                        await client.PutAsync($"api/Tournament/{createTournamentResponseData.TournamentId}/RecordMemberScore", httpContent,
                            CancellationToken.None);

                    httpResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
                }
            }
        }
        
        [When(@"I request to complete the tournament")]
        public async Task WhenIRequestToCompleteTheTournament()
        {
            var createTournamentResponseData =
                this.ScenarioContext.Get<CreateTournamentResponse>("CreateTournamentResponse");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://127.0.0.1:{this.ManagementApiPort}");

                var httpContent = new StringContent(String.Empty, Encoding.UTF8, "application/json");

                this.ScenarioContext["CompleteTournamentHttpResponse"] =
                    await client.PutAsync($"/api/Tournament/{createTournamentResponseData.TournamentId}/Complete", httpContent, CancellationToken.None);
            }
        }
        
        [Then(@"the tournament is completed")]
        public void ThenTheTournamentIsCompleted()
        {
            var httpResponse = this.ScenarioContext.Get<HttpResponseMessage>("CompleteTournamentHttpResponse");

            httpResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }



    }
}