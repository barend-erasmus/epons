namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey.Results")]
    public partial class Result
    {
        public Guid ResultId { get; set; }

        public Guid BatchId { get; set; }

        public Guid OptionId { get; set; }

        public Guid UserId { get; set; }

        public Guid PatientId { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual Option Option { get; set; }

        public virtual Details4 Details4 { get; set; }
    }
}
