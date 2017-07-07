using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epons.Domain.Repositories;
using System.Collections.Generic;

namespace Epons.Domain.Test.Repositories
{
    [TestClass]
    public class VisitRepositoryTest
    {
        private readonly Guid _listCompletedMeasurementToolsPatientId = new Guid("1130D8C7-959B-4DD6-BE67-C66A240F36BE");

        [TestMethod, TestCategory("IntegrationTest")]
        public void ListCompletedMeasurementTools_GivenExistingPatientId_ShouldReturnListOfCompletedMeasurementTools()
        {
            VisitRepository visitRepository = new VisitRepository();

            IList<EntityViews.CompletedMeasurementTool> result = visitRepository.ListCompletedMeasurementTools(_listCompletedMeasurementToolsPatientId, DateTime.UtcNow.Subtract(new TimeSpan(365, 0, 0, 0)), DateTime.UtcNow);

            Assert.AreEqual(22, result.Count);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void List_GivenExistingPatientId_ShouldReturnListOfVisit()
        {
            VisitRepository visitRepository = new VisitRepository();

            IList<EntityViews.Visit> result = visitRepository.List(_listCompletedMeasurementToolsPatientId);

            Assert.AreEqual(332, result.Count);
        }
    }
}
