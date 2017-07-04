﻿using Epons.Domain.Validators;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValidatorController : ApiController
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
    }
}
