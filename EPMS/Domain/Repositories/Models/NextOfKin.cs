using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class NextOfKin
    {
        public Guid Id { get; set; } // Key
        public string FullName { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string Relationship { get; set; }
    }
}
