using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class MeasurementToolDetails
    {
        public MeasurementTool MeasurementTool { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime AllocationTimestamp { get; set; }
        public DateTime? DeallocationTimestamp { get; set; }

    }
}
