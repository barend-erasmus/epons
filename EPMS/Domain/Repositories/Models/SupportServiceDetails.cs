using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    public class SupportServiceDetails
    {
        public Guid Id { get; set; } // Key
        public SupportService SupportService { get; set; }
        public string Text { get; set; }
    }
}
