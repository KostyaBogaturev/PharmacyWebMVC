using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyDAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public Guid RoleID { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
