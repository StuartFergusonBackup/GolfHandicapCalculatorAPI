﻿namespace ManagementAPI.Service.Common
{
    using System;
    using System.Collections.Generic;
    using DataTransferObjects;
    using Swashbuckle.AspNetCore.Filters;

    public class ClubMembershipListResponseExample : IExamplesProvider
    {
        #region Methods

        public Object GetExamples()
        {
            return new List<ClubMembershipResponse>
                   {
                       new ClubMembershipResponse
                       {
                           MembershipNumber = "000001",
                           AcceptedDateTime = DateTime.Now.Date,
                           GolfClubId = Guid.Parse("65DB9360-06A0-48D3-AE99-B927B7AA15AA"),
                           MembershipId = Guid.Parse("A9FF899A-84EB-4CD3-B735-CA8FB15F5283"),
                           RejectionReason = string.Empty,
                           RejectedDateTime = DateTime.MinValue,
                           Status = MembershipStatus.Accepted
                       }
                   };
        }

        #endregion
    }
}