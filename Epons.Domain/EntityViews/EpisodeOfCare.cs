using System;

namespace Epons.Domain.EntityViews
{
    public class EpisodeOfCare
    {
        public ValueObjects.Facility Facility { get; set; }
        public string UniqueHospitalNumber { get; set; }
        public DateTime AdmissionTimestamp { get; set; }
        public DateTime? DischargeTimestamp { get; set; }
        public ValueObjects.ImpairmentGroup ImpairmentGroup { get; set; }
        public DateTime? OnsetTimestamp { get; set; }
        public ValueObjects.Diagnoses Diagnoses { get; set; }
        public ValueObjects.Doctor ReferringDoctor { get; set; }
        public ValueObjects.Doctor TreatingDoctor { get; set; }
    }
}
