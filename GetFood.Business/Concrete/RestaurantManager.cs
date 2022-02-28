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
        private readonly IUserService userService;
        public RestaurantManager(IRestaurantRepository repository, IMapper mapper, IUserService userService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userService = userService;
        }

        public IResponse<RestaurantDto> CreateRestaurant(int id, RestaurantCreateDto restaurant)
        {
            var findUser = userService.Find(id);
            if(findUser.Data != null)
            {
                if (findUser.Data.Restaurant == null)
                {

                    var mappedRestaurant = mapper.Map<Restaurant>(restaurant);
                    var responseRestaurant = repository.CreateRestaurant(id, mappedRestaurant);
                    var responseRestaurantDto = mapper.Map<RestaurantDto>(responseRestaurant);

                    var response = new Response<RestaurantDto>
                    {
                        Message = "Success",
                        StatusCode = StatusCodes.Status200OK,
                        Data = responseRestaurantDto
                    };

                    return response;

                }
                else
                {
                    return new Response<RestaurantDto>
                    {
                        Message = "Already have restaurant on this account",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Data = null
                    };

                }

            }
            else
            {
                return new Response<RestaurantDto>
                {
                    Message = "Can not find user",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }


            

        }

    }
}
