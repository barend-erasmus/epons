using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class ProfessionalBodyDetails
    {
        public Guid Id { get; set; } // Key
        public ProfessionalBody ProfessionalBody { get; set; }
        public string RegistrationNumber { get; set; }
        public string PracticeNumber { get; set; }
    }
}
