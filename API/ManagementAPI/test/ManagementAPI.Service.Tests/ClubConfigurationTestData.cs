﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Composition.Convention;
using ManagementAPI.ClubConfigurationAggregate;
using ManagementAPI.Service.Commands;
using ManagementAPI.Service.DataTransferObjects;
using HoleDataTransferObject = ManagementAPI.ClubConfigurationAggregate.HoleDataTransferObject;
using DTOHoleDataTransferObject = ManagementAPI.Service.DataTransferObjects.HoleDataTransferObject;

namespace ManagementAPI.Service.Tests
{
    public class ClubConfigurationTestData
    {
        
        
        public static Guid AggregateId = Guid.Parse("CD64A469-9593-49D6-988D-3842C532D23E");
        public static String Name = "Test Club Name";
        public static String AddressLine1 = "Address Line 1";
        public static String AddressLine2 = "Address Line 2";
        public static String Town = "Test Town";
        public static String Region = "Test Region";
        public static String PostalCode = "TE57 1NG";
        public static String TelephoneNumber = "123456789";
        public static String EmailAddress = "1@2.com";
        public static String Website = "www.website.com";

        public static Guid MeasuredCourseId= Guid.Parse("B2F334C2-03D3-48DB-9C6F-45FB1133F071");
        public static Guid InvalidMeasuredCourseId= Guid.Parse("F9FAB99E-D315-46FC-A3C6-DDC10FB4FA0E");
        public static String MeasuredCourseName = "Test Measured Course";
        public static String TeeColour = "White";
        public static Int32 StandardScratchScore = 70;

        public static Int32 HoleNumber = 1;
        public static Int32 LengthInYards = 150;
        public static Int32 LengthInMeters = 175;
        public static Int32 HolePar = 3;
        public static Int32 HoleStrokeIndex = 1;
        
        public static ClubConfigurationAggregate.ClubConfigurationAggregate GetEmptyClubConfigurationAggregate()
        {
            ClubConfigurationAggregate.ClubConfigurationAggregate aggregate= ClubConfigurationAggregate.ClubConfigurationAggregate.Create(AggregateId);

            return aggregate;
        }

        public static ClubConfigurationAggregate.ClubConfigurationAggregate GetCreatedClubConfigurationAggregate()
        {
            ClubConfigurationAggregate.ClubConfigurationAggregate aggregate= ClubConfigurationAggregate.ClubConfigurationAggregate.Create(AggregateId);

            aggregate.CreateClubConfiguration(Name, AddressLine1, AddressLine2, Town, Region,PostalCode, TelephoneNumber, Website, EmailAddress);

            return aggregate;
        }

        public static ClubConfigurationAggregate.ClubConfigurationAggregate GetClubConfigurationAggregateWithMeasuredCourse()
        {
            ClubConfigurationAggregate.ClubConfigurationAggregate aggregate= ClubConfigurationAggregate.ClubConfigurationAggregate.Create(AggregateId);

            aggregate.CreateClubConfiguration(Name, AddressLine1, AddressLine2, Town, Region,PostalCode, TelephoneNumber, Website, EmailAddress);

            MeasuredCourseDataTransferObject measuredCourseDataTransferObject = ClubConfigurationTestData.GetMeasuredCourseToAdd();

            aggregate.AddMeasuredCourse(measuredCourseDataTransferObject);

            return aggregate;
        }

        

        public static MeasuredCourseDataTransferObject GetMeasuredCourseToAdd(Int32 numberHoles = 18)
        {
            MeasuredCourseDataTransferObject result = new MeasuredCourseDataTransferObject();

            result.Name = MeasuredCourseName;
            result.MeasuredCourseId = MeasuredCourseId;
            result.StandardScratchScore = StandardScratchScore;
            result.TeeColour = TeeColour;

            result.Holes = new List<HoleDataTransferObject>();

            if (numberHoles >= 1) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 1, LengthInYards = 348, Par = 4, StrokeIndex = 10}); }
            if (numberHoles >= 2) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 2, LengthInYards = 402, Par = 4, StrokeIndex = 4}); }
            if (numberHoles >= 3) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 3, LengthInYards = 207, Par = 3, StrokeIndex = 14});}
            if (numberHoles >= 4) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 4, LengthInYards = 405, Par = 4, StrokeIndex = 8});}
            if (numberHoles >= 5) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 5, LengthInYards = 428, Par = 4, StrokeIndex = 2});}
            if (numberHoles >= 6) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 6, LengthInYards = 477, Par = 5, StrokeIndex = 12});}
            if (numberHoles >= 7) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 7, LengthInYards = 186, Par = 4, StrokeIndex = 16});}
            if (numberHoles >= 8) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 8, LengthInYards = 397, Par = 4, StrokeIndex = 6});}
            if (numberHoles >= 9) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 9, LengthInYards = 130, Par = 3, StrokeIndex = 18});}
            if (numberHoles >= 10) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 10, LengthInYards = 399, Par = 4, StrokeIndex = 3});}
            if (numberHoles >= 11) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 11, LengthInYards = 401, Par = 4, StrokeIndex = 13});}
            if (numberHoles >= 12) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 12, LengthInYards = 421, Par = 4, StrokeIndex = 1});}
            if (numberHoles >= 13) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 13, LengthInYards = 530, Par = 5, StrokeIndex = 11});}
            if (numberHoles >= 14) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 14, LengthInYards = 196, Par = 3, StrokeIndex = 5});}
            if (numberHoles >= 15) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 15, LengthInYards = 355, Par = 4, StrokeIndex = 7});}
            if (numberHoles >= 16) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 16, LengthInYards = 243, Par = 4, StrokeIndex = 15});}
            if (numberHoles >= 17) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 17, LengthInYards = 286, Par = 4, StrokeIndex = 17});}
            if (numberHoles >= 18) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 18, LengthInYards = 399, Par = 4, StrokeIndex = 9});}
            if (numberHoles >= 19) { result.Holes.Add(new HoleDataTransferObject {HoleNumber = 19, LengthInYards = 399, Par = 4, StrokeIndex = 9});}
            
            return result;
        }

        public static MeasuredCourseDataTransferObject GetMeasuredCourseToAddWithMissingHoles()
        {
            MeasuredCourseDataTransferObject result = new MeasuredCourseDataTransferObject();

            result.Name = MeasuredCourseName;
            result.MeasuredCourseId = MeasuredCourseId;
            result.StandardScratchScore = StandardScratchScore;
            result.TeeColour = TeeColour;

            result.Holes = new List<HoleDataTransferObject>();

            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 1, LengthInYards = 348, Par = 4, StrokeIndex = 10}); 
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 2, LengthInYards = 402, Par = 4, StrokeIndex = 4}); 
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 3, LengthInYards = 207, Par = 3, StrokeIndex = 14});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 4, LengthInYards = 405, Par = 4, StrokeIndex = 8});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 5, LengthInYards = 428, Par = 4, StrokeIndex = 2});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 5, LengthInYards = 477, Par = 5, StrokeIndex = 12});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 7, LengthInYards = 186, Par = 4, StrokeIndex = 16});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 8, LengthInYards = 397, Par = 4, StrokeIndex = 6});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 9, LengthInYards = 130, Par = 3, StrokeIndex = 18});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 10, LengthInYards = 399, Par = 4, StrokeIndex = 3});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 11, LengthInYards = 401, Par = 4, StrokeIndex = 13});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 12, LengthInYards = 421, Par = 4, StrokeIndex = 1});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 13, LengthInYards = 530, Par = 5, StrokeIndex = 11});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 14, LengthInYards = 196, Par = 3, StrokeIndex = 5});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 15, LengthInYards = 355, Par = 4, StrokeIndex = 7});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 16, LengthInYards = 243, Par = 4, StrokeIndex = 15});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 17, LengthInYards = 286, Par = 4, StrokeIndex = 17});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 18, LengthInYards = 399, Par = 4, StrokeIndex = 9});            
            
            return result;
        }

        public static MeasuredCourseDataTransferObject GetMeasuredCourseToAddWithMissingStrokeIndex()
        {
            MeasuredCourseDataTransferObject result = new MeasuredCourseDataTransferObject();

            result.Name = MeasuredCourseName;
            result.MeasuredCourseId = MeasuredCourseId;
            result.StandardScratchScore = StandardScratchScore;
            result.TeeColour = TeeColour;

            result.Holes = new List<HoleDataTransferObject>();

            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 1, LengthInYards = 348, Par = 4, StrokeIndex = 10}); 
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 2, LengthInYards = 402, Par = 4, StrokeIndex = 4}); 
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 3, LengthInYards = 207, Par = 3, StrokeIndex = 14});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 4, LengthInYards = 405, Par = 4, StrokeIndex = 8});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 5, LengthInYards = 428, Par = 4, StrokeIndex = 2});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 6, LengthInYards = 477, Par = 5, StrokeIndex = 1});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 7, LengthInYards = 186, Par = 4, StrokeIndex = 16});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 8, LengthInYards = 397, Par = 4, StrokeIndex = 6});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 9, LengthInYards = 130, Par = 3, StrokeIndex = 18});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 10, LengthInYards = 399, Par = 4, StrokeIndex = 3});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 11, LengthInYards = 401, Par = 4, StrokeIndex = 13});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 12, LengthInYards = 421, Par = 4, StrokeIndex = 1});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 13, LengthInYards = 530, Par = 5, StrokeIndex = 11});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 14, LengthInYards = 196, Par = 3, StrokeIndex = 5});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 15, LengthInYards = 355, Par = 4, StrokeIndex = 7});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 16, LengthInYards = 243, Par = 4, StrokeIndex = 15});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 17, LengthInYards = 286, Par = 4, StrokeIndex = 17});
            result.Holes.Add(new HoleDataTransferObject {HoleNumber = 18, LengthInYards = 399, Par = 4, StrokeIndex = 9});            
            
            return result;
        }

        public static CreateClubConfigurationRequest CreateClubConfigurationRequest = new CreateClubConfigurationRequest
        {
            Name = Name,
            AddressLine1 = AddressLine1,
            EmailAddress = EmailAddress,
            PostalCode = PostalCode,
            Town = Town,
            Website = Website,
            Region = Region,
            TelephoneNumber = TelephoneNumber,
            AddressLine2 = AddressLine2
        };

        public static AddMeasuredCourseToClubRequest AddMeasuredCourseToClubRequest =
            new AddMeasuredCourseToClubRequest()
            {
                ClubAggregateId = AggregateId,
                Name = MeasuredCourseName,
                StandardScratchScore = StandardScratchScore,
                TeeColour = TeeColour,
                Holes = new List<DataTransferObjects.HoleDataTransferObject>
                {
                    new DTOHoleDataTransferObject {HoleNumber = 1, LengthInYards = 348, Par = 4, StrokeIndex = 10},
                    new DTOHoleDataTransferObject {HoleNumber = 2, LengthInYards = 402, Par = 4, StrokeIndex = 4},
                    new DTOHoleDataTransferObject {HoleNumber = 3, LengthInYards = 207, Par = 3, StrokeIndex = 14},
                    new DTOHoleDataTransferObject {HoleNumber = 4, LengthInYards = 405, Par = 4, StrokeIndex = 8},
                    new DTOHoleDataTransferObject {HoleNumber = 5, LengthInYards = 428, Par = 4, StrokeIndex = 2},
                    new DTOHoleDataTransferObject {HoleNumber = 6, LengthInYards = 477, Par = 5, StrokeIndex = 12},
                    new DTOHoleDataTransferObject {HoleNumber = 7, LengthInYards = 186, Par = 4, StrokeIndex = 16},
                    new DTOHoleDataTransferObject {HoleNumber = 8, LengthInYards = 397, Par = 4, StrokeIndex = 6},
                    new DTOHoleDataTransferObject {HoleNumber = 9, LengthInYards = 130, Par = 3, StrokeIndex = 18},
                    new DTOHoleDataTransferObject {HoleNumber = 10, LengthInYards = 399, Par = 4, StrokeIndex = 3},
                    new DTOHoleDataTransferObject {HoleNumber = 11, LengthInYards = 401, Par = 4, StrokeIndex = 13},
                    new DTOHoleDataTransferObject {HoleNumber = 12, LengthInYards = 421, Par = 4, StrokeIndex = 1},
                    new DTOHoleDataTransferObject {HoleNumber = 13, LengthInYards = 530, Par = 5, StrokeIndex = 11},
                    new DTOHoleDataTransferObject {HoleNumber = 14, LengthInYards = 196, Par = 3, StrokeIndex = 5},
                    new DTOHoleDataTransferObject {HoleNumber = 15, LengthInYards = 355, Par = 4, StrokeIndex = 7},
                    new DTOHoleDataTransferObject {HoleNumber = 16, LengthInYards = 243, Par = 4, StrokeIndex = 15},
                    new DTOHoleDataTransferObject {HoleNumber = 17, LengthInYards = 286, Par = 4, StrokeIndex = 17},
                    new DTOHoleDataTransferObject {HoleNumber = 18, LengthInYards = 399, Par = 4, StrokeIndex = 9}
                }
            };

        public static CreateClubConfigurationCommand GetCreateClubConfigurationCommand()
        {            
            return CreateClubConfigurationCommand.Create(ClubConfigurationTestData.CreateClubConfigurationRequest);
        }

        public static AddMeasuredCourseToClubCommand GetAddMeasuredCourseToClubCommand()
        {
            return AddMeasuredCourseToClubCommand.Create(ClubConfigurationTestData.AddMeasuredCourseToClubRequest);
        }
        
    }
}