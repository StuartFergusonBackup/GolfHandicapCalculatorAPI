﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;
using Shared.EventSourcing;

namespace ManagementAPI.Player.DomainEvents
{
    [JsonObject]
    public class ClubMembershipRequestedEvent : DomainEvent
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClubMembershipRequestedEvent" /> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public ClubMembershipRequestedEvent()
        {
            //We need this for serialisation, so just embrace the DDD crime
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClubMembershipRequestedEvent"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="clubId">The club identifier.</param>
        /// <param name="membershipRequestedDateAndTime">The membership requested date and time.</param>
        private ClubMembershipRequestedEvent(Guid aggregateId, Guid eventId, Guid clubId, DateTime membershipRequestedDateAndTime) : base(aggregateId, eventId)
        {
            this.ClubId = clubId;
            this.MembershipRequestedDateAndTime = membershipRequestedDateAndTime;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the club identifier.
        /// </summary>
        /// <value>
        /// The club identifier.
        /// </value>
        [JsonProperty]
        public Guid ClubId { get; private set; }

        /// <summary>
        /// Gets the membership requested date and time.
        /// </summary>
        /// <value>
        /// The membership requested date and time.
        /// </value>
        [JsonProperty]
        public DateTime MembershipRequestedDateAndTime { get; private set; }

        #endregion

        #region Public Methods

        #region public static ClubMembershipRequestedEvent Create()
        /// <summary>
        /// Creates the specified aggregate identifier.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="clubId">The club identifier.</param>
        /// <param name="membershipRequestedDateAndTime">The membership requested date and time.</param>
        /// <returns></returns>
        public static ClubMembershipRequestedEvent Create(Guid aggregateId, Guid clubId, DateTime membershipRequestedDateAndTime)
        {
            return new ClubMembershipRequestedEvent(aggregateId, Guid.NewGuid(), clubId,membershipRequestedDateAndTime);
        }
        #endregion

        #endregion
    }
}
