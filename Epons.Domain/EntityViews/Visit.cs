using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Epons.Domain.EntityViews
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Models.VisitUser User { get; set; }
        public int Duration { get; set; }
        public IList<ValueObjects.MeasurementTool> MeasurementTools { get; set; }
        public string DailyNotes { get; set; }
        public string ProgressNotes { get; set; }
        public ValueObjects.VitalSigns VitalSigns { get; set; }

        public bool HasNotes
        {
            get
            {
                string notes1 = DailyNotes == null? null : Regex.Replace(DailyNotes, "<.*?>", String.Empty);
                string notes2 = ProgressNotes == null? null : Regex.Replace(ProgressNotes, "<.*?>", String.Empty);

                if (string.IsNullOrWhiteSpace(notes1) && string.IsNullOrWhiteSpace(notes2))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
