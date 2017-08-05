using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Domain.Repositories.Models
{
    class EpisodeOfCare
    {
        public Facility Facility { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime AdmissionTimestamp { get; set; }
        public DateTime? DismissionTimestamp { get; set; }
        public ICD10Code ICD10Code { get; set; }
        public ImpairmentGroup ImpairmentGroup { get;set; }
        public ReferringDoctor ReferringDoctor { get; set; }
        public TreatingDoctor TreatingDoctor { get; set; }
    }
}
