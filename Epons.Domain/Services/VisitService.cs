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
    public class VisitService
    {
        private readonly VisitRepository _visitRepository;

        public VisitService(VisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public IList<EntityViews.Visit> List(Guid patientId)
        {
            return _visitRepository.List(patientId);
        }

        public IList<EntityViews.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _visitRepository.ListCompletedMeasurementTools(patientId, startDate, endDate);
        }
    }
}
