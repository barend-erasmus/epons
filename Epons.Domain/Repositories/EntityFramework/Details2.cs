namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.Details")]
    public partial class Details2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Details2()
        {
            Details1 = new HashSet<Details1>();
            Details5 = new HashSet<Details5>();
            EpisodesOfCares = new HashSet<EpisodesOfCare>();
            EpisodesOfCares1 = new HashSet<EpisodesOfCare>();
            MeasurementTools1 = new HashSet<MeasurementTools1>();
            PatientImpairmentGroups = new HashSet<PatientImpairmentGroup>();
            Results = new HashSet<Result>();
            SupportServices = new HashSet<SupportService>();
            TeamMembers = new HashSet<TeamMember>();
        }

        [Key]
        public Guid PatientId { get; set; }

        [Required]
        [StringLength(256)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(256)]
        public string Lastname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public Guid? GenderId { get; set; }

        public Guid? RaceId { get; set; }

        [StringLength(256)]
        public string IdentificationNumber { get; set; }

        public Guid? MedicalSchemeId { get; set; }

        public Guid? TitleId { get; set; }

        [StringLength(64)]
        public string ContactNumber { get; set; }

        [StringLength(256)]
        public string Street { get; set; }

        [StringLength(256)]
        public string PostalCode { get; set; }

        [StringLength(256)]
        public string NameOfNextOfKin { get; set; }

        [StringLength(25)]
        public string ContactNumberOfNextOfKin { get; set; }

        [StringLength(256)]
        public string MedicalSchemeMembershipNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }

        public Guid? CityId { get; set; }

        [StringLength(256)]
        public string EmailAddressOfNextOfKin { get; set; }

        [StringLength(256)]
        public string RelationshipOfNextOfKin { get; set; }

        public Guid? ResidentialEnvironmentId { get; set; }

        public Guid? ImpairmentGroupId { get; set; }

        public Guid? DischargeTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details1> Details1 { get; set; }

        public virtual City City { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual ImpairmentGroup ImpairmentGroup { get; set; }

        public virtual MedicalScheme MedicalScheme { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details5> Details5 { get; set; }

        public virtual Race Race { get; set; }

        public virtual ResidentialEnvironment ResidentialEnvironment { get; set; }

        public virtual Title Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EpisodesOfCare> EpisodesOfCares { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EpisodesOfCare> EpisodesOfCares1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasurementTools1> MeasurementTools1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientImpairmentGroup> PatientImpairmentGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupportService> SupportServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
