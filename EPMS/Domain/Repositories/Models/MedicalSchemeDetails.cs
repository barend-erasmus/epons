using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class MedicalSchemeDetails
    {
        public Guid Id { get; set; } // Key
        public MedicalScheme MedicalScheme { get; set; }
        public string MembershipNumber { get; set; }
    }
}
