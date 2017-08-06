using System;

namespace Epons.Domain.Entities.Patient
{
    public class TeamMember
    {
        public Facility Facility { get; set; }
        public User User { get; set; }
        public DateTime AllocationTimestamp { get; set; }
        public DateTime? DeallocationTimestamp { get; set; }
    }
}
