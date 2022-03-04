using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    public interface IFoodRepository
    {

        public Food CreateFood(Food food);
        public Food Find(int id);
        public List<Food> GetFoodsByRestaurantId(int restaurantId);

    }
}
