namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.SupportServices")]
    public partial class SupportService
    {
        [Key]
        [Column(Order = 0)]
        public Guid PatientId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SupportServiceId { get; set; }

        [StringLength(256)]
        public string Text { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual SupportServices1 SupportServices1 { get; set; }
    }
}
