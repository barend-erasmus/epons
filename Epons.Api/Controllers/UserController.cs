using Epons.Api.Attributes;
using Epons.Domain.Entities;
using Epons.Domain.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public User FindById(Guid id)
        {
            return null;
        }
    }
}
