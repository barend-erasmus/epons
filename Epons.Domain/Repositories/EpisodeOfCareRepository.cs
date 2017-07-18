using Epons.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Dapper.SqlMapper;

namespace Epons.Domain.Repositories
{
    public class EpisodeOfCareRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public EpisodeOfCareRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public IList<EntityViews.EpisodeOfCare> List(Guid patientId)
        {
            return _context.EpisodesOfCares.Select((x) => new
            {
                AdmissionTimestamp = x.AllocationTimestamp,
                DischargeTimestamp = x.DeallocationTimestamp,
                FacilityId = x.FacilityId,
                ReferringDoctorId = x.ReferringDoctorId,
                UniqueHospitalNumber = x.AllocationNumber,
                ImpairmentGroupId = x.ImpairmentGroupId
            }).ToList().Select((x) => new EntityViews.EpisodeOfCare()
            {
                AdmissionTimestamp = x.AdmissionTimestamp,
                DischargeTimestamp = x.DischargeTimestamp,
                Facility = _context.Details.Where((y) => y.FacilityId == x.FacilityId).Select((y) => new
                {
                    Id = y.FacilityId,
                    Name = y.Name
                }).ToList().Select((y) => new ValueObjects.Facility()
                {
                    Id = y.Id,
                    Name = y.Name
                }).FirstOrDefault(),
                ReferringDoctor = _context.Doctors.Where((y) => y.Id == x.ReferringDoctorId).Select((y) => new
                {
                    Name = y.Name
                }).ToList().Select((y) => new ValueObjects.Doctor()
                {
                    Id = new Guid(),
                    Name = y.Name
                }).FirstOrDefault(),
                TreatingDoctor = _context.Doctors.Where((y) => y.Id == x.ReferringDoctorId).Select((y) => new
                {
                    Name = y.Name
                }).ToList().Select((y) => new ValueObjects.Doctor()
                {
                    Id = new Guid(),
                    Name = y.Name
                }).FirstOrDefault(),
                UniqueHospitalNumber = x.UniqueHospitalNumber,
                ImpairmentGroup = _context.ImpairmentGroups.Where((y) => y.ImpairmentGroupId == x.ImpairmentGroupId).Select((y) => new
                {
                    Id = y.ImpairmentGroupId,
                    Name = y.Name
                }).ToList().Select((y) => new ValueObjects.ImpairmentGroup()
                {
                    Id = y.Id,
                    Name = y.Name
                }).FirstOrDefault()
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
                ContactDetails = new Models.DoctorContactDetails()
                {
                    ContactNumber = x.ContactNumber,
                    EmailAddress = x.EmailAddress
                },
                Facility = new ValueObjects.Facility()
                {
                    Id = x.FacilityId,
                    Name = x.FacilityName
                },
                Fullname = x.Fullname,
                HPCSANumber = x.HPCSANumber,
                PracticeNumber = x.PracticeNumber
            }).ToList();
        }

        public IList<EntityViews.Doctor> ListTreatingDoctors(Guid patientId)
        {
            var result = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[ListTreatingDoctorsByPatientId]", new
            {
                patientId = patientId
            });

            return result.Select((x) => new EntityViews.Doctor()
            {
                ContactDetails = new Models.DoctorContactDetails()
                {
                    ContactNumber = x.ContactNumber,
                    EmailAddress = x.EmailAddress
                },
                Facility = new ValueObjects.Facility()
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
