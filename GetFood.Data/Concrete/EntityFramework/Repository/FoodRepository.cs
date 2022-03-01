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
    public class FoodRepository : EntityFrameworkRepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Food> GetAllByRestaurantId(int restaurantId)
        {
            return GetAll(x=>x.Restaurant.RestaurantId==restaurantId).ToList();
        }
    }
}
