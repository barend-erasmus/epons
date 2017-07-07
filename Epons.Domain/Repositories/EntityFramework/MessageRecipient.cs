namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message.MessageRecipient")]
    public partial class MessageRecipient
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid MessageId { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool HasBeenRead { get; set; }

        public virtual Details1 Details1 { get; set; }

        public virtual Details4 Details4 { get; set; }
    }
}
