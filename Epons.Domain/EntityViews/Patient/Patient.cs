using System;
using System.Collections.Generic;

namespace Epons.Domain.EntityViews.Patient
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ValueObjects.Title Title { get; set; }
        public ValueObjects.Gender Gender { get; set; }
        public ValueObjects.Race Race { get; set; }
        public MedicalSchemeDetails MedicalSchemeDetails { get; set; }
        public IList<Facility> Facilities { get; set; }
        public IList<Models.ValidationMessage> ValidationMessages { get; set; } = new List<Models.ValidationMessage>();
    }
}
