using Epons.Domain.Enums;
using Epons.Domain.Repositories;
using Epons.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository;
        private readonly VisitRepository _visitRepository;
        private readonly RSAIdentificationNumberValidator _identificationNumberValidator;

        public PatientService(PatientRepository patientRepository,
            VisitRepository visitRepository,
            RSAIdentificationNumberValidator identificationNumberValidator)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _identificationNumberValidator = identificationNumberValidator;
        }

        public Entities.Patient.Patient Find(Guid id)
        {
            Entities.Patient.Patient patient = _patientRepository.FindById(id);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Entities.Patient.Patient Find(string identificationNumber)
        {
            Entities.Patient.Patient patient = _patientRepository.FindByIdentificationNumber(identificationNumber);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Entities.Patient.Patient Find(string firstname, string lastname, DateTime dateOfBirth)
        {
            Entities.Patient.Patient patient = _patientRepository.FindByDetails(firstname, lastname, dateOfBirth);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Models.Pagination<EntityViews.Patient.Patient> List(Guid? userId, Guid? facilityId, PatientType type, string query, int page, int size)
        {
            if (type == PatientType.Active && userId.HasValue && facilityId.HasValue)
            {
                Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsUser(userId.Value, facilityId.Value);

                result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                return result;
            }
            else
            {
                throw new Exception("Invalid PatientType");
            }
        }

        private Entities.Patient.Patient ValidatePatient(Entities.Patient.Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrWhiteSpace(patient.IdentificationNumber))
                {
                    bool valid = _identificationNumberValidator.IsValid(patient.IdentificationNumber);

                    if (!valid)
                    {
                        patient.ValidationMessages.Add(new Models.ValidationMessage()
                        {
                            Field = "IdentificationNumber",
                            Message = "Invalid Identification Number"
                        });
                    }
                }

                if (!patient.DateOfBirth.HasValue)
                {
                    patient.ValidationMessages.Add(new Models.ValidationMessage()
                    {
                        Field = "DateOfBirth",
                        Message = "Invalid Date of Birth"
                    });
                }
            }

            return patient;
        }

        private EntityViews.Patient.Patient ValidatePatientView(EntityViews.Patient.Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrWhiteSpace(patient.IdentificationNumber))
                {
                    bool valid = _identificationNumberValidator.IsValid(patient.IdentificationNumber);

                    if (!valid)
                    {
                        patient.ValidationMessages.Add(new Models.ValidationMessage()
                        {
                            Field = "IdentificationNumber",
                            Message = "Invalid Identification Number"
                        });
                    }
                }

                if (!patient.DateOfBirth.HasValue)
                {
                    patient.ValidationMessages.Add(new Models.ValidationMessage()
                    {
                        Field = "DateOfBirth",
                        Message = "Invalid Date of Birth"
                    });
                }
            }

            return patient;
        }
    }
}
