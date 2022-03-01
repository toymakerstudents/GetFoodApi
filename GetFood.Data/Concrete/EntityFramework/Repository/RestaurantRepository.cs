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
    public class RestaurantRepository: EntityFrameworkRepositoryBase<Restaurant>,IRestaurantRepository
    {
        DbContext context;
        public RestaurantRepository(DbContext context):base(context)
        {
            this.context = context;
        }


        public Restaurant CreateRestaurant(int id, Restaurant restaurant)
        {

            context.Set<Restaurant>().Add(restaurant);
            context.SaveChanges();
            return restaurant;

        }

 
    }
}
