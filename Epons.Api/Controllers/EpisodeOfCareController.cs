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
    public class EpisodeOfCareController : BaseController
    {

        private readonly EpisodeOfCareService _episodeOfCareService;

        public EpisodeOfCareController(EpisodeOfCareService episodeOfCareService)
        {
            _episodeOfCareService = episodeOfCareService;
        }

        [HttpGet]
        public IList<Domain.EntityViews.EpisodeOfCare.EpisodeOfCare> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            HasToBeAuthenticated();

            return _episodeOfCareService.List(patientId, startDate, endDate);
        }
    }
}
