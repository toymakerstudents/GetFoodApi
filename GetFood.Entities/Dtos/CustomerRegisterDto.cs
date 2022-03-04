using GetFood.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Entities.Dtos
{
    public class CustomerRegisterDto : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProvinceId { get; set; }
    }
}
