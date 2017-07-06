using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.EntityViews
{
    public class TeamMember
    {
        public Facility Facility { get; set; }
        public User User { get; set; }
        public DateTime AllocationTimestamp { get; set; }
        public DateTime? DeallocationTimestamp { get; set; }
    }
}
