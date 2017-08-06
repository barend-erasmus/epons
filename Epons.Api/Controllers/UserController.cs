using Epons.Api.Attributes;
using Epons.Domain.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class UserController : BaseController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public Domain.Entities.User.User FindById(Guid id)
        {
            HasToBeAuthenticated();

            return _userService.Find(id);
        }

        [HttpGet]
        public string JWT(string username, string password)
        {
            return _userService.GetJWT(username, password);
        }
    }
}
