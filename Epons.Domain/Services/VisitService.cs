using Epons.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.Services
{
    public class VisitService
    {
        private readonly VisitRepository _visitRepository;

        public VisitService(VisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public IList<EntityViews.Visit.Visit> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddHours(24);

            return _visitRepository.List(patientId, startDate, endDate).OrderBy((x) => x.Timestamp).ToList();
        }

        public IList<EntityViews.CompletedMeasurementTool.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddHours(24);

            return _visitRepository.ListCompletedMeasurementTools(patientId, startDate, endDate);
        }
    }
}
