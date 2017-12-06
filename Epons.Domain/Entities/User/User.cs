using System;
using System.Collections.Generic;

namespace Epons.Domain.Entities.User
{
    public class User
    {
        public Guid Id { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public ValueObjects.Position Position { get; set; }
        public ValueObjects.Title Title { get; set; }
        public ValueObjects.ContactDetails ContactDetails { get; set; }
        public ProfessionalBodyDetails ProfessionalBodyDetails { get; set; }
        public IList<UserPermission> Permissions { get; set; }
        public IList<MeasurementToolAccreditation> MeasurementToolAccreditations { get; set; }
    }
}
