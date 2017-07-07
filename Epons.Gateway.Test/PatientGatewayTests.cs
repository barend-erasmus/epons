using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epons.Gateway;
using Epons.Gateway.Models;

namespace Epons.Gateway.Test
{
    [TestClass]
    public class PatientGatewayTests
    {
        private Guid _patientId = new Guid("12D1D801-AFE4-4124-A4B9-03012754EFA7");
        private string _identificationNumber = "8105190070085";
        private string _firstname = "Vuso";
        private string _lastname = "Mngxozana";
        private DateTime _dateOfBirth = new DateTime(1977, 07, 16);

        [TestMethod]
        public void FindById()
        {
            PatientGateway gateway = new PatientGateway();

            PatientDto result = gateway.Find(_patientId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindByIdentificationNumber()
        {
            PatientGateway gateway = new PatientGateway();

            PatientDto result = gateway.Find(_identificationNumber);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindByDetails()
        {
            PatientGateway gateway = new PatientGateway();

            PatientDto result = gateway.Find(_firstname, _lastname, _dateOfBirth);

            Assert.IsNotNull(result);
        }
    }
}
