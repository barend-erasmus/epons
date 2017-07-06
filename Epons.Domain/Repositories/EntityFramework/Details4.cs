namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User.Details")]
    public partial class Details4
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Details4()
        {
            Details1 = new HashSet<Details1>();
            Results = new HashSet<Result>();
            Credentials = new HashSet<Credential>();
            Details5 = new HashSet<Details5>();
            MeasurementToolScores = new HashSet<MeasurementToolScore>();
            MessageRecipients = new HashSet<MessageRecipient>();
            Permissions = new HashSet<Permission>();
            TeamMembers = new HashSet<TeamMember>();
        }

        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string Firstname { get; set; }

        [StringLength(256)]
        public string Lastname { get; set; }

        public Guid? TitleId { get; set; }

        [StringLength(256)]
        public string IdentificationNumber { get; set; }

        [StringLength(64)]
        public string ContactNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisclaimerAgreeTimestamp { get; set; }

        [StringLength(256)]
        public string PracticeNumber { get; set; }

        public Guid? ProfessionalBodyId { get; set; }

        [StringLength(64)]
        public string RegistrationNumber { get; set; }

        public bool IsSuperAdmin { get; set; }

        public Guid? CurrentFacilityId { get; set; }

        public Guid? CurrentPositionId { get; set; }

        public virtual Detail Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details1> Details1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credential> Credentials { get; set; }

        public virtual ProfessionalBody ProfessionalBody { get; set; }

        public virtual Title Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details5> Details5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasurementToolScore> MeasurementToolScores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
