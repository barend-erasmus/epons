using Epons.Domain.Entities;
using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public static class Mapper
    {
        public static EntityViews.Patient MapPatientView(dynamic patientResult, IList<dynamic> facilitiesResult)
        {
            return new EntityViews.Patient()
            {
                Id = patientResult.Id,
                Firstname = patientResult.Firstname,
                Lastname = patientResult.Lastname,
                DateOfBirth = patientResult.DateOfBirth,
                IdentificationNumber = patientResult.IdentificationNumber,
                Title = patientResult.TitleId == null ? null : new Title()
                {
                    Id = patientResult.TitleId,
                    Name = patientResult.Title
                },
                Gender = patientResult.GenderId == null ? null : new Gender()
                {
                    Id = patientResult.GenderId,
                    Name = patientResult.Gender
                },
                Race = patientResult.RaceId == null ? null : new Race()
                {
                    Id = patientResult.RaceId,
                    Name = patientResult.Race
                },
                MedicalSchemeDetails = new PatientMedicalSchemeDetails()
                {
                    MedicalScheme = patientResult.MedicalSchemeId == null ? null : new MedicalScheme()
                    {
                        Id = patientResult.MedicalSchemeId,
                        Name = patientResult.MedicalScheme
                    },
                    MembershipNumber = patientResult.MedicalSchemeNumber
                },
                Facilities = facilitiesResult.Where((x) => x.PatientId == patientResult.Id).Select((x) => new Facility()
                {
                    Id = x.FacilityId,
                    Name = x.FacilityName
                }).ToList()
            };
        }

        public static User MapUser(dynamic userResult)
        {
            return new User()
            {
                Id = userResult.Id,
                Username = userResult.Username,
                Firstname = userResult.Firstname,
                Lastname = userResult.Lastname,
                IdentificationNumber = userResult.IdentificationNumber,
                PracticeNumber = userResult.PracticeNumber,
                IsSuperAdmin = userResult.IsSuperAdmin,
                Title = userResult.TitleId == null ? null : new Title()
                {
                    Id = userResult.TitleId,
                    Name = userResult.Title
                },
                ProfessionalBody = userResult.ProfessionalBodyId == null ? null : new UserProfessionalBody()
                {
                    ProfessionalBody = new ProfessionalBody()
                    {
                        Id = userResult.ProfessionalBodyId,
                        Name = userResult.ProfessionalBody
                    },
                    Number = userResult.ProfessionalBodyRegistrationNumber,
                },
                ContactDetails = new UserContactDetails()
                {
                    ContactNumber = userResult.ContactNumber,
                    EmailAddress = userResult.EmailAddress
                },
                Position = userResult.PositionId == null ? null : new Position()
                {
                    Id = userResult.PositionId,
                    Name = userResult.Position
                },
                Permissions = new List<UserPermission>()
            };
        }

        public static Patient MapPatient(dynamic patientResult, IList<dynamic> supportServicesResult)
        {
            return new Patient()
            {
                Id = patientResult.Id,
                Firstname = patientResult.Firstname,
                Lastname = patientResult.Lastname,
                DateOfBirth = patientResult.DateOfBirth,
                IdentificationNumber = patientResult.IdentificationNumber,
                Title = patientResult.TitleId == null ? null : new Title()
                {
                    Id = patientResult.TitleId,
                    Name = patientResult.Title
                },
                Gender = patientResult.GenderId == null ? null : new Gender()
                {
                    Id = patientResult.GenderId,
                    Name = patientResult.Gender
                },
                Race = patientResult.RaceId == null ? null : new Race()
                {
                    Id = patientResult.RaceId,
                    Name = patientResult.Race
                },
                Address = new Models.PatientAddress()
                {
                    Street = patientResult.Street,
                    City = patientResult.CityId == null ? null : new City()
                    {
                        Id = patientResult.CityId,
                        Name = patientResult.City
                    },
                    Country = patientResult.CountryId == null ? null : new Country()
                    {
                        Id = patientResult.CountryId,
                        Name = patientResult.Country
                    },
                    PostalCode = patientResult.PostalCode,
                    Province = patientResult.ProvinceId == null ? null : new Province()
                    {
                        Id = patientResult.ProvinceId,
                        Name = patientResult.Province
                    },
                    ResidentialEnvironment = patientResult.ResidentialEnvironmentId == null ? null : new ResidentialEnvironment()
                    {
                        Id = patientResult.ResidentialEnvironmentId,
                        Name = patientResult.ResidentialEnvironment
                    },
                },
                ContactDetails = new PatientContactDetails()
                {
                    ContactNumber = patientResult.ContactNumber
                },
                MedicalSchemeDetails = new PatientMedicalSchemeDetails()
                {
                    MedicalScheme = patientResult.MedicalSchemeId == null ? null : new MedicalScheme()
                    {
                        Id = patientResult.MedicalSchemeId,
                        Name = patientResult.MedicalScheme
                    },
                    MembershipNumber = patientResult.MedicalSchemeNumber
                },
                SupportServices = supportServicesResult.Select((x) => new PatientSupportService()
                {
                    SupportService = new SupportService()
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    Text = x.Text
                }).ToList(),
                ImpairmentGroup = patientResult.ImpairmentGroupId == null ? null : new ImpairmentGroup()
                {
                    Id = patientResult.ImpairmentGroupId,
                    Name = patientResult.ImpairmentGroup
                },
                Avatar = patientResult.Avatar == null ? null : $"data:image/png;base64,{Convert.ToBase64String(patientResult.Avatar)}"
            };
        }
    }
}
