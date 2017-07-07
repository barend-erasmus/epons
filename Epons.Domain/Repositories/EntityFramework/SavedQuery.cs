namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin.SavedQueries")]
    public partial class SavedQuery
    {
        [Key]
        [Column(Order = 0)]
        public Guid QueryId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Query { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreatedTimestamp { get; set; }
    }
}
