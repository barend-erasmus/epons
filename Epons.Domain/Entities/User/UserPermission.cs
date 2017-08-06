namespace Epons.Domain.Entities.User
{
    public class UserPermission
    {
        public Facility Facility { get; set; }
        public ValueObjects.Permission Permission { get; set; }
    }
}
