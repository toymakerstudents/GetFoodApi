using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class FoodDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
