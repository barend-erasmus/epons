using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epons.Domain.Repositories;
using Epons.Domain.Entities;

namespace Epons.Domain.Test
{
    [TestClass]
    public class PatientRepositoryTests
    {

        private string _patientId = "C49E9094-46A0-45AF-9752-003874230A8E";

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithFirstname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Firstname);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithLastname()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Lastname);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithDateOfBirth()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.DateOfBirth);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithIdentificationNumber()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.IdentificationNumber);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithGender()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Gender);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithRace()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Race);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithTitle()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Title);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithAddress()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.Address);
        }


        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithContactDetails()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.ContactDetails);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithMedicalShemeDetails()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.MedicalSchemeDetails);
        }

        [TestMethod]
        public void FindById_GivenExistingId_ShouldReturnPatientWithSupportServices()
        {
            PatientRepository patientRepository = new PatientRepository();

            Patient patient = patientRepository.FindById(_patientId);

            Assert.IsNotNull(patient.SupportServices);
        }
    }
}
