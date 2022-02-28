using GetFood.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Models
{
    public class Province:EntityBase
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        
    }
}
