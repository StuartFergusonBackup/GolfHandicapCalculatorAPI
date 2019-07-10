﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using ManagementAPI.GolfClub;
using ManagementAPI.GolfClubMembership;
using ManagementAPI.Player;
using ManagementAPI.Service.CommandHandlers;
using ManagementAPI.Service.Manager;
using ManagementAPI.Service.Services;
using ManagementAPI.Tournament;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Shared.CommandHandling;
using Shared.EventStore;
using StructureMap;
using StructureMap.Pipeline;
using ESLogger = EventStore.ClientAPI;

namespace ManagementAPI.Service.Bootstrapper
{
    using EventHandling;
    using HandicapCalculationProcess;
    using Services.DomainServices;

    [ExcludeFromCodeCoverage]
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {            
            String connString = Startup.Configuration.GetValue<String>("EventStoreSettings:ConnectionString");            
            String connectionName = Startup.Configuration.GetValue<String>("EventStoreSettings:ConnectionName");
            Int32 httpPort = Startup.Configuration.GetValue<Int32>("EventStoreSettings:HttpPort");

            EventStoreConnectionSettings settings = EventStoreConnectionSettings.Create(connString, connectionName, httpPort);

            For<IEventStoreContext>().Use<EventStoreContext>().Singleton().Ctor<EventStoreConnectionSettings>().Is(settings);

            Func<String, IEventStoreContext> eventStoreContextFunc = (connectionString) =>
            {  
                EventStoreConnectionSettings connectionSettings = EventStoreConnectionSettings.Create(connectionString,connectionName, httpPort);

                ExplicitArguments args = new ExplicitArguments().Set(connectionSettings);

                return Startup.Container.GetInstance<IEventStoreContext>(args);
            };

            Func<EventStoreConnectionSettings, IEventStoreConnection> eventStoreConnectionFunc = (connectionSettings) =>
            {  
                return EventStoreConnection.Create(connectionSettings.ConnectionString);                
            };

            For<IDomainEventHandler>().Use<GolfClubDomainEventHandler>().Named("GolfClub");
            For<IDomainEventHandler>().Use<GolfClubMembershipDomainEventHandler>().Named("GolfClubMembership");
            For<IDomainEventHandler>().Use<TournamentDomainEventHandler>().Named("Tournament");
            For<IDomainEventHandler>().Use<HandicapCalculationDomainEventHandler>().Named("HandicapCalculator");

            Func<String, IDomainEventHandler> domainEventHanderFunc = (name) => Startup.Container.GetInstance<IDomainEventHandler>(name);

            For<Func<EventStoreConnectionSettings, IEventStoreConnection>>().Use(eventStoreConnectionFunc);

            For<ESLogger.ILogger>().Use<ESLogger.Common.Log.ConsoleLogger>().Singleton();
            For<ICommandRouter>().Use<CommandRouter>().Singleton();
            For<IAggregateRepository<GolfClubAggregate>>()
                .Use<AggregateRepository<GolfClubAggregate>>().Singleton();
            For<IAggregateRepository<GolfClubMembershipAggregate>>()
                .Use<AggregateRepository<GolfClubMembershipAggregate>>().Singleton();
            For<IAggregateRepository<TournamentAggregate>>()
                .Use<AggregateRepository<TournamentAggregate>>().Singleton();
            For<IAggregateRepository<PlayerAggregate>>()
                .Use<AggregateRepository<PlayerAggregate>>().Singleton();
            For<IAggregateRepository<HandicapCalculationProcessAggregate>>()
                .Use<AggregateRepository<HandicapCalculationProcessAggregate>>().Singleton();

            For<IHandicapAdjustmentCalculatorService>().Use<HandicapAdjustmentCalculatorService>();
            For<IManagmentAPIManager>().Use<ManagementAPIManager>().Singleton();
            For<ISecurityService>().Use<SecurityService>().Singleton();
            For<IGolfClubMembershipApplicationService>().Use<GolfClubMembershipApplicationService>().Singleton();
            For<ITournamentApplicationService>().Use<TournamentApplicationService>().Singleton();

            this.For<IHandicapCalculationProcessorService>().Use<HandicapCalculationProcessorService>().Transient();
        }
    }
}
