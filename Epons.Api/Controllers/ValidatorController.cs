using Epons.Api.Attributes;
using Epons.Domain.Validators;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class ValidatorController : BaseController
    {
        private readonly RSAIdentificationNumberValidator _identificationNumberValidator;

        public ValidatorController(RSAIdentificationNumberValidator identificationNumberValidator)
        {
            _identificationNumberValidator = identificationNumberValidator;
        }

        [HttpGet]
        public bool IdentificationNumber(string identificationNumber)
        {
            return _identificationNumberValidator.IsValid(identificationNumber);
        }

        [HttpGet]
        public bool IsMale(string identificationNumber)
        {
            return _identificationNumberValidator.IsMale(identificationNumber);
        }

        [HttpGet]
        public bool IsFemale(string identificationNumber)
        {
            return _identificationNumberValidator.IsFemale(identificationNumber);
        }

        [HttpGet]
        public DateTime DateOfBirth(string identificationNumber)
        {
            return _identificationNumberValidator.DateOfBirth(identificationNumber);
        }
    }
}
