namespace Epons.Domain.Entities.Patient
{
    public class UserPermission
    {
        public Facility Facility { get; set; }
        public ValueObjects.Permission Permission { get; set; }
    }
}
