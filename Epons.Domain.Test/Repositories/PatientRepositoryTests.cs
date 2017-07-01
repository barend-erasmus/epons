using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epons.Domain.Repositories;
using Epons.Domain.Entities;
using Epons.Domain.Models;
using System.Collections.Generic;

namespace Epons.Domain.Test.Repositories
{
    [TestClass]
    public class PatientRepositoryTests
    {

        private Guid _patientId = new Guid("12D1D801-AFE4-4124-A4B9-03012754EFA7");
        private string _identificationNumber = "8105190070085";
        private string _firstname = "Vuso";
        private string _lastname = "Mngxozana";
        private DateTime _dateOfBirth = new DateTime(1977, 07, 16);
        private Guid _userId = new Guid("B9E49BEE-F576-45D6-8AE3-6FE08831E146");
        private Guid _facilityId = new Guid("5355E9EE-2B79-4F55-A64B-EA8321E79386");
        private Guid _listCompletedMeasurementToolsPatientId = new Guid("1130D8C7-959B-4DD6-BE67-C66A240F36BE");

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenNonExistingId_ShouldReturnNull()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(new Guid());

            Assert.IsNull(patient);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithFirstname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Firstname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithLastname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Lastname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithDateOfBirth()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.DateOfBirth);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithIdentificationNumber()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.IdentificationNumber);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithGender()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Gender);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithRace()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Race);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithTitle()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Title);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithAddress()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Address);
        }


        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithContactDetails()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.ContactDetails);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithMedicalShemeDetails()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.MedicalSchemeDetails);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithSupportServices()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.SupportServices);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithImpairmentGroup()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.ImpairmentGroup);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnPatientWithAvatar()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Avatar);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindByIdentificationNumber_GivenNonExistingIdentificationNumber_ShouldReturnNull()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindByIdentificationNumber("NONEXISTING");

            Assert.IsNull(patient);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindByIdentificationNumber_GivenExistingIdentificationNumber_ShouldReturnPatientWithFirstname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindByIdentificationNumber(_identificationNumber);

            Assert.IsNotNull(patient.Firstname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindByDetails_GivenExistingDetails_ShouldReturnPatientWithFirstname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindByDetails(_firstname, _lastname, _dateOfBirth);

            Assert.IsNotNull(patient.Firstname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindByDetails_GivenExistingDetailsUpperCase_ShouldReturnPatientWithFirstname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindByDetails(_firstname.ToUpper(), _lastname.ToUpper(), _dateOfBirth);

            Assert.IsNotNull(patient.Firstname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void ListActive_GivenExistingUserId_ShouldReturnListOfPatients()
        {
            PatientRepository patientRepository = new PatientRepository();

            Pagination<EntityViews.Patient> result = patientRepository.ListActive(0, 5, _userId, _facilityId, null);

            Assert.AreEqual(5, result.Items.Count);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void ListActive_GivenExistingUserIdAndNullFacilityId_ShouldReturnListOfPatients()
        {
            PatientRepository patientRepository = new PatientRepository();

            Pagination<EntityViews.Patient> result = patientRepository.ListActive(0, 5, _userId, null, null);

            Assert.AreEqual(5, result.Items.Count);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void ListCompletedMeasurementTools_GivenExistingPatientId_ShouldReturnListOfCompletedMeasurementTools()
        {
            PatientRepository patientRepository = new PatientRepository();

            IList<EntityViews.CompletedMeasurementTool> result = patientRepository.ListCompletedMeasurementTools(_listCompletedMeasurementToolsPatientId, DateTime.UtcNow.Subtract(new TimeSpan(365, 0, 0, 0)), DateTime.UtcNow);

            Assert.AreEqual(18, result.Count);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void ListReferringDoctors_GivenExistingPatientId_ShouldReturnListOfDoctors()
        {
            PatientRepository patientRepository = new PatientRepository();

            IList<EntityViews.Doctor> result = patientRepository.ListReferringDoctors(_patientId);

            Assert.AreEqual(1, result.Count);
        }
    }
}
