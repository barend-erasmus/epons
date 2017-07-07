namespace Epons.Domain.Models
{
    public class UserPermission
    {
        public ValueObjects.Facility Facility { get; set; }
        public ValueObjects.Permission Permission { get; set; }
    }
}
