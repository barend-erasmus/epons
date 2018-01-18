using Epons.Api.Attributes;
using Epons.Domain.Models;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class FacilityController : BaseController
    {
        private readonly FacilityService _facilityService;

        public FacilityController(FacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public Domain.EntityViews.Facility.Facility Find(Guid id)
        {
            HasToBeAuthenticated();

            return _facilityService.Find(id);
        }

        [HttpGet]
        public bool Lock(Guid id)
        {
            HasToBeAuthenticated();

            _facilityService.Lock(id);

            return true;
        }

        [HttpGet]
        public bool Unlock(Guid id)
        {
            HasToBeAuthenticated();

            _facilityService.Unlock(id);

            return true;
        }

        [HttpGet]
        public int[] TimeSpent(Guid id)
        {
            HasToBeAuthenticated();

            return _facilityService.TimeSpent(id);
        }
    }
}
