using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;

namespace Epons.Domain.EntityViews
{
    public class Doctor
    {
        public string Fullname { get; set; }
        public DoctorContactDetails ContactDetails { get; set; }
        public string HPCSANumber { get; set; }
        public string PracticeNumber { get; set; }
        public Facility Facility { get; set; }
    }
}
