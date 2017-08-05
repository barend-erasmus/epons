using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class NextOfKin
    {
        public string FullName { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string Relationship { get; set; }
    }
}
