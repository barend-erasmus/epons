using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class MeasurementToolScore
    {
        public Guid Id { get; set; } // Key
        public MeasurementTool MeasurementTool { get; set; }
        public double Score { get; set; }
    }
}
