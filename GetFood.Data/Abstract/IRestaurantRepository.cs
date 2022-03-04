using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    public interface IRestaurantRepository
    {
        public Restaurant CreateRestaurant(int id, Restaurant restaurant);
        public Restaurant Find(int id);
        public List<Restaurant> GetRestaurantsByLocation(int provinceId);
        public Restaurant GetRestaurantById(int restaurantId);
    }
}
