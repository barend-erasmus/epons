using System;
using System.Collections.Generic;

namespace Epons.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public string Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ValueObjects.Title Title { get; set; }
        public ValueObjects.Gender Gender { get; set; }
        public ValueObjects.Race Race { get; set; }
        public Models.PatientAddress Address { get; set; }
        public Models.PatientContactDetails ContactDetails { get; set; }
        public ValueObjects.ImpairmentGroup ImpairmentGroup { get; set; }
        public Models.PatientMedicalSchemeDetails MedicalSchemeDetails { get; set; }
        public IList<Models.PatientSupportService> SupportServices { get; set; }
        public IList<Models.ValidationMessage> ValidationMessages { get; set; } = new List<Models.ValidationMessage>();
    }
}
