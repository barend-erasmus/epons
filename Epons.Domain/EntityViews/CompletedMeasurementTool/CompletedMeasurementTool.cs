using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.EntityViews.CompletedMeasurementTool
{
    public class CompletedMeasurementTool
    {
        public ValueObjects.MeasurementTool MeasurementTool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, int> ScoreItems { get; set; }

        public double CalculateBurdenOfCare()
        {
            if (MeasurementTool.Name == "Beta")
            {
                double sum = ScoreItems.OrderBy(y => y.Key).Select(y => (double)y.Value).Sum();

                double value = (126 - sum) * 3.38 / 60;

                return Math.Floor(value * 10) / 10;
            }
            else
            {
                return 0;
            }
        }
    }
}
