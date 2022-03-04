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
        private readonly IFoodService foodService;
        public RestaurantManager(IRestaurantRepository repository, IMapper mapper, IFoodService foodService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.foodService = foodService;
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

        public IResponse<List<RestaurantDto>> GetRestaurantsByLocation(int provinceId)
        {
            var list = repository.GetRestaurantsByLocation(provinceId);
            var mappedList = list.Select(x => mapper.Map<RestaurantDto>(x)).ToList();

            var response = new Response<List<RestaurantDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = mappedList
            };

            return response;

        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = repository.GetRestaurantById(restaurantId);
            return restaurant;
        }



        public List<Food> GetFoodsOfRestaurant(int restaurantId)
        {
            var foodList = foodService.GetFoodsByRestaurantId(restaurantId);
            return foodList;
        }



        public IResponse<FoodDto> AddFoodToRestaurant(int id, FoodCreateDto food)
        {
            try
            {
                var targetRestaurant = Find(id);
                if (targetRestaurant != null)
                {
                    var responseFood = foodService.CreateFood(food, targetRestaurant);
                    var foodDto = mapper.Map<FoodDto>(responseFood);

                    var response = new Response<FoodDto>
                    {
                        Message = "Success",
                        StatusCode = StatusCodes.Status200OK,
                        Data = foodDto
                    };

                    return response;
                }
                else
                {
                    return new Response<FoodDto>
                    {
                        Message = "Can not find restaurant",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<FoodDto>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
            
            


        }











    }
}
