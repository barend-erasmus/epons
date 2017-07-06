using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.ValueObjects
{
    public class User
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public Permission Permission { get; set; }
    }
}
