using GetFood.Entities.Dtos;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Abstract
{
    public interface IFoodService
    {


        public Food CreateFood(FoodCreateDto food, Restaurant restaurant);
        public Food Find(int id);
        public List<Food> GetFoodsByRestaurantId(int restaurantId);

    }
}
