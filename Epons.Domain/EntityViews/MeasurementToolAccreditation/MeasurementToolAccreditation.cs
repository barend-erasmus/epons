using System;

namespace Epons.Domain.EntityViews.MeasurementToolAccreditation
{
    public class MeasurementToolAccreditation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public double Score { get; set; }
        public DateTime DatePassed { get; set; }
        public int CountdownInDays { get; set; }
    }
}
