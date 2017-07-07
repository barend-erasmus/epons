namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User.Permissions")]
    public partial class Permission
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid FacilityId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid PermissionId { get; set; }

        public virtual Detail Detail { get; set; }

        public virtual Details4 Details4 { get; set; }

        public virtual Permissions1 Permissions1 { get; set; }
    }
}
