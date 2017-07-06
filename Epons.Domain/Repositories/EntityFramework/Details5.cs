namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visit.Details")]
    public partial class Details5
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Details5()
        {
            ScoreValues = new HashSet<ScoreValue>();
        }

        [Key]
        public Guid VisitId { get; set; }

        public Guid PatientId { get; set; }

        public DateTime Timestamp { get; set; }

        [Column(TypeName = "text")]
        public string DailyNotes { get; set; }

        [Column(TypeName = "text")]
        public string ProgressNotes { get; set; }

        public Guid? UserId { get; set; }

        public double? Temperature { get; set; }

        public int? HeartRate { get; set; }

        public int? BloodPressureSystolic { get; set; }

        public int? BloodPressureDiastolic { get; set; }

        public int? RespiratoryRate { get; set; }

        public int? PulseOximetry { get; set; }

        public double? Glucose { get; set; }

        public bool IsPrivate { get; set; }

        public Guid? EpisodeOfCareId { get; set; }

        public int? DurationofVisitinMinutes { get; set; }

        public virtual Details2 Details2 { get; set; }

        public virtual EpisodesOfCare EpisodesOfCare { get; set; }

        public virtual Details4 Details4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreValue> ScoreValues { get; set; }
    }
}
