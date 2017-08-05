using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class Facility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MonthlyRate { get; set; }
        public AdmissionType AdmissionType { get; set; }
        public bool IsFunder { get; set; }
        public MeasurementToolPermission[] MeasurementToolPermissions { get; set; }
    }
}
