using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class ContactDetails
    {
        public Guid Id { get; set; } // Key
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
