using Epons.Domain.Entities;
using Epons.Domain.Helpers;
using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Dapper.SqlMapper;

namespace Epons.Domain.Repositories
{
    public class PatientRepository
    {
        private DbExecutor _dbExecutor;

        public PatientRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
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

            return Mapper.MapPatient(patientResult, supportServicesResult);
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
                patients.Add(Mapper.MapPatientView(patientResult, facilitiesResult.ToList()));
            }

            return new Pagination<EntityViews.Patient>()
            {
                Count = dataResult.First().Count,
                Items = patients,
                Page = (start * length) + 1,
                Size = length
            };

        }

        // TODO: Move this to Visit Repository and Visit Service
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

        public IList<EntityViews.Doctor> ListReferringDoctors(Guid patientId)
        {
            var result = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[ListReferringDoctorsByPatientId]", new
            {
                patientId = patientId
            });

            return result.Select((x) => new EntityViews.Doctor()
            {
                ContactDetails = new DoctorContactDetails()
                {
                    ContactNumber = x.ContactNumber,
                    EmailAddress = x.EmailAddress
                },
                Facility = new Facility()
                {
                    Id = x.FacilityId,
                    Name = x.FacilityName
                },
                Fullname = x.Fullname,
                HPCSANumber = x.HPCSANumber,
                PracticeNumber = x.PracticeNumber
            }).ToList();
        }
    }
}
