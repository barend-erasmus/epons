using Epons.Api.Attributes;
using Epons.Domain.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class TrainingVideosController : BaseController
    {
        private readonly TrainingVideoService _trainingVideoService;

        public TrainingVideosController(TrainingVideoService trainingVideoService)
        {
            _trainingVideoService = trainingVideoService;
        }

        [HttpGet]
        public IDictionary<string, string> List(string name)
        {
            HasToBeAuthenticated();

            return _trainingVideoService.List(name);
        }

        [HttpGet]
        public IList<string> List()
        {
            HasToBeAuthenticated();

            return _trainingVideoService.List();
        }
    }
}
