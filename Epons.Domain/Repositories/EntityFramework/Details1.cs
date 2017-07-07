namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message.Details")]
    public partial class Details1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Details1()
        {
            MessageRecipients = new HashSet<MessageRecipient>();
        }

        [Key]
        public Guid MessageId { get; set; }

        public Guid PatientId { get; set; }

        public Guid SenderId { get; set; }

        public DateTime Timestamp { get; set; }

        public string Body { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual Details4 Details4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }
    }
}
