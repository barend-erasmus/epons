using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Models
{
    public class PatientNextOfKin
    {
        public string Fullname { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Relationship { get; set; }
    }
}
