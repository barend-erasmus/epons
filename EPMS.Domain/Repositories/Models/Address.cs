using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class Address
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Province Province { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public ResidentialEnvironment ResidentialEnvironment { get; set; }
    }
}
