using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfileImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Title Title { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string IdentificationNumber { get; set; }
        public string PassportNumber { get; set; }
        public Address Address { get; set; }
        public NextOfKin NextOfKin { get; set; }
        public MedicalSchemeDetails MedicalSchemeDetails { get;set; }
        public SupportServiceDetails[] SupportServiceDetails { get; set; }
        public EpisodeOfCare[] EpisodeOfCares { get; set; }
        public MeasurementToolDetails[] MeasurementToolDetails { get; set; }
        public TeamMember[] TeamMembers { get; set; }
    }
}
