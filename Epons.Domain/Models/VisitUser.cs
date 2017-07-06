using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Models
{
    public class VisitUser
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public IList<UserPermission> Permissions { get; set; }
    }
}
