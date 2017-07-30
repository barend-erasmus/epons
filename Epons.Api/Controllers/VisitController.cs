using Epons.Api.Attributes;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class VisitController : BaseController
    {
        private readonly VisitService _visitService;

        public VisitController(VisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public IList<Domain.EntityViews.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            HasToBeAuthenticated();

            return _visitService.ListCompletedMeasurementTools(patientId, startDate, endDate);
        }

        [HttpGet]
        public IList<Domain.EntityViews.Visit> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            HasToBeAuthenticated();

            return _visitService.List(patientId, startDate, endDate);
        }
    }
}
