using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.ValueObjects
{
    public class VitalSigns
    {
        public double? Temperature { get; set; }
        public double? HeartRate { get; set; }
        public double? BloodPressureSystolic { get; set; }
        public double? BloodPressureDiastolic { get; set; }
        public double? RespiratoryRate { get; set; }
        public double? PulseOximetry { get; set; }
        public double? Glucose { get; set; }
    }
}
