﻿using Epons.Domain.Enums;
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

        public Entities.Patient Find(Guid id)
        {
            Entities.Patient patient = _patientRepository.FindById(id);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Entities.Patient Find(string identificationNumber)
        {
            Entities.Patient patient = _patientRepository.FindByIdentificationNumber(identificationNumber);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Entities.Patient Find(string firstname, string lastname, DateTime dateOfBirth)
        {
            Entities.Patient patient = _patientRepository.FindByDetails(firstname, lastname, dateOfBirth);

            patient = ValidatePatient(patient);

            return patient;
        }

        public Models.Pagination<EntityViews.Patient> List(Guid userId, Guid? facilityId, PatientType type, string query, int page, int size)
        {
            if (type == PatientType.Active)
            {

                Models.Pagination<EntityViews.Patient> result = _patientRepository.ListActive((page - 1) * size, size, userId, facilityId, query);

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

        public IList<EntityViews.Doctor> ListTreatingDoctors(Guid patientId, Guid? facilityId)
        {
            if (facilityId.HasValue)
            {
                return _patientRepository.ListTreatingDoctors(patientId).Where((x) => x.Facility.Id == facilityId).ToList();
            }
            else
            {
                return _patientRepository.ListTreatingDoctors(patientId);
            }
        }

        private Entities.Patient ValidatePatient(Entities.Patient patient)
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

        private EntityViews.Patient ValidatePatientView(EntityViews.Patient patient)
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
