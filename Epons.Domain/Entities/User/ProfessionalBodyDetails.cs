using Epons.Domain.ValueObjects;

namespace Epons.Domain.Entities.User
{
    public class ProfessionalBodyDetails
    {
        public ProfessionalBody ProfessionalBody { get; set; }
        public string PracticeNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
