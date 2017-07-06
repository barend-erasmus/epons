namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User.MeasurementToolScores")]
    public partial class MeasurementToolScore
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid MeasurementToolId { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Score { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Timestamp { get; set; }

        public virtual Details4 Details4 { get; set; }

        public virtual MeasurementTools2 MeasurementTools2 { get; set; }
    }
}
