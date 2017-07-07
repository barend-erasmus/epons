using System;

namespace Epons.Domain.EntityViews
{
    public class Doctor
    {
        public string Fullname { get; set; }
        public Models.DoctorContactDetails ContactDetails { get; set; }
        public string HPCSANumber { get; set; }
        public string PracticeNumber { get; set; }
        public ValueObjects.Facility Facility { get; set; }
    }
}
