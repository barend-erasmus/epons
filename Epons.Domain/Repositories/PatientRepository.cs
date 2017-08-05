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

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public Entities.Patient FindById(Guid id)
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

        public Entities.Patient FindByIdentificationNumber(string identificationNumber)
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

        public Entities.Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
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

        public Models.Pagination<EntityViews.Patient> ListActive(int start, int length, Guid userId, Guid? facilityId, string query)
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

            return new Models.Pagination<EntityViews.Patient>()
            {
                Count = dataResult.First().Count,
                Items = patients,
                Page = (start * length) + 1,
                Size = length
            };

        }

        public IList<EntityViews.PatientMeasurementTool> ListMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _context.MeasurementTools1
                .Where((x) => x.PatientId == patientId && x.AssignedTimestamp < endDate && endDate < x.DeassignedTimestamp)
                .Select((x) => new EntityViews.PatientMeasurementTool()
                {
                    AssignedTimestamp = x.AssignedTimestamp,
                    DeassignedTimestamp = x.DeassignedTimestamp,
                    MeasurementTool = new ValueObjects.MeasurementTool()
                    {
                        Id = x.MeasurementTools2.MeasurementToolId,
                        Name = x.MeasurementTools2.Name
                    },
                    Frequency = new ValueObjects.Frequency()
                    {
                        Id = x.Frequency.FrequencyId,
                        Name = x.Frequency.Name
                    }
                }).ToList();
        }

        private Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
