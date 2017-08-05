using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class Address
    {
        public Guid Id { get; set; } // Key
        public Country Country { get; set; }
        public City City { get; set; }
        public Province Province { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public ResidentialEnvironment ResidentialEnvironment { get; set; }
    }
}
