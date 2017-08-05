using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string IdentificationNumber { get; set; }
        public ProfessionalBodyDetails ProfessionalBodyDetails { get; set; }
        public Position Position { get; set; }
        public List<FacilityPermission> FacilityPermissions { get; set; }
        public List<MeasurementToolScore> MeasurementToolScores { get; set; }
        public Credentials Credentials { get;set; }
    }
}
