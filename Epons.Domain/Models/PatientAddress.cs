using Epons.Domain.ValueObjects;

namespace Epons.Domain.Models
{
    public class PatientAddress
    {
        public Country Country { get; set; }
        public Province Province { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public ResidentialEnvironment ResidentialEnvironment { get; set; }
        public string PostalCode { get; set; }
    }
}
