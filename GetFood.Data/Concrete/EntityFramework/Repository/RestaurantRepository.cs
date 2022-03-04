using GetFood.Data.Abstract;
using GetFood.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Repository
{
    public class RestaurantRepository:IRestaurantRepository
    {
        DbContext context;
        public RestaurantRepository(DbContext context)
        {
            this.context = context;
        }


        public Restaurant CreateRestaurant(int id, Restaurant restaurant)
        {
            context.Set<Restaurant>().Add(restaurant);
            context.SaveChanges();
            return restaurant;

        }

        public List<Restaurant> GetRestaurantsByLocation(int provinceId)
        {
            var restaurantList = context.Set<Restaurant>().Include(x => x.Province)
                .Where(x => x.Province.ProvinceId == provinceId).ToList();
            return restaurantList;
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = context.Set<Restaurant>().FirstOrDefault(x => x.RestaurantId == restaurantId);
            return restaurant;
        }


        public Restaurant Find(int id)
        {
            var restaurant = context.Set<Restaurant>().FirstOrDefault(x => x.RestaurantId == id);
            if (restaurant is not null)
            {
                return restaurant;
            }
            else
            {
                throw new Exception("Can not find restaurant");
            }
        }

        



    }
}
