using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.EntityViews
{
    public class Patient
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Title Title { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public PatientMedicalSchemeDetails MedicalSchemeDetails { get; set; }
        public string[] Facilities { get; set; }
    }
}
