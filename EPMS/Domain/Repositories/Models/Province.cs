using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class Province
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
