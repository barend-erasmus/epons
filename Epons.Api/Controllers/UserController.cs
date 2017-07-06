using Epons.Api.Attributes;
using Epons.Domain.Entities;
using Epons.Domain.Services;
using System;
using System.Net;
using System.Net.Http;
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
            HasToBeAuthenticated();

            return _userService.Find(id);
        }

        [HttpGet]
        public string JWT(string username, string password)
        {
            return _userService.GetJWT(username, password);
        }

        private void HasToBeAuthenticated()
        {
            if (!Request.Properties.ContainsKey("jwt"))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }
    }
}
