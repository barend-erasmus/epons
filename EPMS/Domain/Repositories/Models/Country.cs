using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Province> Provinces { get; set; }
    }
}
