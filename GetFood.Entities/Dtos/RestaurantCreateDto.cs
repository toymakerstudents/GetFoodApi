using GetFood.Entities.Base;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class RestaurantCreateDto : DtoBase
    {
        public string RestaurantName { get; set; }
        public Province Province { get; set; }

    }
}
