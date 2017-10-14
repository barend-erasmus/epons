using Epons.Domain.Validators;
using StatsdClient;

namespace Epons.Domain.Services
{
    public class ValidatorService
    {
        private readonly RSAIdentificationNumberValidator _identificationNumberValidator;

        public ValidatorService(RSAIdentificationNumberValidator identificationNumberValidator)
        {
            _identificationNumberValidator = identificationNumberValidator;
        }

        public bool IdentificationNumber(string identificationNumber)
        {
            var validIdentificationNumber = _identificationNumberValidator.IsValid(identificationNumber);

            if (validIdentificationNumber)
            {
                Metrics.Counter("ValidatorService.IdentificationNumber.Valid");
            }
            else
            {
                Metrics.Counter("ValidatorService.IdentificationNumber.Invalid");
            }

            Metrics.Counter("ValidatorService.IdentificationNumber");

            return validIdentificationNumber;
        }
    }
}
