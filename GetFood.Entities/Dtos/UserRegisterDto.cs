using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public CustomerRegisterDto Customer { get; set; }
    }
}
