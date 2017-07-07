using System;
using System.Collections.Generic;

namespace Epons.Domain.EntityViews
{
    public class CompletedMeasurementTool
    {
        public ValueObjects.MeasurementTool MeasurementTool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, int> ScoreItems { get; set; }
    }
}
