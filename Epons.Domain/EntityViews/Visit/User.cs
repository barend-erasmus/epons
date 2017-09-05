using System;
using System.Collections.Generic;

namespace Epons.Domain.EntityViews.Visit
{
    public class User
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public IList<UserPermission> Permissions { get; set; }
        public ValueObjects.Position Position { get; set; }
    }
}
