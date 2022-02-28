using GetFood.Entities.Dtos;
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
    public class OrderRepository
    {
        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns>List of order dto</returns>
        public async Task<List<OrderDto>> GetOrder()
        {
            return null;
        }

        /// <summary>
        /// Returns an order by given id
        /// </summary>
        /// <returns></returns>
        public async Task<OrderDto> GetOrderById(int orderId)
        {
            return null;
        }

        /// <summary>
        /// Return order which belongs to the restaurant (Given Id)
        /// </summary>
        /// <param name="restaurantId">Restaurant Id</param>
        /// <returns>List of order dto</returns>
        public async Task<List<OrderDto>> GetOrdersByRestaurantId(int restaurantId)
        {
            return null;
        }
    }
}
