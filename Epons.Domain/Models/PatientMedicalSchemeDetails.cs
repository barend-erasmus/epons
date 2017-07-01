using Epons.Domain.ValueObjects;

namespace Epons.Domain.Models
{
    public class PatientMedicalSchemeDetails
    {
        public MedicalScheme MedicalScheme { get; set; }
        public string MembershipNumber { get; set; }
    }
}
