using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.EntityViews
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public User User { get; set; }
        public int Duration { get; set; }
        public bool HasNotes { get; set; }
        public IList<MeasurementTool> MeasurementTools { get; set; }
    }
}
