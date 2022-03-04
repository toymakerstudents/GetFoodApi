using GetFood.Data.Abstract;
using GetFood.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DbContext context;
        public FoodRepository(DbContext context)
        {
            this.context = context;
        }

        public Food CreateFood(Food food)
        {
            context.Set<Food>().Add(food);
            context.SaveChanges();
            return food;
        }

        public Food Find(int id)
        {
            var food = context.Set<Food>().Include(x => x.Restaurant).FirstOrDefault(x => x.FoodId == id);
            if(food is not null)
            {
                return food;
            }
            else
            {
                throw new Exception("Can not find food");
            }

        }


        public List<Food> GetFoodsByRestaurantId(int restaurantId)
        {
            var foodList = context.Set<Food>().Include(x => x.Restaurant).Where(x => x.Restaurant.RestaurantId == restaurantId).ToList();
            return foodList;
        }




    }
}
