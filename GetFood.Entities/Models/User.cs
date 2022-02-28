using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }       
        public string Password { get; set; }
        public Customer? Customer { get; set; }
        public Restaurant? Restaurant { get; set; }
        
    }
}
