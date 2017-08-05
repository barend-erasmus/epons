using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Domain.Repositories.Models
{
    public class Visit
    {
        public DateTime Timestamp { get; set; }
        public int Duration { get; set; }
        public string DailyNotes { get; set; }
        public string ProgressNotes { get; set; }
        public VitalSigns VitalSigns { get; set; }
        public
    }
}
