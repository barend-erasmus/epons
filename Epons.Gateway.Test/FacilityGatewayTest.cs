using System;
using Epons.Gateway.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epons.Gateway.Test
{
    [TestClass]
    public class FacilityGatewayTest
    {
        private Guid _facilityId = new Guid("de66f030-1f9b-4898-92e5-5eea88c94e34");

        [TestMethod]
        public void Find()
        {
            FacilityGateway gateway = new FacilityGateway();

            FacilityDto result = gateway.Find(_facilityId);

            Assert.IsNotNull(result);
        }
    }
}
