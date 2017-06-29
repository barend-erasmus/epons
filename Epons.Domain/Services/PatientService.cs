using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
using Epons.Domain.Repositories;
using System;

namespace Epons.Domain.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Get(Guid id)
        {
            return _patientRepository.FindById(id);
        }

        public Patient Get(string identificationNumber)
        {
            return _patientRepository.FindByIdentificationNumber(identificationNumber);
        }

        public Patient Get(string firstname, string lastname, DateTime dateOfBirth)
        {
            return _patientRepository.FindByDetails(firstname, lastname, dateOfBirth);
        }

        public Pagination<EntityViews.Patient> List(Guid userId, Guid? facilityId, PatientType type, string query, int page, int size)
        {
            if (type == PatientType.Active)
            {
                return _patientRepository.ListActive((page - 1) / size, size, userId, facilityId, query);
            }
            else
            {
                throw new Exception("Invalid PatientType");
            }
        }
    }
}
