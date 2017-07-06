using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
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

        public PatientService(PatientRepository patientRepository, VisitRepository visitRepository, RSAIdentificationNumberValidator identificationNumberValidator)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _identificationNumberValidator = identificationNumberValidator;
        }

        public Patient Find(Guid id)
        {
            Patient patient = _patientRepository.FindById(id);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Patient Find(string identificationNumber)
        {
            Patient patient = _patientRepository.FindByIdentificationNumber(identificationNumber);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Patient Find(string firstname, string lastname, DateTime dateOfBirth)
        {
            Patient patient = _patientRepository.FindByDetails(firstname, lastname, dateOfBirth);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Pagination<EntityViews.Patient> List(Guid userId, Guid? facilityId, PatientType type, string query, int page, int size)
        {
            if (type == PatientType.Active)
            {

                Pagination<EntityViews.Patient> result = _patientRepository.ListActive((page - 1) * size, size, userId, facilityId, query);

                result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                return result;
            }
            else
            {
                throw new Exception("Invalid PatientType");
            }
        }

        public IList<EntityViews.Doctor> ListReferringDoctors(Guid patientId, Guid? facilityId)
        {
            if (facilityId.HasValue)
            {
                return _patientRepository.ListReferringDoctors(patientId).Where((x) => x.Facility.Id == facilityId).ToList();
            }
            else
            {
                return _patientRepository.ListReferringDoctors(patientId);
            }
        }

        private Patient ValidatePatient(Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrWhiteSpace(patient.IdentificationNumber))
                {
                    bool valid = _identificationNumberValidator.IsValid(patient.IdentificationNumber);

                    if (!valid)
                    {
                        patient.ValidationMessages.Add(new ValidationMessage()
                        {
                            Field = "IdentificationNumber",
                            Message = "Invalid Identification Number"
                        });
                    }
                }

                if (!patient.DateOfBirth.HasValue)
                {
                    patient.ValidationMessages.Add(new ValidationMessage()
                    {
                        Field = "DateOfBirth",
                        Message = "Invalid Date of Birth"
                    });
                }
            }

            return patient;
        }

        private EntityViews.Patient ValidatePatientView(EntityViews.Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrWhiteSpace(patient.IdentificationNumber))
                {
                    bool valid = _identificationNumberValidator.IsValid(patient.IdentificationNumber);

                    if (!valid)
                    {
                        patient.ValidationMessages.Add(new ValidationMessage()
                        {
                            Field = "IdentificationNumber",
                            Message = "Invalid Identification Number"
                        });
                    }
                }

                if (!patient.DateOfBirth.HasValue)
                {
                    patient.ValidationMessages.Add(new ValidationMessage()
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
