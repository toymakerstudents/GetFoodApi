using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class UserToken
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
    }
}
