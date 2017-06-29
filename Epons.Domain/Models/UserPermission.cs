using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Models
{
    public class UserPermission
    {
        public Facility Facility { get; set; }
        public Permission Permission { get; set; }
    }
}
