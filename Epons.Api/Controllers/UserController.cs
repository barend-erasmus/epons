using Epons.Domain.Entities;
using Epons.Domain.Services;
using System;
using System.Web.Http;

namespace Epons.Api.Controllers
{
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
