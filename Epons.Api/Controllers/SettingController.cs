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
        private readonly SettingService _settingService;

        public SettingController(SettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public string Find(string name)
        {
            HasToBeAuthenticated();

            return _settingService.Find(name);
        }

        [HttpGet]
        public bool Update(string name, string value)
        {
            HasToBeAuthenticated();

            _settingService.Update(name, value);

            return true;
        }
    }
}
