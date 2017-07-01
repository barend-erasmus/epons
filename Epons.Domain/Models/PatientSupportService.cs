using Epons.Domain.ValueObjects;

namespace Epons.Domain.Models
{
    public class PatientSupportService
    {
        public SupportService SupportService { get; set; }
        public string Text { get; set; }
    }
}
