using Epons.Domain.Repositories;
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
    }
}
