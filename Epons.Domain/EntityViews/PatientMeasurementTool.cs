using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.EntityViews
{
    public class PatientMeasurementTool
    {
        public ValueObjects.MeasurementTool MeasurementTool { get; set; }
        public ValueObjects.Frequency Frequency { get; set; }
        public DateTime AssignedTimestamp { get; set; }
        public DateTime? DeassignedTimestamp { get; set; }
    }
}
