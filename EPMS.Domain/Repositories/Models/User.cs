using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string IdentificationNumber { get; set; }
        public ProfessionalBodyDetails ProfessionalBodyDetails { get; set; }
        public Position Position { get; set; }
        public FacilityPermission[] FacilityPermissions { get; set; }
        public MeasurementToolScore[] MeasurementToolScores { get; set; }
        public Credentials Credentials { get;set; }
    }
}
