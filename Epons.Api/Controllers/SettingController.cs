using Epons.Api.Attributes;
using Epons.Domain.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class SettingController : BaseController
    {
        private readonly PatientService _patientService;

        public SettingController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public string Find(string name)
        {
            HasToBeAuthenticated();

            return _patientService.Find(id);
        }
    }
}
