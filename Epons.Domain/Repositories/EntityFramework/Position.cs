namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValueObjects.Positions")]
    public partial class Position
    {
        public Guid PositionId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}
