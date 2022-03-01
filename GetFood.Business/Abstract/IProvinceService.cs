using GetFood.Entities.Dtos;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Abstract
{
    public interface IProvinceService
    {
        ProvinceDto GetById(int provinceId);
        ICollection<ProvinceDto> GetAll();
        Province Add(ProvinceDto provinceDto);
        bool Update(Province province);
        bool Delete(Province province);
    }
}
