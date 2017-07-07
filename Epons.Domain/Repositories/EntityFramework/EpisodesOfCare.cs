namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.EpisodesOfCare")]
    public partial class EpisodesOfCare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EpisodesOfCare()
        {
            Details5 = new HashSet<Details5>();
        }

        public Guid PatientId { get; set; }

        public Guid FacilityId { get; set; }

        public DateTime AllocationTimestamp { get; set; }

        public DateTime? DeallocationTimestamp { get; set; }

        public Guid? ReasonForAdmissionId { get; set; }

        public DateTime? ReasonForAdmissionTimestamp { get; set; }

        public Guid? AdmissionTypeId { get; set; }

        public Guid? DischargeTypeId { get; set; }

        [Key]
        public Guid EpisodeOfCareId { get; set; }

        [StringLength(255)]
        public string AllocationNumber { get; set; }

        public int? ReferringDoctorId { get; set; }

        public int? AttendingDoctorId { get; set; }

        public Guid? ImpairmentGroupId { get; set; }

        public Guid? CreatedByUserId { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual Details2 Details21 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details5> Details5 { get; set; }

        public virtual AdmissionType AdmissionType { get; set; }

        public virtual AdmissionType AdmissionType1 { get; set; }

        public virtual DischargeType DischargeType { get; set; }

        public virtual DischargeType DischargeType1 { get; set; }

        public virtual ICD10Codes ICD10Codes { get; set; }

        public virtual ICD10Codes ICD10Codes1 { get; set; }
    }
}
