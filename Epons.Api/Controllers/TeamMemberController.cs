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
    public class TeamMemberController : BaseController
    {
        private readonly TeamMemberService _teamMemberService;

        public TeamMemberController(TeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        public IList<Domain.EntityViews.TeamMember> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            HasToBeAuthenticated();

            return _teamMemberService.List(patientId, startDate, endDate);
        }
    }
}
