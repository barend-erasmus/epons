namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValueObjects.ICD10CodeToIGMap")]
    public partial class ICD10CodeToIGMap
    {
        [Key]
        [Column(Order = 0)]
        public Guid ICD10CodeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ImpairmentGroupId { get; set; }
    }
}
