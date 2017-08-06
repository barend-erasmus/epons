using System;

namespace Epons.Domain.EntityViews.EpisodeOfCare
{
    public class Doctor
    {
        public string Fullname { get; set; }
        public ValueObjects.ContactDetails ContactDetails { get; set; }
        public string HPCSANumber { get; set; }
        public string PracticeNumber { get; set; }
    }
}
