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
        private readonly ValidatorService _validatorService;

        public PatientService(PatientRepository patientRepository,
            VisitRepository visitRepository,
            ValidatorService validatorService)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _validatorService = validatorService;
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

        public Models.Pagination<EntityViews.Patient.Patient> List(Guid? userId, Guid? facilityId, PatientType type, int start, int end, string firstName, string lastName, string dateOfBirth, string gender, string race, string medicalScheme, bool superAdmin)
        {
            if (type == PatientType.Active)
            {

                if (facilityId.HasValue && userId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsUser(userId.Value, facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;

                }
                else if (facilityId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsFacility(facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else if (superAdmin)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsSuperAdmin(start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else
                {
                    throw new Exception("Expected FacilityId and UserId or FacilityId");
                }
            }
            else if (type == PatientType.Discharged)
            {

                if (facilityId.HasValue && userId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListDischargedAsUser(userId.Value, facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;

                }
                else if (facilityId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListDischargedAsFacility(facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else if (superAdmin)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsSuperAdmin(start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else
                {
                    throw new Exception("Expected FacilityId and UserId or FacilityId");
                }
            }
            else if (type == PatientType.Deceased)
            {

                if (facilityId.HasValue && userId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListDeceasedAsUser(userId.Value, facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;

                }
                else if (facilityId.HasValue)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListDeceasedAsFacility(facilityId.Value, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else if (superAdmin)
                {
                    Models.Pagination<EntityViews.Patient.Patient> result = _patientRepository.ListActiveAsSuperAdmin(start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme);

                    result.Items = result.Items.Select((patient) => ValidatePatientView(patient)).ToList();

                    return result;
                }
                else
                {
                    throw new Exception("Expected FacilityId and UserId or FacilityId");
                }
            }
            else
            {
                throw new Exception("Invalid PatientType");
            }
        }

        public int[] TimeSpent(Guid id)
        {
            return new int[3] {
                _patientRepository.CalculateTimeSpent(id, 72),
                _patientRepository.CalculateTimeSpent(id, 48),
                _patientRepository.CalculateTimeSpent(id, 24)
                };
        }

        public void Delete(Guid id)
        {
            _patientRepository.Delete(id);
        }

        private Entities.Patient.Patient ValidatePatient(Entities.Patient.Patient patient)
        {
            if (patient != null)
            {
                if (!string.IsNullOrWhiteSpace(patient.IdentificationNumber))
                {
                    bool valid = _validatorService.IdentificationNumber(patient.IdentificationNumber);

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
                    bool valid = _validatorService.IdentificationNumber(patient.IdentificationNumber);

                    if (!valid)
                    {
                        patient.ValidationMessages.Add(new Models.ValidationMessage()
                        {
                            Field = "IdentificationNumber",
                            Message = "Invalid Identification Number"
                        });
                    }
                }
                else
                {
                    patient.ValidationMessages.Add(new Models.ValidationMessage()
                    {
                        Field = "IdentificationNumber",
                        Message = "No Identification Number"
                    });
                }

                if (!patient.DateOfBirth.HasValue)
                {
                    patient.ValidationMessages.Add(new Models.ValidationMessage()
                    {
                        Field = "DateOfBirth",
                        Message = "No Date of Birth"
                    });
                }
            }

            return patient;
        }
    }
}
