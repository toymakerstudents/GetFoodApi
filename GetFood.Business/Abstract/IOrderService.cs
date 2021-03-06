using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Abstract
{
    public interface IOrderService
    {


        public IResponse<OrderDto> OrderFood(int userId, int foodId);
        public List<Order> GetOrderHistory(int userId);

    }
}
