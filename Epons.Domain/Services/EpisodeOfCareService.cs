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

        public IList<EntityViews.EpisodeOfCare> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _episodeOfCareRepository.List(patientId, startDate, endDate).OrderByDescending((x) => x.DischargeTimestamp).ToList();
        }

        public IList<ValueObjects.Diagnoses> ListDiagnoses(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _episodeOfCareRepository.ListDiagnoses(patientId, startDate, endDate);
        }

        public IList<EntityViews.Doctor> ListReferringDoctors(Guid patientId, Guid? facilityId)
        {
            if (facilityId.HasValue)
            {
                return _episodeOfCareRepository.ListReferringDoctors(patientId).Where((x) => x.Facility.Id == facilityId).ToList();
            }
            else
            {
                return _episodeOfCareRepository.ListReferringDoctors(patientId);
            }
        }

        public IList<EntityViews.Doctor> ListTreatingDoctors(Guid patientId, Guid? facilityId)
        {
            if (facilityId.HasValue)
            {
                return _episodeOfCareRepository.ListTreatingDoctors(patientId).Where((x) => x.Facility.Id == facilityId).ToList();
            }
            else
            {
                return _episodeOfCareRepository.ListTreatingDoctors(patientId);
            }
        }
    }
}
