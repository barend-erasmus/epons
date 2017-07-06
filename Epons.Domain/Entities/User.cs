using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
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
        public Position Position { get; set; }
        public Title Title { get; set; }
        public UserContactDetails ContactDetails { get; set; }
        public UserProfessionalBody ProfessionalBody { get; set; }
        public IList<UserPermission> Permissions { get; set; }
    }
}
