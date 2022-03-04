using GetFood.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class FoodCreateDto : DtoBase
    {
        public string FoodName { get; set; }
        public double Price { get; set; }
    }
}
