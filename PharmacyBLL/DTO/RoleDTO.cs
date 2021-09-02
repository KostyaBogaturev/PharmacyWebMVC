using PharmacyDAL.Entities;
using System;

namespace PharmacyBLL.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEquatable<User> Users { get; set; }
    }
}
