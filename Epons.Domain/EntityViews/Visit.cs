using Epons.Domain.Models;
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
        public VisitUser User { get; set; }
        public int Duration { get; set; }
        public IList<MeasurementTool> MeasurementTools { get; set; }
        public string DailyNotes { get; set; }
        public string ProgressNotes { get; set; }


        public bool HasNotes()
        {
            return true;
        }
    }
}
