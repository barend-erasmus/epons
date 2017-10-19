using Epons.Domain.Validators;

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

            return validIdentificationNumber;
        }
    }
}
