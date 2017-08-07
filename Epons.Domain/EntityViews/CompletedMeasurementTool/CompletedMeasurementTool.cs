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

        public double BurdenOfCare
        {
            get
            {
                return CalculateBurdenOfCare();
            }
        }

        public string Score
        {
            get
            {
                return CalculateScore();
            }
        }

        public string CalculateScore()
        {
            int total = 0;
            int sum = ScoreItems.OrderBy(y => y.Key).Select(y => y.Value).Sum();

            switch (MeasurementTool.Name)
            {
                default:
                    total = 126;
                    break;
            }

            return $"{sum} / {total}";
        }

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
