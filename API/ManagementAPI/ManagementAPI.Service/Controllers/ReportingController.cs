﻿namespace ManagementAPI.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BusinessLogic.Manager;
    using DataTransferObjects.Responses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// The reporting manager
        /// </summary>
        private readonly IReportingManager ReportingManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingController"/> class.
        /// </summary>
        /// <param name="reportingManager">The reporting manager.</param>
        public ReportingController(IReportingManager reportingManager)
        {
            this.ReportingManager = reportingManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the number of members report.
        /// </summary>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GolfClub/{golfClubId}/numberofmembers")]
        public async Task<IActionResult> GetNumberOfMembersReport(Guid golfClubId,
                                                                  CancellationToken cancellationToken)
        {
            GetNumberOfMembersReportResponse reportData = await this.ReportingManager.GetNumberOfMembersReport(golfClubId, cancellationToken);

            return this.Ok(reportData);
        }

        /// <summary>
        /// Gets the number of members report.
        /// </summary>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GolfClub/{golfClubId}/numberofmembersbyhandicapcategory")]
        public async Task<IActionResult> GetNumberOfMembersByHandicapCategoryReport(Guid golfClubId,
                                                                  CancellationToken cancellationToken)
        {
            GetNumberOfMembersByHandicapCategoryReportResponse reportData = await this.ReportingManager.GetNumberOfMembersByHandicapCategoryReport(golfClubId, cancellationToken);

            return this.Ok(reportData);
        }
        
        [HttpGet]
        [Route("GolfClub/{golfClubId}/numberofmembersbytimeperiod/{timeperiod}")]
        public async Task<IActionResult> GetNumberOfMembersByTimePeriodReport(Guid golfClubId,
                                                                              String timePeriod,
                                                                              CancellationToken cancellationToken)
        {
            GetNumberOfMembersByTimePeriodReportResponse response =
                await this.ReportingManager.GetNumberOfMembersByTimePeriodReport(golfClubId, timePeriod, cancellationToken);

            return this.Ok(response);
        }

        #endregion
    }
}