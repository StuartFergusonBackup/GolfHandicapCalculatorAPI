﻿// <auto-generated />
using System;
using ManagementAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementAPI.Database.Migrations
{
    [DbContext(typeof(ManagementAPIReadModel))]
    partial class ManagementAPIReadModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ManagementAPI.Database.Models.GolfClub", b =>
                {
                    b.Property<Guid>("GolfClubId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("Town");

                    b.Property<string>("WebSite");

                    b.HasKey("GolfClubId");

                    b.ToTable("GolfClub");
                });

            modelBuilder.Entity("ManagementAPI.Database.Models.PlayerClubMembership", b =>
                {
                    b.Property<Guid>("PlayerId");

                    b.Property<Guid>("GolfClubId");

                    b.Property<DateTime?>("AcceptedDateTime");

                    b.Property<string>("GolfClubName");

                    b.Property<Guid>("MembershipId");

                    b.Property<string>("MembershipNumber");

                    b.Property<DateTime?>("RejectedDateTime");

                    b.Property<string>("RejectionReason");

                    b.Property<int>("Status");

                    b.HasKey("PlayerId", "GolfClubId");

                    b.ToTable("PlayerClubMembership");
                });
#pragma warning restore 612, 618
        }
    }
}
