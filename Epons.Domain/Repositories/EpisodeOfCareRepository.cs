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

        public IList<EntityViews.EpisodeOfCare.EpisodeOfCare> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _context.EpisodesOfCares.Where((x) => x.PatientId == patientId && ((x.AllocationTimestamp < endDate && startDate < x.DeallocationTimestamp) || (x.AllocationTimestamp < endDate && !x.DeallocationTimestamp.HasValue))).Select((x) => new
            {
                AdmissionTimestamp = x.AllocationTimestamp,
                DischargeTimestamp = x.DeallocationTimestamp,
                FacilityId = x.FacilityId,
                ReferringDoctorId = x.ReferringDoctorId,
                UniqueHospitalNumber = x.AllocationNumber,
                ImpairmentGroupId = x.ImpairmentGroupId,
                DiagnosesId = x.ReasonForAdmissionId,
                OnsetTimestamp = x.ReasonForAdmissionTimestamp
            }).ToList().Select((x) => new EntityViews.EpisodeOfCare.EpisodeOfCare()
            {
                AdmissionTimestamp = x.AdmissionTimestamp,
                DischargeTimestamp = x.DischargeTimestamp,
                Facility = _context.Details.Where((y) => y.FacilityId == x.FacilityId).Select((y) => new
                {
                    Id = y.FacilityId,
                    Name = y.Name
                }).ToList().Select((y) => new EntityViews.EpisodeOfCare.Facility()
                {
                    Id = y.Id,
                    Name = y.Name
                }).FirstOrDefault(),
                ReferringDoctor = _context.Doctors.Where((y) => y.Id == x.ReferringDoctorId).Select((y) => new EntityViews.EpisodeOfCare.Doctor()
                {
                    ContactDetails = new ValueObjects.ContactDetails()
                    {
                        ContactNumber = y.ContactNumber,
                        EmailAddress = y.Email
                    },
                    Fullname = y.Name,
                    HPCSANumber = y.HPCSANumber,
                    PracticeNumber = y.PracticeName
                }).ToList().FirstOrDefault(),
                TreatingDoctor = _context.Doctors.Where((y) => y.Id == x.ReferringDoctorId).Select((y) => new EntityViews.EpisodeOfCare.Doctor()
                {
                    ContactDetails = new ValueObjects.ContactDetails()
                    {
                        ContactNumber = y.ContactNumber,
                        EmailAddress = y.Email
                    },
                    Fullname = y.Name,
                    HPCSANumber = y.HPCSANumber,
                    PracticeNumber = y.PracticeName
                }).ToList().FirstOrDefault(),
                UniqueHospitalNumber = x.UniqueHospitalNumber,
                ImpairmentGroup = _context.ImpairmentGroups.Where((y) => y.ImpairmentGroupId == x.ImpairmentGroupId).Select((y) => new
                {
                    Id = y.ImpairmentGroupId,
                    Name = y.Name
                }).ToList().Select((y) => new ValueObjects.ImpairmentGroup()
                {
                    Id = y.Id,
                    Name = y.Name
                }).FirstOrDefault(),
                Diagnoses = _context.ICD10Codes.Where((y) => y.ICD10CodeId == x.DiagnosesId).Select((y) => new
                {
                    Id = y.ICD10CodeId,
                    Name = y.Name,
                    Code = y.Code
                }).ToList().Select((y) => new ValueObjects.Diagnoses()
                {
                    Id = y.Id,
                    Name = $"{y.Code} - {y.Name}"
                }).FirstOrDefault(),
                OnsetTimestamp = x.OnsetTimestamp
            }).ToList();
        }
    }
}
