using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public Food Food { get; set; }
    }
}
