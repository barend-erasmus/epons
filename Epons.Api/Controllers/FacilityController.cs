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
        public int[] TimeSpent(Guid id)
        {
            HasToBeAuthenticated();

            return _facilityService.TimeSpent(id);
        }
    }
}
