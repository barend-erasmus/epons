using System;

namespace Epons.Domain.EntityViews
{
    public class TeamMember
    {
        public ValueObjects.Facility Facility { get; set; }
        public Models.TeamMemberUser User { get; set; }
        public DateTime AllocationTimestamp { get; set; }
        public DateTime? DeallocationTimestamp { get; set; }
    }
}
