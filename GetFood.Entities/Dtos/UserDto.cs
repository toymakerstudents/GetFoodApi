using GetFood.Entities.Base;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class UserDto : DtoBase
    {
        public string Email { get; set; }
        public RestaurantDto Restaurant { get; set; }

    }
}
