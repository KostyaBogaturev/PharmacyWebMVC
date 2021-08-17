using System;
using System.Collections.Generic;

namespace PharmacyBLL.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }
    }
}
