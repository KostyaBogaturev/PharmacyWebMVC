﻿using System;

namespace PharmacyDAL.Entities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEquatable<User> Users { get; set; }
    }
}
