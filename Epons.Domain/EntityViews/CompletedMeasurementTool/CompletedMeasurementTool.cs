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
            int total = GetTotalOfMeasurementTool();
            int sum = ScoreItems.OrderBy(y => y.Key).Select(y => y.Value).Sum();

            return $"{sum} / {total}";
        }

        public double CalculateBurdenOfCare()
        {
            if (MeasurementTool.Name == "Beta")
            {
                double sum = ScoreItems.OrderBy(y => y.Key).Select(y => (double)y.Value).Sum();

                double value = (GetTotalOfMeasurementTool() - sum) * 3.38 / 60;

                return Math.Floor(value * 10) / 10;
            }
            else
            {
                return 0;
            }
        }


        /*
        SELECT 
        [measurementTool].[Name],
        COUNT(*) AS [NumberOfScoreItems]
        FROM [ValueObjects].[ScoreItems] AS scoreItem
        INNER JOIN [ValueObjects].[MeasurementTools] AS measurementTool
        ON [measurementTool].[MeasurementToolId] = [scoreItem].[MeasurementToolId]
        INNER JOIN [ValueObjects].[ScoreValues] AS scoreValue
        ON [scoreValue].[ScoreItemId] = [scoreItem].[ScoreItemId]
        AND [scoreItem].[ParentScoreItemId] IS NULL
        GROUP BY [measurementTool].[Name]
        ORDER BY [measurementTool].[Name]
        */

        private int GetTotalOfMeasurementTool()
        {
            switch (MeasurementTool.Name)
            {
                case "Alpha":
                    return 84;
                case "APOM":
                    return 144;
                case "Beta":
                   return 126;
                case "Delta":
                    return 35;
                case "Epsilon":
                    return 49;
                case "Eta":
                    return 56;
                case "FAM":
                    return 84;
                case "Gamma":
                    return 56;
                case "Omega":
                    return 56;
                case "Zeta":
                    return 84;
                default:
                    return 0;
            }
        }
    }
}
