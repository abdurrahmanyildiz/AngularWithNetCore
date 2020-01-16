using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithNetCore.Models
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }

        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }

    public enum Role
    {
        Admin,
        Customer,
        Officer,
        Delivery
    }
}
