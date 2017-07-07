namespace Epons.Domain.Models
{
    public class PatientAddress
    {
        public ValueObjects.Country Country { get; set; }
        public ValueObjects.Province Province { get; set; }
        public ValueObjects.City City { get; set; }
        public string Street { get; set; }
        public ValueObjects.ResidentialEnvironment ResidentialEnvironment { get; set; }
        public string PostalCode { get; set; }
    }
}
