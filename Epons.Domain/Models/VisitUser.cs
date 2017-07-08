﻿using System;
using System.Collections.Generic;

namespace Epons.Domain.Models
{
    public class VisitUser
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public IList<UserPermission> Permissions { get; set; }
    }
}