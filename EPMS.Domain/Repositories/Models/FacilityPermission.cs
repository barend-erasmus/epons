using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class FacilityPermission
    {
        public Facility Facility { get; set; }
        public Permission Permission { get; set; }
    }
}
