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
                Title = patientResult.TitleId == null ? null : new ValueObjects.Title()
                {
                    Id = patientResult.TitleId,
                    Name = patientResult.Title
                },
                Gender = patientResult.GenderId == null ? null : new ValueObjects.Gender()
                {
                    Id = patientResult.GenderId,
                    Name = patientResult.Gender
                },
                Race = patientResult.RaceId == null ? null : new ValueObjects.Race()
                {
                    Id = patientResult.RaceId,
                    Name = patientResult.Race
                },
                MedicalSchemeDetails = new Models.PatientMedicalSchemeDetails()
                {
                    MedicalScheme = patientResult.MedicalSchemeId == null ? null : new ValueObjects.MedicalScheme()
                    {
                        Id = patientResult.MedicalSchemeId,
                        Name = patientResult.MedicalScheme
                    },
                    MembershipNumber = patientResult.MedicalSchemeNumber
                },
                Facilities = facilitiesResult.Where((x) => x.PatientId == patientResult.Id).Select((x) => new ValueObjects.Facility()
                {
                    Id = x.FacilityId,
                    Name = x.FacilityName
                }).ToList()
            };
        }

        public static Entities.User MapUser(dynamic userResult, IList<dynamic> permissionsResult)
        {
            return new Entities.User()
            {
                Id = userResult.Id,
                Username = userResult.Username,
                Firstname = userResult.Firstname,
                Lastname = userResult.Lastname,
                IdentificationNumber = userResult.IdentificationNumber,
                PracticeNumber = userResult.PracticeNumber,
                IsSuperAdmin = userResult.IsSuperAdmin,
                Title = userResult.TitleId == null ? null : new ValueObjects.Title()
                {
                    Id = userResult.TitleId,
                    Name = userResult.Title
                },
                ProfessionalBody = userResult.ProfessionalBodyId == null ? null : new Models.UserProfessionalBody()
                {
                    ProfessionalBody = new ValueObjects.ProfessionalBody()
                    {
                        Id = userResult.ProfessionalBodyId,
                        Name = userResult.ProfessionalBody
                    },
                    Number = userResult.ProfessionalBodyRegistrationNumber,
                },
                ContactDetails = new Models.UserContactDetails()
                {
                    ContactNumber = userResult.ContactNumber,
                    EmailAddress = userResult.EmailAddress
                },
                Position = userResult.PositionId == null ? null : new ValueObjects.Position()
                {
                    Id = userResult.PositionId,
                    Name = userResult.Position
                },
                Permissions = permissionsResult.Select((x) => new Models.UserPermission()
                {
                    Facility = new ValueObjects.Facility()
                    {
                        Id = x.FacilityId,
                        Name = x.Facility
                    },
                    Permission = new ValueObjects.Permission()
                    {
                        Id = x.PermissionId,
                        Name = x.Permission
                    }
                }).ToList()
            };
        }

        public static Entities.Patient MapPatient(dynamic patientResult, IList<dynamic> supportServicesResult)
        {
            return new Entities.Patient()
            {
                Id = patientResult.Id,
                Firstname = patientResult.Firstname,
                Lastname = patientResult.Lastname,
                DateOfBirth = patientResult.DateOfBirth,
                IdentificationNumber = patientResult.IdentificationNumber,
                Title = patientResult.TitleId == null ? null : new ValueObjects.Title()
                {
                    Id = patientResult.TitleId,
                    Name = patientResult.Title
                },
                Gender = patientResult.GenderId == null ? null : new ValueObjects.Gender()
                {
                    Id = patientResult.GenderId,
                    Name = patientResult.Gender
                },
                Race = patientResult.RaceId == null ? null : new ValueObjects.Race()
                {
                    Id = patientResult.RaceId,
                    Name = patientResult.Race
                },
                Address = new Models.PatientAddress()
                {
                    Street = patientResult.Street,
                    City = patientResult.CityId == null ? null : new ValueObjects.City()
                    {
                        Id = patientResult.CityId,
                        Name = patientResult.City
                    },
                    Country = patientResult.CountryId == null ? null : new ValueObjects.Country()
                    {
                        Id = patientResult.CountryId,
                        Name = patientResult.Country
                    },
                    PostalCode = patientResult.PostalCode,
                    Province = patientResult.ProvinceId == null ? null : new ValueObjects.Province()
                    {
                        Id = patientResult.ProvinceId,
                        Name = patientResult.Province
                    },
                    ResidentialEnvironment = patientResult.ResidentialEnvironmentId == null ? null : new ValueObjects.ResidentialEnvironment()
                    {
                        Id = patientResult.ResidentialEnvironmentId,
                        Name = patientResult.ResidentialEnvironment
                    },
                },
                ContactDetails = new Models.PatientContactDetails()
                {
                    ContactNumber = patientResult.ContactNumber
                },
                MedicalSchemeDetails = new Models.PatientMedicalSchemeDetails()
                {
                    MedicalScheme = patientResult.MedicalSchemeId == null ? null : new ValueObjects.MedicalScheme()
                    {
                        Id = patientResult.MedicalSchemeId,
                        Name = patientResult.MedicalScheme
                    },
                    MembershipNumber = patientResult.MedicalSchemeNumber
                },
                SupportServices = supportServicesResult.Select((x) => new Models.PatientSupportService()
                {
                    SupportService = new ValueObjects.SupportService()
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    Text = x.Text
                }).ToList(),
                ImpairmentGroup = patientResult.ImpairmentGroupId == null ? null : new ValueObjects.ImpairmentGroup()
                {
                    Id = patientResult.ImpairmentGroupId,
                    Name = patientResult.ImpairmentGroup
                },
                Avatar = patientResult.Avatar == null ? null : $"data:image/png;base64,{Convert.ToBase64String(patientResult.Avatar)}"
            };
        }
    }
}
