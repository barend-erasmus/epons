namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Facility.Details")]
    public partial class Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detail()
        {
            Details4 = new HashSet<Details4>();
            Permissions = new HashSet<Permission>();
            TeamMembers = new HashSet<TeamMember>();
            MeasurementTools2 = new HashSet<MeasurementTools2>();
        }

        [Key]
        public Guid FacilityId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int MonthlyRate { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }

        public bool IsFunder { get; set; }

        public Guid? AdmissionTypeId { get; set; }

        public virtual AdmissionType AdmissionType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details4> Details4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasurementTools2> MeasurementTools2 { get; set; }
    }
}
