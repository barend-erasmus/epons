using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class ReferringDoctor
    {
        public Guid Id { get; set; } // Key
        public string FullName { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string PracticeNumber { get; set; }
        public string HPCSANumber { get; set; }
    }
}
