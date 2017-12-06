using System;

namespace Epons.Domain.Entities.User
{
    public class MeasurementToolAccreditation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public DateTime DatePassed { get; set; }
        public int CountdownInDays { get; set; }
    }
}
