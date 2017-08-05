using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class TeamMember
    {
        public Guid Id { get; set; } // Key
        public User User { get; set; }
        public Facility Facility { get; set; }
        public DateTime AllocationTimestamp { get; set; }
        public DateTime? DeallocationTimestamp { get; set; }
    }
}
