﻿using System;
using System.Linq;
using ManagementAPI.Service.Commands;
using Shouldly;
using Xunit;

namespace ManagementAPI.Service.Tests
{
    public class TournamentCommandTests
    {
        [Fact]
        public void CreateTournamentCommand_CanBeCreated_IsCreated()
        {
            CreateTournamentCommand command = CreateTournamentCommand.Create(TournamentTestData.CreateTournamentRequest);

            command.ShouldNotBeNull();
            command.CommandId.ShouldNotBe(Guid.Empty);
            command.CreateTournamentRequest.ShouldNotBeNull();
            command.CreateTournamentRequest.ShouldBe(TournamentTestData.CreateTournamentRequest); 
        }

        [Fact]
        public void RecordMemberTournamentScoreCommand_CanBeCreated_IsCreated()
        {
            RecordMemberTournamentScoreCommand command =
                RecordMemberTournamentScoreCommand.Create(TournamentTestData.AggregateId, TournamentTestData.RecordMemberTournamentScoreRequest);

            command.ShouldNotBeNull();
            command.CommandId.ShouldNotBe(Guid.Empty);
            command.TournamentId.ShouldBe(TournamentTestData.AggregateId);
            command.RecordMemberTournamentScoreRequest.ShouldNotBeNull();
            command.RecordMemberTournamentScoreRequest.ShouldBe(TournamentTestData.RecordMemberTournamentScoreRequest); 
        }

        [Fact]
        public void CompleteTournamentCommand_CanBeCreated_IsCreated()
        {
            CompleteTournamentCommand command = CompleteTournamentCommand.Create(TournamentTestData.AggregateId);

            command.ShouldNotBeNull();
            command.CommandId.ShouldNotBe(Guid.Empty);
            command.TournamentId.ShouldBe(TournamentTestData.AggregateId);
        }

        [Fact]
        public void CancelTournamentCommand_CanBeCreated_IsCreated()
        {
            CancelTournamentCommand command =
                CancelTournamentCommand.Create(TournamentTestData.AggregateId, TournamentTestData.CancelTournamentRequest);

            command.ShouldNotBeNull();
            command.CommandId.ShouldNotBe(Guid.Empty);
            command.TournamentId.ShouldBe(TournamentTestData.AggregateId);
            command.CancelTournamentRequest.ShouldNotBeNull();
            command.CancelTournamentRequest.ShouldBe(TournamentTestData.CancelTournamentRequest); 
        }
    }
}