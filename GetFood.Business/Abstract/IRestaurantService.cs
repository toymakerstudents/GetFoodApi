using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Abstract
{
    public interface IRestaurantService
    {

        public Restaurant CreateRestaurant(int userId, RestaurantCreateDto restaurant);
        public Restaurant Find(int id);

    }
}
