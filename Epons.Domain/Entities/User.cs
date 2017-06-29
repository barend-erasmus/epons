using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PracticeNumber { get; set; }
        public string Position { get; set; }
        public Title Title { get; set; }
        public UserContactDetails ContactDetails { get; set; }
        public UserProfessionalBody ProfessionalBody { get; set; }
        public IList<UserPermission> Permissions { get; set; }
    }
}
