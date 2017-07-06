namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.MeasurementTools")]
    public partial class MeasurementTools1
    {
        [Key]
        [Column(Order = 0)]
        public Guid PatientId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid MeasurementToolId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid FrequencyId { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime AssignedTimestamp { get; set; }

        public DateTime? DeassignedTimestamp { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual Frequency Frequency { get; set; }

        public virtual MeasurementTools2 MeasurementTools2 { get; set; }
    }
}
