using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class Facility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MonthlyRate { get; set; }
        public AdmissionType AdmissionType { get; set; }
        public bool IsFunder { get; set; }
        public virtual List<MeasurementToolPermission> MeasurementToolPermissions { get; set; }
    }
}
