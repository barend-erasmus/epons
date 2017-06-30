using Epons.Domain.Entities;
using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using static Dapper.SqlMapper;

namespace Epons.Domain.Repositories
{
    public class PatientRepository
    {
        private DbExecutor _dbExecutor;

        public PatientRepository()
        {
            _dbExecutor = new DbExecutor("data source=epons.dedicated.co.za;Initial Catalog=SADFM_Live;User ID=EPONS;Password=H@?PT@8sUeL32vBE;");
        }

        public Patient FindById(Guid id)
        {
            dynamic patientResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS_API].[FindPatientById]", new
            {
                PatientId = id
            });

            if (patientResult == null)
            {
                return null;
            }

            IList<dynamic> supportServicesResult = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[ListSupportServicesByPatientId]", new
            {
                PatientId = patientResult.Id
            });

            return MapPatient(patientResult, supportServicesResult);
        }

        public Patient FindByIdentificationNumber(string identificationNumber)
        {
            dynamic patientResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS_API].[FindPatientIdByIdentificationNumber]", new
            {
                IdentificationNumber = identificationNumber
            });

            if (patientResult == null)
            {
                return null;
            }

            return FindById(patientResult.Id);
        }

        public Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            dynamic patientResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS_API].[FindPatientIdByDetails]", new
            {
                Firstname = firstname,
                Lastname = lastname,
                DateOfBirth = dateOfBirth
            });

            if (patientResult == null)
            {
                return null;
            }

            return FindById(patientResult.Id);
        }

        public Pagination<EntityViews.Patient> ListActive(int start, int length, Guid userId, Guid? facilityId, string query)
        {
            GridReader gridReader = _dbExecutor.QueryMultiTableProc("[EPONS_API].[ListActivePatients]", new
            {
                start = start,
                length = length,
                userId = userId,
                facilityId = facilityId,
                query = query
            });

            IEnumerable<dynamic> patientsResult = gridReader.Read<dynamic>();
            IEnumerable<dynamic> facilitiesResult = gridReader.Read<dynamic>();
            IEnumerable<dynamic> dataResult = gridReader.Read<dynamic>();

            List<EntityViews.Patient> patients = new List<EntityViews.Patient>();

            foreach (dynamic patientResult in patientsResult)
            {
                patients.Add(MapPatientView(patientResult, facilitiesResult.ToList()));
            }

            return new Pagination<EntityViews.Patient>()
            {
                Count = dataResult.First().Count,
                Items = patients,
                Page = (start * length) + 1,
                Size = length
            };

        }

        public IList<EntityViews.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            var result = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[FindCompletedMeasurementToolsByPatientIdAndDateRange]", new
            {
                patientId = patientId,
                startDate = startDate,
                endDate = endDate
            });

            return result
                .GroupBy(x => x.DataSetId)
                .Select(x => new EntityViews.CompletedMeasurementTool()
                {
                    EndDate = x.First().EndDate,
                    StartDate = x.First().StartDate,
                    MeasurementTool = new MeasurementTool()
                    {
                        Id = x.First().MeasurementToolId,
                        Name = x.First().MeasurementTool,
                    },
                    ScoreItems = x.OrderBy(y => y.ScoreItemSortOrder).ToDictionary(y => (string)y.ScoreItem, y => (int)y.ScoreValue)
                }).ToList();
        }

        private EntityViews.Patient MapPatientView(dynamic patientResult, IList<dynamic> facilitiesResult)
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

        private Patient MapPatient(dynamic patientResult, IList<dynamic> supportServicesResult)
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
