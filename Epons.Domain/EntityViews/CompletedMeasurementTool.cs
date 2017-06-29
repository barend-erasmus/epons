using System;
using System.Collections.Generic;

namespace Epons.Domain.EntityViews
{
    public class CompletedMeasurementTool
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, int> ScoreItems { get; set; }
    }
}
