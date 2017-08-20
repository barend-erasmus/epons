using Epons.Domain.Enums;
using Epons.Domain.Repositories;
using Epons.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.Services
{
    public class EpisodeOfCareService
    {
        private readonly EpisodeOfCareRepository _episodeOfCareRepository;

        public EpisodeOfCareService(EpisodeOfCareRepository episodeOfCareRepository)
        {
            _episodeOfCareRepository = episodeOfCareRepository;
        }

        public IList<EntityViews.EpisodeOfCare.EpisodeOfCare> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddHours(24);

            return _episodeOfCareRepository.List(patientId, startDate, endDate).OrderByDescending((x) => x.DischargeTimestamp).ToList();
        }
    }
}
