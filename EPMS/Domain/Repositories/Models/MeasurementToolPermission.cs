using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class MeasurementToolPermission
    {
        public Guid Id { get; set; } // Key
        public MeasurementTool MeasurementTool { get; set; }
    }
}
