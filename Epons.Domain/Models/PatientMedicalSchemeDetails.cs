using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Models
{
    public class PatientMedicalSchemeDetails
    {
        public MedicalScheme MedicalScheme { get; set; }
        public string MembershipNumber { get; set; }
    }
}
