using GetFood.Data.Abstract;
using GetFood.Entities.Dtos;
using GetFood.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Repository
{
    /// <summary>
    /// Data Access Class For Order Entity (Entity Framework)
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext context;
        public OrderRepository(DbContext context)
        {
            this.context = context;
        }




        

        public Order OrderFood(Order order)
        {
            context.Set<Order>().Add(order);
            context.SaveChanges();
            return order;
        }


        public List<Order> GetOrdersOfCustomer(int customerId)
        {
            var orderList = context.Set<Order>().Include(x => x.Food).Include(x => x.Restaurant).Where(x => x.Customer.CustomerId == customerId).ToList();
            return orderList;
        }



    }
}
