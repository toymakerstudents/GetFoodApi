using AutoMapper;
using GetFood.Business.Abstract;
using GetFood.Data.Abstract;
using GetFood.Entities.Dtos;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodRepository repository;
        private readonly IMapper mapper;
        public FoodManager(IFoodRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public Food CreateFood(FoodCreateDto food, Restaurant restaurant)
        {
            var mappedFood = mapper.Map<Food>(food);
            mappedFood.Restaurant = restaurant;
            var responseFood = repository.CreateFood(mappedFood);
            return responseFood;
        }

        public Food Find(int id)
        {
            var food = repository.Find(id);
            return food;
        }


        public List<Food> GetFoodsByRestaurantId(int restaurantId)
        {
            var foodList = repository.GetFoodsByRestaurantId(restaurantId);
            return foodList;
        }





    }
}
