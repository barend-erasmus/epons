using Epons.Domain.Repositories;
using StatsdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Services
{
    
    public class FacilityService
    {
        private readonly FacilityRepository _facilityRepository;

        public FacilityService(FacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public EntityViews.Facility.Facility Find(Guid id)
        {
            return _facilityRepository.FindById(id);
        }

        public int[] TimeSpent(Guid id)
        {
            using (Metrics.StartTimer($"FacilityService-TimeSpent"))
            {
                return new int[3] {
                    _facilityRepository.CalculateTimeSpent(id, 72),
                    _facilityRepository.CalculateTimeSpent(id, 48),
                    _facilityRepository.CalculateTimeSpent(id, 24)
                };
            }
        }
    }
}
