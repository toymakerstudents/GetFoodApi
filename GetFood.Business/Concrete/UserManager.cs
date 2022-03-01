using AutoMapper;
using GetFood.Business.Abstract;
using GetFood.Business.Main;
using GetFood.Data.Abstract;
using GetFood.Entities.Base;
using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using GetFood.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        IConfiguration configuration;
        private readonly IRestaurantService restaurantService;

        public UserManager(IUserRepository repository, IMapper mapper, IConfiguration configuration,
           IRestaurantService restaurantService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.restaurantService = restaurantService;
            
        }

        public IResponse<List<UserDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                var mappedList = list.Select(x => mapper.Map<UserDto>(x)).ToList();

                var response = new Response<List<UserDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = mappedList
                };

                return response;

            }
            catch (Exception ex)
            {

                return new Response<List<UserDto>>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }

           
        }


        public IResponse<UserDto> Find(int id)
        {
            try
            {
                var user = repository.Find(id);
                var mappedUser = mapper.Map<UserDto>(user);

                var response = new Response<UserDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = mappedUser
                };

                return response;

            }
            catch (Exception ex)
            {
                return new Response<UserDto>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }


        public IResponse<UserDto> Update(int id, UserUpdateDto user)
        {
            var targetItem = repository.Find(id);
            var mappedItem = mapper.Map(user, targetItem);
            var updatedItem = repository.Update(mappedItem);

            var userDto = mapper.Map<UserDto>(updatedItem);

            var response = new Response<UserDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = userDto
            };

            return response;

        }


        public IResponse<UserDto> BindRestaurantToUser(int userId, RestaurantCreateDto restaurant)
        {
            var findUser = Find(userId);
            if (findUser.Data != null)
            {
                if (findUser.Data.Restaurant == null)
                {
                    Restaurant responseRestaurant = restaurantService.CreateRestaurant(userId, restaurant);


                    User targetUser = repository.Find(userId);
                    targetUser.Restaurant = responseRestaurant;
                    User responseUser = repository.Update(targetUser);

                    UserDto userDto = mapper.Map<UserDto>(responseUser);

                    var response = new Response<UserDto>
                    {
                        Message = "Success",
                        StatusCode = StatusCodes.Status200OK,
                        Data = userDto
                    };

                    return response;

                }
                else
                {
                    return new Response<UserDto>
                    {
                        Message = "Already have restaurant on this account",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Data = null
                    };

                }

            }
            else
            {
                return new Response<UserDto>
                {
                    Message = "Can not find user",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }








        public IResponse<UserToken> Register(UserRegisterDto userRegister)
        {
            try
            {
                var mappedUserRegister = mapper.Map<User>(userRegister);
                var responseUser = repository.Register(mappedUserRegister);

                var tokenString = new TokenManager(configuration).CreateAccessToken(responseUser);
                var userToken = new UserToken()
                {
                    User = mappedUserRegister,
                    AccessToken = tokenString
                };


                var response = new Response<UserToken>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };

                return response;

            }
            catch (Exception ex)
            {
                return new Response<UserToken>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };

            }
            
        }



        public IResponse<UserToken> Login(UserLoginDto userLogin)
        {
            var mappedUserLogin = mapper.Map<User>(userLogin);
            var user = repository.Login(mappedUserLogin);

            if(user != null)
            {
                var tokenString = new TokenManager(configuration).CreateAccessToken(user);

                var userToken = new UserToken
                {
                    User = user,
                    AccessToken = tokenString
                };

                var response = new Response<UserToken>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };

                return response;


            }
            else
            {
                return new Response<UserToken>
                {
                    Message = "UserCode or Password is wrong.",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }


        }


        
















    }
}
