using AutoMapper;
using GetFood.Business.Abstract;
using GetFood.Entities.Base;
using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService service;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public RestaurantController(IRestaurantService service, IUserService userService, IMapper mapper)
        {
            this.service = service;
            this.userService = userService;
            this.mapper = mapper;
        }



        
        [HttpPost("AddFood")]
        public IResponse<FoodDto> AddFoodToRestaurant(FoodCreateDto food)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = userService.ReadUserToken(identity);
                var responseRestaurant = userService.GetRestaurantOfUser(userId);
                int restaurantId = responseRestaurant.Data.RestaurantId;

                var response = service.AddFoodToRestaurant(restaurantId, food);
                return response;

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


        [HttpGet("GetRestaurantsByLocation/{provinceId}")]
        public IResponse<List<RestaurantDto>> GetRestaurantsByLocation(int provinceId)
        {
            var response = service.GetRestaurantsByLocation(provinceId);
            return response;
        }


        [HttpGet("GetRestaurantById/{restaurantId}")]
        public IResponse<RestaurantDto> GetRestaurantById(int restaurantId)
        {
            var restaurant = service.GetRestaurantById(restaurantId);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            var response = new Response<RestaurantDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = restaurantDto
            };

            return response;

        }




        [HttpGet("GetFoodsOfRestaurant/{restaurantId}")]
        public IResponse<List<FoodDto>> GetFoodsOfRestaurant(int restaurantId)
        {
            var foodList = service.GetFoodsOfRestaurant(restaurantId);
            var foodListDto = foodList.Select(x => mapper.Map<FoodDto>(x)).ToList();

            var response = new Response<List<FoodDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = foodListDto
            };

            return response;

        }
        
        










    }
}
