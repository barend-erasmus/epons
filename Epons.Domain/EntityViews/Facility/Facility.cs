using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.EntityViews.Facility
{
    public class Facility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Avatar { get; set; }
        public bool Locked { get; set; }
    }
}
