using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Models
{
    public class PatientSupportService
    {
        public SupportService SupportService { get; set; }
        public string Text { get; set; }
    }
}
