using GetFood.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Models
{
    public class Restaurant : EntityBase
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public Province Province { get; set; }
    }
}
