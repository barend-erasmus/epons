using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class FacilityPermission
    {
        public Guid Id { get; set; } // Key
        public Facility Facility { get; set; }
        public Permission Permission { get; set; }
    }
}
