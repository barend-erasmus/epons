namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient.Doctor")]
    public partial class Doctor
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(64)]
        public string ContactNumber { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string PracticeName { get; set; }

        [StringLength(256)]
        public string HPCSANumber { get; set; }

        public bool? IsActive { get; set; }
    }
}
