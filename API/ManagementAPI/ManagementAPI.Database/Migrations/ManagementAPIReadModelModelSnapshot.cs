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
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ManagementAPI.Database.Models.ClubInformation", b =>
                {
                    b.Property<Guid>("ClubConfigurationId")
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

                    b.HasKey("ClubConfigurationId");

                    b.ToTable("ClubInformation");
                });

            modelBuilder.Entity("ManagementAPI.Database.Models.ClubMembershipRequest", b =>
                {
                    b.Property<Guid>("MembershipRequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<Guid>("ClubId");

                    b.Property<decimal>("ExactHandicap");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<int>("HandicapCategory");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("MembershipRequestedDateAndTime");

                    b.Property<string>("MiddleName");

                    b.Property<Guid>("PlayerId");

                    b.Property<int>("PlayingHandicap");

                    b.Property<int>("Status");

                    b.HasKey("MembershipRequestId");

                    b.ToTable("ClubMembershipRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
