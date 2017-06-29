using Epons.Domain.Validators;
using System.Web.Http;

namespace Epons.Api.Controllers
{
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
