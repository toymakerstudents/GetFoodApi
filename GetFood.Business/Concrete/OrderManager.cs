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
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;
        private readonly IFoodService foodService;
        private readonly IUserService userService;
        public OrderManager(IOrderRepository repository, IMapper mapper, IFoodService foodService, 
            IUserService userService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.foodService = foodService;
            this.userService = userService;
        }




        public IResponse<OrderDto> OrderFood(int userId, int foodId)
        {
            var targetFood = foodService.Find(foodId);
            var targetCustomer = userService.GetCustomerAccountOfUser(userId);
            var order = new Order
            {
                Status = "waiting",
                Customer = targetCustomer,
                Restaurant = targetFood.Restaurant,
                Food = targetFood
            };

            var responseOrder = repository.OrderFood(order);
            var orderDto = mapper.Map<OrderDto>(responseOrder);

            var response = new Response<OrderDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = orderDto
            };

            return response;

        }


        public List<Order> GetOrderHistory(int userId)
        {
            var targetCustomer = userService.GetCustomerAccountOfUser(userId);
            var customerId = targetCustomer.CustomerId;

            var orderList = repository.GetOrdersOfCustomer(customerId);
            return orderList;

        }




    }
}
