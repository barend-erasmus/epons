using System;

namespace Epons.Domain.Entities.Patient
{
    public class MeasurementToolDetails
    {
        public ValueObjects.MeasurementTool MeasurementTool { get; set; }
        public ValueObjects.Frequency Frequency { get; set; }
        public DateTime AssignedTimestamp { get; set; }
        public DateTime? DeassignedTimestamp { get; set; }
    }
}
