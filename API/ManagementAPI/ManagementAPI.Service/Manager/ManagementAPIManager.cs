﻿namespace ManagementAPI.Service.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Database;
    using Database.Models;
    using DataTransferObjects;
    using GolfClub;
    using GolfClub.DomainEvents;
    using GolfClubMembership;
    using Microsoft.EntityFrameworkCore;
    using Player;
    using Services;
    using Services.DataTransferObjects;
    using Shared.EventStore;
    using Shared.Exceptions;
    using Shared.General;
    using MembershipStatus = DataTransferObjects.MembershipStatus;

    public class ManagementAPIManager : IManagmentAPIManager
    {
        #region Fields

        /// <summary>
        /// The club repository
        /// </summary>
        private readonly IAggregateRepository<GolfClubAggregate> GolfClubRepository;

        /// <summary>
        /// The o auth2 security service
        /// </summary>
        private readonly IOAuth2SecurityService OAuth2SecurityService;

        /// <summary>
        /// The player repository
        /// </summary>
        private readonly IAggregateRepository<PlayerAggregate> PlayerRepository;

        /// <summary>
        /// The read model resolver
        /// </summary>
        private readonly Func<ManagementAPIReadModel> ReadModelResolver;

        /// <summary>
        /// The golf club membership repository
        /// </summary>
        private readonly IAggregateRepository<GolfClubMembershipAggregate> GolfClubMembershipRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementAPIManager" /> class.
        /// </summary>
        /// <param name="golfClubRepository">The golf club repository.</param>
        /// <param name="readModelResolver">The read model resolver.</param>
        /// <param name="playerRepository">The player repository.</param>
        /// <param name="oAuth2SecurityService">The o auth2 security service.</param>
        /// <param name="golfClubMembershipRepository">The golf club membership repository.</param>
        public ManagementAPIManager(IAggregateRepository<GolfClubAggregate> golfClubRepository,
                                    Func<ManagementAPIReadModel> readModelResolver,
                                    IAggregateRepository<PlayerAggregate> playerRepository,
                                    IOAuth2SecurityService oAuth2SecurityService,
                                    IAggregateRepository<GolfClubMembershipAggregate> golfClubMembershipRepository)
        {
            this.GolfClubRepository = golfClubRepository;
            this.ReadModelResolver = readModelResolver;
            this.PlayerRepository = playerRepository;
            this.OAuth2SecurityService = oAuth2SecurityService;
            this.GolfClubMembershipRepository = golfClubMembershipRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the club configuration.
        /// </summary>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Golf Club not found for Golf Club Id [{golfClubId}</exception>
        public async Task<GetGolfClubResponse> GetGolfClub(Guid golfClubId,
                                                           CancellationToken cancellationToken)
        {
            Guard.ThrowIfInvalidGuid(golfClubId, typeof(ArgumentNullException), "A Golf Club Id must be provided to retrieve a golf club");

            GetGolfClubResponse result = null;

            // Find the club configuration by id
            GolfClubAggregate golfClub = await this.GolfClubRepository.GetLatestVersion(golfClubId, cancellationToken);

            // Check we have found the club configuration
            if (!golfClub.HasBeenCreated)
            {
                throw new NotFoundException($"Golf Club not found for Golf Club Id [{golfClubId}]");
            }

            // We have found the club configuration
            result = new GetGolfClubResponse
                     {
                         AddressLine1 = golfClub.AddressLine1,
                         EmailAddress = golfClub.EmailAddress,
                         PostalCode = golfClub.PostalCode,
                         Name = golfClub.Name,
                         Town = golfClub.Town,
                         Website = golfClub.Website,
                         Region = golfClub.Region,
                         TelephoneNumber = golfClub.TelephoneNumber,
                         AddressLine2 = golfClub.AddressLine2,
                         Id = golfClub.AggregateId
                     };

            return result;
        }

        /// <summary>
        /// Gets the club list.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<GetGolfClubResponse>> GetGolfClubList(CancellationToken cancellationToken)
        {
            List<GetGolfClubResponse> result = new List<GetGolfClubResponse>();

            using(ManagementAPIReadModel context = this.ReadModelResolver())
            {
                List<GolfClub> golfClubs = await context.GolfClub.ToListAsync(cancellationToken);

                foreach (GolfClub golfClub in golfClubs)
                {
                    result.Add(new GetGolfClubResponse
                               {
                                   AddressLine1 = golfClub.AddressLine1,
                                   EmailAddress = golfClub.EmailAddress,
                                   Name = golfClub.Name,
                                   Town = golfClub.Town,
                                   Website = golfClub.WebSite,
                                   Region = golfClub.Region,
                                   TelephoneNumber = golfClub.TelephoneNumber,
                                   PostalCode = golfClub.PostalCode,
                                   AddressLine2 = golfClub.AddressLine2,
                                   Id = golfClub.GolfClubId
                               });
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the golf club members list.
        /// </summary>
        /// <param name="golfClubId">The golf club identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<GolfClubMembershipDetails>> GetGolfClubMembersList(Guid golfClubId,
                                                                                  CancellationToken cancellationToken)
        {
            List<GolfClubMembershipDetails> result = new List<GolfClubMembershipDetails>();

            // Rehydrate the Golf Club
            GolfClubAggregate golfClub = await this.GolfClubRepository.GetLatestVersion(golfClubId, cancellationToken);

            if (!golfClub.HasBeenCreated)
            {
                throw new NotFoundException($"Golf Club not found with Id {golfClubId}");
            }

            // Rehydrate the Golf Club Membership
            GolfClubMembershipAggregate golfClubMembership = await this.GolfClubMembershipRepository.GetLatestVersion(golfClubId, cancellationToken);
            
            // Translate
            List<MembershipDataTransferObject> membershipList = golfClubMembership.GetMemberships();

            foreach (MembershipDataTransferObject membership in membershipList)
            {
                result.Add(new GolfClubMembershipDetails
                           {
                               GolfClubId = golfClub.AggregateId,
                               PlayerId = membership.PlayerId,
                               PlayerGender = membership.PlayerGender,
                               PlayerDateOfBirth = membership.PlayerDateOfBirth.ToString("dd/MM/yyyy"),
                               PlayerFullName = membership.PlayerFullName,
                               MembershipNumber = membership.MembershipNumber,
                               MembershipStatus = (MembershipStatus)membership.Status,
                               Name = golfClub.Name
                           });
            }
            
            // Return
            return result;
        }

        /// <summary>
        /// Inserts the club information to read model.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task InsertGolfClubToReadModel(GolfClubCreatedEvent domainEvent,
                                                    CancellationToken cancellationToken)
        {
            Guard.ThrowIfNull(domainEvent, typeof(ArgumentNullException), "Domain event cannot be null");

            using(ManagementAPIReadModel context = this.ReadModelResolver())
            {
                // Check the club has not already been added to the read model
                Boolean isDuplicate = await context.GolfClub.Where(c => c.GolfClubId == domainEvent.AggregateId).AnyAsync(cancellationToken);

                if (!isDuplicate)
                {
                    GolfClub golfClub = new GolfClub
                                        {
                                            AddressLine1 = domainEvent.AddressLine1,
                                            EmailAddress = domainEvent.EmailAddress,
                                            Name = domainEvent.Name,
                                            Town = domainEvent.Town,
                                            Region = domainEvent.Region,
                                            TelephoneNumber = domainEvent.TelephoneNumber,
                                            AddressLine2 = domainEvent.AddressLine2,
                                            GolfClubId = domainEvent.AggregateId,
                                            PostalCode = domainEvent.PostalCode,
                                            WebSite = domainEvent.Website
                                        };

                    context.GolfClub.Add(golfClub);

                    await context.SaveChangesAsync(cancellationToken);
                }
            }
        }

        /// <summary>
        /// Registers the club administrator.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task RegisterClubAdministrator(RegisterClubAdministratorRequest request,
                                                    CancellationToken cancellationToken)
        {
            // Allocate a new club Id 
            Guid golfClubAggregateId = Guid.NewGuid();

            // Now create a club admin security user
            RegisterUserRequest registerUserRequest = new RegisterUserRequest
                                                      {
                                                          EmailAddress = request.EmailAddress,
                                                          Claims = new Dictionary<String, String>
                                                                   {
                                                                       {"GolfClubId", golfClubAggregateId.ToString()}
                                                                   },
                                                          Password = "123456",
                                                          PhoneNumber = request.TelephoneNumber,
                                                          Roles = new List<String>
                                                                  {
                                                                      "Club Administrator"
                                                                  }
                                                      };

            // Create the user
            await this.OAuth2SecurityService.RegisterUser(registerUserRequest, cancellationToken);
        }

        #endregion
    }
}