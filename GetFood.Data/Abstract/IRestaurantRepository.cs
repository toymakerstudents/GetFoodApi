using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    public interface IRestaurantRepository:IRepository<Restaurant>
    {
        public Restaurant CreateRestaurant(int id, Restaurant restaurant);
        public Restaurant Find(int id);
    }
}
