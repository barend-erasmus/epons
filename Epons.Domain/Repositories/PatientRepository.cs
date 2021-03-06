﻿using Epons.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Dapper.SqlMapper;

namespace Epons.Domain.Repositories
{
    public class PatientRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public PatientRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};MultipleActiveResultSets=true;";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public int CalculateTimeSpent(Guid id, int overLastHours)
        {
            DateTime timestamp = DateTime.Now.Subtract(new TimeSpan(overLastHours, 0, 0));

            return _context.Details5.Where((x) => x.PatientId == id & x.Timestamp >= timestamp).ToList().Sum((y) => y.DurationofVisitinMinutes).Value;
        }

        public void Delete(Guid id)
        {
            _context.Database.ExecuteSqlCommand($"EXEC [EPONS_API].[DeleteByPatientId] '{id}';");
        }

        public Entities.Patient.Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            var patient = _context.Details2.FirstOrDefault((x) => x.Firstname == firstname && x.Lastname == lastname && x.DateOfBirth == dateOfBirth);

            if (patient == null)
            {
                return null;
            }

            return FindById(patient.PatientId);
        }

        public Entities.Patient.Patient FindById(Guid id)
        {
            return _context.Details2.Where((x) => x.PatientId == id).Select((x) => new Entities.Patient.Patient()
            {
                Address = new ValueObjects.Address()
                {
                    City = x.CityId.HasValue ? new ValueObjects.City()
                    {
                        Id = x.City.CityId,
                        Name = x.City.Name
                    } : null,
                    Country = x.CityId.HasValue ? new ValueObjects.Country()
                    {
                        Id = x.City.Province.Country.CountryId,
                        Name = x.City.Province.Country.Name
                    } : null,
                    PostalCode = x.PostalCode,
                    Province = x.CityId.HasValue ? new ValueObjects.Province()
                    {
                        Id = x.City.Province.ProvinceId,
                        Name = x.City.Province.Name
                    } : null,
                    ResidentialEnvironment = x.ResidentialEnvironmentId.HasValue ? new ValueObjects.ResidentialEnvironment()
                    {
                        Id = x.ResidentialEnvironment.ResidentialEnvironmentId,
                        Name = x.ResidentialEnvironment.Name
                    } : null,
                    Street = x.Street
                },
                Avatar = x.Avatar,
                ContactDetails = new ValueObjects.ContactDetails()
                {
                    ContactNumber = x.ContactNumber,
                    EmailAddress = null
                },
                DateOfBirth = x.DateOfBirth,
                Firstname = x.Firstname,
                Gender = x.GenderId.HasValue ? new ValueObjects.Gender()
                {
                    Id = x.Gender.GenderId,
                    Name = x.Gender.Name
                } : null,
                Id = id,
                IdentificationNumber = x.IdentificationNumber,
                ImpairmentGroup = x.ImpairmentGroupId.HasValue ? new ValueObjects.ImpairmentGroup()
                {
                    Id = x.ImpairmentGroup.ImpairmentGroupId,
                    Name = x.ImpairmentGroup.Name
                } : null,
                Lastname = x.Lastname,
                MeasurementToolDetails = x.MeasurementTools1.Select((y) => new Entities.Patient.MeasurementToolDetails()
                {
                    AssignedTimestamp = y.AssignedTimestamp,
                    DeassignedTimestamp = y.DeassignedTimestamp,
                    Frequency = new ValueObjects.Frequency()
                    {
                        Id = y.Frequency.FrequencyId,
                        Name = y.Frequency.Name
                    },
                    MeasurementTool = new ValueObjects.MeasurementTool()
                    {
                        Id = y.MeasurementTools2.MeasurementToolId,
                        Name = y.MeasurementTools2.Name
                    }
                }).OrderBy((y) => y.DeassignedTimestamp).ToList(),
                MedicalSchemeDetails = new Entities.Patient.MedicalSchemeDetails()
                {
                    MedicalScheme = x.MedicalSchemeId.HasValue ? new ValueObjects.MedicalScheme()
                    {
                        Id = x.MedicalScheme.MedicalSchemeId,
                        Name = x.MedicalScheme.Name
                    } : null,
                    MembershipNumber = x.MedicalSchemeMembershipNumber
                },
                Race = x.RaceId.HasValue ? new ValueObjects.Race()
                {
                    Id = x.Race.RaceId,
                    Name = x.Race.Name
                } : null,
                SupportServiceDetails = x.SupportServices.Where((y) => !string.IsNullOrEmpty(y.Text)).Select((y) => new Entities.Patient.SupportServiceDetails()
                {
                    SupportService = new ValueObjects.SupportService()
                    {
                        Id = y.SupportServices1.SupportServiceId,
                        Name = y.SupportServices1.Name
                    },
                    Text = y.Text
                }).ToList(),
                TeamMembers = x.TeamMembers.Select((y) => new Entities.Patient.TeamMember()
                {
                    AllocationTimestamp = y.AllocationTimestamp,
                    DeallocationTimestamp = y.DeallocationTimestamp,
                    Facility = new Entities.Patient.Facility()
                    {
                        Id = y.Detail.FacilityId,
                        Name = y.Detail.Name
                    },
                    User = new Entities.Patient.User()
                    {
                        Fullname = y.Details4.Firstname + " " + y.Details4.Lastname,
                        Id = y.Details4.UserId,
                        Permissions = y.Details4.Permissions.Select((z) => new Entities.Patient.UserPermission()
                        {
                            Facility = new Entities.Patient.Facility()
                            {
                                Id = z.Detail.FacilityId,
                                Name = z.Detail.Name
                            },
                            Permission = new ValueObjects.Permission()
                            {
                                Id = z.Permissions1.PermissionId,
                                Name = z.Permissions1.Name
                            }
                        }).ToList(),
                        Position = y.Details4.CurrentPositionId.HasValue ? _context.Positions.Where((a) => a.PositionId == y.Details4.CurrentPositionId).Select((a) => new ValueObjects.Position()
                        {
                            Id = a.PositionId,
                            Name = a.Name
                        }).FirstOrDefault() : null
                    }
                }).OrderBy((y) => y.DeallocationTimestamp).ToList(),
                Title = x.TitleId.HasValue ? new ValueObjects.Title()
                {
                    Id = x.Title.TitleId,
                    Name = x.Title.Name
                } : null
            }).FirstOrDefault();
        }

        public Entities.Patient.Patient FindByIdentificationNumber(string identificationNumber)
        {
            var patient = _context.Details2.FirstOrDefault((x) => x.IdentificationNumber == identificationNumber);

            if (patient == null)
            {
                return null;
            }

            return FindById(patient.PatientId);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListActiveAsFacility(Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {
            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);

                if (parsedDateOfBirth.Value == DateTime.MinValue)
                {
                    parsedDateOfBirth = null;
                }
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
            .Where((x) => x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId && y.DeallocationTimestamp == null) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId && y.DeallocationTimestamp == null) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));

            }

            return ListPatients(data, start, end);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListActiveAsSuperAdmin(int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);

                if (parsedDateOfBirth.Value == DateTime.MinValue)
                {
                    parsedDateOfBirth = null;
                }
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2;
            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            );

            }

            return ListPatients(data, start, end);
        }


        public Models.Pagination<EntityViews.Patient.Patient> ListActiveAsUser(Guid userId, Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {
            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
            .Where((x) => x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId && y.DeallocationTimestamp == null) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId && y.DeallocationTimestamp == null) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));

            }

            return ListPatients(data, start, end);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListDeceasedAsFacility(Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {

            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
             .Where((x) => x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) > 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) > 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));
            }

            return ListPatients(data, start, end);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListDeceasedAsUser(Guid userId, Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {
            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
            .Where((x) => x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) > 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId) > 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) > 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));

            }

            return ListPatients(data, start, end);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListDischargedAsFacility(Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {

            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
             .Where((x) => x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId) > 0 && x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId && y.DeallocationTimestamp == null) == 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId) > 0 && x.EpisodesOfCares.Count((y) => y.FacilityId == facilityId && y.DeallocationTimestamp == null) == 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));
            }

            return ListPatients(data, start, end);
        }

        public Models.Pagination<EntityViews.Patient.Patient> ListDischargedAsUser(Guid userId, Guid facilityId, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme)
        {
            var deathImpairmentGroupId = _context.ImpairmentGroups.FirstOrDefault((x) => x.Name == "Death - Death").ImpairmentGroupId;

            DateTime? parsedDateOfBirth = null;

            try
            {
                parsedDateOfBirth = Convert.ToDateTime(dateOfBirth);
            }
            catch { }

            IQueryable<EntityFramework.Details2> data = null;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(dateOfBirth) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(race) && string.IsNullOrEmpty(medicalScheme))
            {
                data = _context.Details2
            .Where((x) => x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId) > 0 && x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId && y.DeallocationTimestamp == null) == 0 && x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0);

            }
            else
            {
                data = _context.Details2
            .Where((x) =>
            x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId) > 0 && x.TeamMembers.Count((y) => y.FacilityId == facilityId && y.UserId == userId && y.DeallocationTimestamp == null) > 0 &&
            x.EpisodesOfCares.Count((y) => y.ImpairmentGroupId == deathImpairmentGroupId) == 0 && (
            (firstName == null ? true : x.Firstname.ToLower().Contains(firstName.ToLower())) &&
            (lastName == null ? true : x.Lastname.ToLower().Contains(lastName.ToLower())) &&
            (x.DateOfBirth.HasValue && parsedDateOfBirth.HasValue ? x.DateOfBirth == parsedDateOfBirth : true) &&
            (gender == null ? true : (x.Gender == null ? false : x.Gender.Name.ToLower() == gender.ToLower())) &&
            (race == null ? true : (x.Race == null ? false : x.Race.Name.ToLower() == race.ToLower())) &&
            (medicalScheme == null ? true : (x.MedicalScheme == null ? false : x.MedicalScheme.Name.ToLower() == medicalScheme.ToLower()))
            ));

            }

            return ListPatients(data, start, end);
        }

        private Models.Pagination<EntityViews.Patient.Patient> ListPatients(IQueryable<EntityFramework.Details2> data, int start, int end)
        {
            var result = data
            .OrderBy((x) => x.Lastname)
            .Skip(start)
            .Take(end - start)
            .Select((x) => new EntityViews.Patient.Patient()
            {
                DateOfBirth = x.DateOfBirth,
                Firstname = x.Firstname,
                Facilities = x.TeamMembers.Select((y) => new EntityViews.Patient.Facility()
                {
                    Id = y.Detail.FacilityId,
                    Name = y.Detail.Name,
                }).Distinct().ToList(),

                Gender = x.GenderId.HasValue ? new ValueObjects.Gender()
                {
                    Id = x.Gender.GenderId,
                    Name = x.Gender.Name
                } : null,
                Id = x.PatientId,
                IdentificationNumber = x.IdentificationNumber,
                Lastname = x.Lastname,
                MedicalSchemeDetails = new EntityViews.Patient.MedicalSchemeDetails()
                {
                    MedicalScheme = x.MedicalSchemeId.HasValue ? new ValueObjects.MedicalScheme()
                    {
                        Id = x.MedicalScheme.MedicalSchemeId,
                        Name = x.MedicalScheme.Name
                    } : null,
                    MembershipNumber = x.MedicalSchemeMembershipNumber
                },
                Race = x.RaceId.HasValue ? new ValueObjects.Race()
                {
                    Id = x.Race.RaceId,
                    Name = x.Race.Name
                } : null,
                Title = x.TitleId.HasValue ? new ValueObjects.Title()
                {
                    Id = x.Title.TitleId,
                    Name = x.Title.Name
                } : null
            }).ToList();

            int count = data.Count();

            return new Models.Pagination<EntityViews.Patient.Patient>()
            {
                Count = count,
                Start = start,
                End = end,
                Items = result
            };
        }
    }
}
