using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
