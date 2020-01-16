using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithNetCore.Models.Dto
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string OperatorName { get; set; }
    }

}
