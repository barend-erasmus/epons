namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValueObjects.ImpairmentGroups")]
    public partial class ImpairmentGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImpairmentGroup()
        {
            Details2 = new HashSet<Details2>();
            PatientImpairmentGroups = new HashSet<PatientImpairmentGroup>();
        }

        public Guid ImpairmentGroupId { get; set; }

        [StringLength(16)]
        public string Code { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int SortOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details2> Details2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientImpairmentGroup> PatientImpairmentGroups { get; set; }
    }
}
