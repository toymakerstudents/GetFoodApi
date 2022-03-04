using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    public interface IOrderRepository
    {


        public Order OrderFood(Order order);
        public List<Order> GetOrdersOfCustomer(int customerId);

    }
}
