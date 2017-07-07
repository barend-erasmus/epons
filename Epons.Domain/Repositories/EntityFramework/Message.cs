namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin.Messages")]
    public partial class Message
    {
        [Key]
        [Column(Order = 0)]
        public Guid MessageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Title { get; set; }

        [Key]
        [Column("Message", Order = 2)]
        public string Message1 { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FromTimestamp { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime ToTimestamp { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreatedTimestamp { get; set; }
    }
}
