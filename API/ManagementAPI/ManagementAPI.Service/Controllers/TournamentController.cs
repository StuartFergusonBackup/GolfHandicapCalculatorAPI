﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ManagementAPI.Service.Commands;
using ManagementAPI.Service.Common;
using ManagementAPI.Service.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CommandHandling;

namespace ManagementAPI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    [Authorize]
    public class TournamentController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// The command router
        /// </summary>
        private readonly ICommandRouter CommandRouter;

        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentController"/> class.
        /// </summary>
        /// <param name="commandRouter">The command router.</param>
        public TournamentController(ICommandRouter commandRouter)
        {
            this.CommandRouter = commandRouter;
        }

        #endregion

        #region Public Methods

        #region public async Task<IActionResult> PostTournament([FromBody]CreateTournamentRequest request, CancellationToken cancellationToken)        
        /// <summary>
        /// Posts the tournament.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateTournamentResponse), 200)]
        [Authorize(Policy = PolicyNames.CreateTournamentPolicy)]
        public async Task<IActionResult> PostTournament([FromBody]CreateTournamentRequest request, CancellationToken cancellationToken)
        {
            // Get the Golf Club Id claim from the user            
            Claim golfClubIdClaim = ClaimsHelper.GetUserClaim(this.User, CustomClaims.GolfClubId);

            // Create the command
            CreateTournamentCommand command = CreateTournamentCommand.Create(Guid.Parse(golfClubIdClaim.Value),  request);

            // Route the command
            await this.CommandRouter.Route(command,cancellationToken);

            // return the result
            return this.Ok(command.Response);
        }
        #endregion

        #region public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, [FromBody]RecordMemberTournamentScoreRequest request, CancellationToken cancellationToken)        
        /// <summary>
        /// Posts the tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut]      
        [ProducesResponseType(204)]
        [Route("{tournamentId}/RecordMemberScore")]
        [Authorize(Policy = PolicyNames.RecordPlayerScoreForTournamentPolicy)]
        public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, [FromBody]RecordMemberTournamentScoreRequest request, CancellationToken cancellationToken)
        {
            // Create the command
            RecordMemberTournamentScoreCommand command = RecordMemberTournamentScoreCommand.Create(tournamentId, request);

            // Route the command
            await this.CommandRouter.Route(command,cancellationToken);

            // return the result
            return this.Ok(command.Response);
        }
        #endregion

        #region public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, CancellationToken cancellationToken)        
        /// <summary>
        /// Posts the tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut]      
        [ProducesResponseType(204)]
        [Route("{tournamentId}/Complete")]
        [Authorize(Policy = PolicyNames.CompleteTournamentPolicy)]
        public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, CancellationToken cancellationToken)
        {
            // Create the command
            CompleteTournamentCommand command = CompleteTournamentCommand.Create(tournamentId);

            // Route the command
            await this.CommandRouter.Route(command,cancellationToken);

            // return the result
            return this.Ok(command.Response);
        }
        #endregion

        #region public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, [FromBody]CancelTournamentRequest request, CancellationToken cancellationToken)        
        /// <summary>
        /// Posts the tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut]      
        [ProducesResponseType(204)]
        [Route("{tournamentId}/Cancel")]
        [Authorize(Policy = PolicyNames.CancelTournamentPolicy)]
        public async Task<IActionResult> PutTournament([FromRoute] Guid tournamentId, [FromBody]CancelTournamentRequest request, CancellationToken cancellationToken)
        {
            // Create the command
            CancelTournamentCommand command = CancelTournamentCommand.Create(tournamentId, request);

            // Route the command
            await this.CommandRouter.Route(command,cancellationToken);

            // return the result
            return this.Ok(command.Response);
        }
        #endregion

        #region public async Task<IActionResult> PutTournamentProduceResult([FromRoute] Guid tournamentId, CancellationToken cancellationToken)        
        /// <summary>
        /// Posts the tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut]      
        [ProducesResponseType(204)]
        [Route("{tournamentId}/ProduceResult")]
        [Authorize(Policy = PolicyNames.ProduceTournamentResultPolicy)]
        public async Task<IActionResult> PutTournamentProduceResult([FromRoute] Guid tournamentId, CancellationToken cancellationToken)
        {
            // Create the command
            ProduceTournamentResultCommand command = ProduceTournamentResultCommand.Create(tournamentId);

            // Route the command
            await this.CommandRouter.Route(command,cancellationToken);

            // return the result
            return this.Ok(command.Response);
        }
        #endregion

        #endregion
    }
}