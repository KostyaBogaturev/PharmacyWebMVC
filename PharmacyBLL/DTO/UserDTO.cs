using System;

namespace PharmacyBLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public Guid? RoleId { get; set; }

        public RoleDTO Role { get; set; }
    }
}
