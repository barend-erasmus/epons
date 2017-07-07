namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User.Credentials")]
    public partial class Credential
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string Username { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvalidLoginAttempts { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Locked { get; set; }

        public DateTime? LastLoginTimestamp { get; set; }

        public virtual Details4 Details4 { get; set; }
    }
}
