using Epons.Domain.Entities;
using Epons.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
