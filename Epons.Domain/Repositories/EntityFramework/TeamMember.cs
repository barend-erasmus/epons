namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.TeamMembers")]
    public partial class TeamMember
    {
        [Key]
        [Column(Order = 0)]
        public Guid PatientId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid FacilityId { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime AllocationTimestamp { get; set; }

        public DateTime? DeallocationTimestamp { get; set; }

        public virtual Detail Detail { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual Details4 Details4 { get; set; }
    }
}
