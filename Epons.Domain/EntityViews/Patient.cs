using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Epons.Domain.EntityViews
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Title Title { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public PatientMedicalSchemeDetails MedicalSchemeDetails { get; set; }
        public IList<Facility> Facilities { get; set; }
    }
}
