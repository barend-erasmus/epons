using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class Credentials
    {
        public Guid Id { get; set; } // Key
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
