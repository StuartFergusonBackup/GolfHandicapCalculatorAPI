﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementAPI.Service.Tests.General
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BusinessLogic.Manager;
    using Database;
    using Database.Models;
    using DataTransferObjects.Responses;
    using GolfClub;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Shouldly;
    using Xunit;

    public class ReportingManagerTests
    {
        [Fact]
        public async Task ReportingManager_GetNumberOfMembersReport_ReportDataReturned()
        {
            String databaseName = Guid.NewGuid().ToString("N");
            ManagementAPIReadModel context = this.GetContext(databaseName);

            List<GolfClubMembershipReporting> reportingData = new List<GolfClubMembershipReporting>();

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-20),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 1,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 1"
            });

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-25),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 2,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 2"
                              });
            await context.GolfClubMembershipReporting.AddRangeAsync(reportingData, CancellationToken.None);
            await context.SaveChangesAsync(CancellationToken.None);

            Func<ManagementAPIReadModel> contextResolver = () => { return context; };

            ReportingManager reportingManager = new ReportingManager(contextResolver);

            GetNumberOfMembersReportResponse reportData = await reportingManager.GetNumberOfMembersReport(GolfClubTestData.AggregateId, CancellationToken.None);

            reportData.GolfClubId.ShouldBe(GolfClubTestData.AggregateId);
            reportData.NumberOfMembers.ShouldBe(reportingData.Count);
        }

        [Fact]
        public async Task ReportingManager_GetNumberOfMembersReport_NoMembers_ReportDataReturned()
        {
            String databaseName = Guid.NewGuid().ToString("N");
            ManagementAPIReadModel context = this.GetContext(databaseName);

            List<GolfClubMembershipReporting> reportingData = new List<GolfClubMembershipReporting>();
            
            Func<ManagementAPIReadModel> contextResolver = () => { return context; };

            ReportingManager reportingManager = new ReportingManager(contextResolver);

            GetNumberOfMembersReportResponse reportData = await reportingManager.GetNumberOfMembersReport(GolfClubTestData.AggregateId, CancellationToken.None);

            reportData.GolfClubId.ShouldBe(GolfClubTestData.AggregateId);
            reportData.NumberOfMembers.ShouldBe(reportingData.Count);
        }

        [Fact]
        public async Task ReportingManager_GetNumberOfMembersByHandicapCategoryReport_ReportDataReturned()
        {
            String databaseName = Guid.NewGuid().ToString("N");
            ManagementAPIReadModel context = this.GetContext(databaseName);

            List<GolfClubMembershipReporting> reportingData = new List<GolfClubMembershipReporting>();

            reportingData.Add(new GolfClubMembershipReporting
            {
                DateJoined = DateTime.Now,
                DateOfBirth = DateTime.Now.AddYears(-20),
                PlayerId = Guid.NewGuid(),
                GolfClubId = GolfClubTestData.AggregateId,
                GolfClubName = GolfClubTestData.Name,
                HandicapCategory = 1,
                PlayerGender = "M",
                PlayerName = "Test Player 1"
            });

            reportingData.Add(new GolfClubMembershipReporting
            {
                DateJoined = DateTime.Now,
                DateOfBirth = DateTime.Now.AddYears(-25),
                PlayerId = Guid.NewGuid(),
                GolfClubId = GolfClubTestData.AggregateId,
                GolfClubName = GolfClubTestData.Name,
                HandicapCategory = 2,
                PlayerGender = "M",
                PlayerName = "Test Player 2"
            });

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-25),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 2,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 3"
                              });

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-25),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 3,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 4"
                              });

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-25),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 3,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 5"
                              });

            reportingData.Add(new GolfClubMembershipReporting
                              {
                                  DateJoined = DateTime.Now,
                                  DateOfBirth = DateTime.Now.AddYears(-25),
                                  PlayerId = Guid.NewGuid(),
                                  GolfClubId = GolfClubTestData.AggregateId,
                                  GolfClubName = GolfClubTestData.Name,
                                  HandicapCategory = 3,
                                  PlayerGender = "M",
                                  PlayerName = "Test Player 6"
                              });

            await context.GolfClubMembershipReporting.AddRangeAsync(reportingData, CancellationToken.None);
            await context.SaveChangesAsync(CancellationToken.None);

            Func<ManagementAPIReadModel> contextResolver = () => { return context; };

            ReportingManager reportingManager = new ReportingManager(contextResolver);

            GetNumberOfMembersByHandicapCategoryReportResponse reportData = await reportingManager.GetNumberOfMembersByHandicapCategoryReport(GolfClubTestData.AggregateId, CancellationToken.None);

            reportData.GolfClubId.ShouldBe(GolfClubTestData.AggregateId);
            reportData.MembersByHandicapCategoryResponse.ShouldNotBeEmpty();
            reportData.MembersByHandicapCategoryResponse.Where(q => q.HandicapCategory == 1).Single().NumberOfMembers.ShouldBe(1);
            reportData.MembersByHandicapCategoryResponse.Where(q => q.HandicapCategory == 2).Single().NumberOfMembers.ShouldBe(2);
            reportData.MembersByHandicapCategoryResponse.Where(q => q.HandicapCategory == 3).Single().NumberOfMembers.ShouldBe(3);
        }

        [Fact]
        public async Task ReportingManager_GetNumberOfMembersByHandicapCategoryReport_NoMembers_ReportDataReturned()
        {
            String databaseName = Guid.NewGuid().ToString("N");
            ManagementAPIReadModel context = this.GetContext(databaseName);

            List<GolfClubMembershipReporting> reportingData = new List<GolfClubMembershipReporting>();

            Func<ManagementAPIReadModel> contextResolver = () => { return context; };

            ReportingManager reportingManager = new ReportingManager(contextResolver);

            GetNumberOfMembersByHandicapCategoryReportResponse reportData = await reportingManager.GetNumberOfMembersByHandicapCategoryReport(GolfClubTestData.AggregateId, CancellationToken.None);

            reportData.GolfClubId.ShouldBe(GolfClubTestData.AggregateId);
            reportData.MembersByHandicapCategoryResponse.ShouldBeEmpty();
        }


        private ManagementAPIReadModel GetContext(String databaseName)
        {
            DbContextOptionsBuilder<ManagementAPIReadModel> builder = new DbContextOptionsBuilder<ManagementAPIReadModel>()
                                                                      .UseInMemoryDatabase(databaseName)
                                                                      .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            ManagementAPIReadModel context = new ManagementAPIReadModel(builder.Options);

            return context;
        }
    }
}
