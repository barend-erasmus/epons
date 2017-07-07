namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValueObjects.ScoreValues")]
    public partial class ScoreValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScoreValue()
        {
            Details5 = new HashSet<Details5>();
        }

        public Guid ScoreValueId { get; set; }

        public Guid ScoreItemId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public int Value { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public virtual ScoreItem ScoreItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details5> Details5 { get; set; }
    }
}
