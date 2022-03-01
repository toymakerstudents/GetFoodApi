using AutoMapper;
using GetFood.Business.Abstract;
using GetFood.Data.Abstract;
using GetFood.Entities.Base;
using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using GetFood.Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Concrete
{
    public class RestaurantManager : IRestaurantService
    {
        private readonly IRestaurantRepository repository;
        private readonly IMapper mapper;
        public RestaurantManager(IRestaurantRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Restaurant CreateRestaurant(int userId, RestaurantCreateDto restaurant)
        {

            var mappedRestaurant = mapper.Map<Restaurant>(restaurant);
            var responseRestaurant = repository.CreateRestaurant(userId, mappedRestaurant);
            return responseRestaurant;
        }




        public Restaurant Find(int id)
        {
            var restaurant = repository.Find(id);
            return restaurant;

        }











    }
}
