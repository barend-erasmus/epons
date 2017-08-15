using System;
using System.Collections.Generic;

namespace Epons.Domain.Entities.Patient
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentificationNumber { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? Age
        {
            get
            {
                return CalculateAge();
            }
        }

        public ValueObjects.Title Title { get; set; }
        public ValueObjects.Gender Gender { get; set; }
        public ValueObjects.Race Race { get; set; }
        public ValueObjects.Address Address { get; set; }
        public ValueObjects.ContactDetails ContactDetails { get; set; }
        public ValueObjects.ImpairmentGroup ImpairmentGroup { get; set; }
        public MedicalSchemeDetails MedicalSchemeDetails { get; set; }
        public IList<MeasurementToolDetails> MeasurementToolDetails { get; set; }
        public IList<SupportServiceDetails> SupportServiceDetails { get; set; }
        public IList<TeamMember> TeamMembers { get; set; }
        public IList<Models.ValidationMessage> ValidationMessages { get; set; } = new List<Models.ValidationMessage>();

        private int? CalculateAge()
        {
            if (!DateOfBirth.HasValue)
            {
                return null;
            }

            DateTime today = DateTime.Today;

            int a = (today.Year * 100 + today.Month) * 100 + today.Day;
            int b = (DateOfBirth.Value.Year * 100 + DateOfBirth.Value.Month) * 100 + DateOfBirth.Value.Day;

            return (a - b) / 10000;
        }
    }
}
