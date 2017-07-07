namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValueObjects.ScoreItems")]
    public partial class ScoreItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScoreItem()
        {
            ScoreItems1 = new HashSet<ScoreItem>();
            ScoreValues = new HashSet<ScoreValue>();
        }

        public Guid ScoreItemId { get; set; }

        public Guid? ParentScoreItemId { get; set; }

        public Guid MeasurementToolId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public int Value { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual MeasurementTools2 MeasurementTools2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreItem> ScoreItems1 { get; set; }

        public virtual ScoreItem ScoreItem1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreValue> ScoreValues { get; set; }
    }
}
