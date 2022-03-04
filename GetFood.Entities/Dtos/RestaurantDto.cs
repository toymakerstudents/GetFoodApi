using GetFood.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class RestaurantDto : DtoBase
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
