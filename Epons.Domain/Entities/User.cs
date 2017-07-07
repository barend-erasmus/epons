using System;
using System.Collections.Generic;

namespace Epons.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PracticeNumber { get; set; }
        public ValueObjects.Position Position { get; set; }
        public ValueObjects.Title Title { get; set; }
        public Models.UserContactDetails ContactDetails { get; set; }
        public Models.UserProfessionalBody ProfessionalBody { get; set; }
        public IList<Models.UserPermission> Permissions { get; set; }
    }
}
