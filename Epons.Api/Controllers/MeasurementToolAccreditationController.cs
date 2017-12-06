using Epons.Api.Attributes;
using Epons.Domain.EntityViews.MeasurementToolAccreditation;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class MeasurementToolAccreditationController : BaseController
    {
        private readonly MeasurementToolAccreditationService _measurementToolAccreditationService;

        public MeasurementToolAccreditationController(MeasurementToolAccreditationService measurementToolAccreditationService)
        {
            _measurementToolAccreditationService = measurementToolAccreditationService;
        }

        [HttpGet]
        public IList<MeasurementToolAccreditation> List()
        {
            HasToBeAuthenticated();

            return _measurementToolAccreditationService.List();
        }
    }
}