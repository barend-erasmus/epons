namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Audit.Patient")]
    public partial class Patient
    {
        [Key]
        [Column(Order = 0)]
        public Guid PatientId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime AuditTimestamp { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string AuditType { get; set; }
    }
}
