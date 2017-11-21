using Epons.Api.Attributes;
using Epons.Domain.Services;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrainingVideosController : BaseController
    {
        private readonly TrainingVideoService _trainingVideoService;

        public TrainingVideosController(TrainingVideoService trainingVideoService)
        {
            _trainingVideoService = trainingVideoService;
        }

        [JWTAuthorize]
        [HttpGet]
        public IDictionary<string, string> List(string name)
        {
            HasToBeAuthenticated();

            return _trainingVideoService.List(name);
        }

        [JWTAuthorize]
        [HttpGet]
        public IList<string> ListAll()
        {
            HasToBeAuthenticated();

            return _trainingVideoService.List();
        }

        [HttpGet]
        public IHttpActionResult Download(string name, string fileName)
        {

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(File.Open(Path.Combine(ConfigurationManager.AppSettings["TrainingVideosPath"], name, fileName), FileMode.Open))
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = ResponseMessage(result);

            return response;
        }
    }
}
