using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
