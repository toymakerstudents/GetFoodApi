using AutoMapper;
using GetFood.Entities.Dtos;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();

            CreateMap<Customer, CustomerRegisterDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Restaurant, RestaurantCreateDto>().ReverseMap();
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();

            CreateMap<Food, FoodCreateDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

        }
    }
}
