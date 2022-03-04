using AutoMapper;
using GetFood.Business.Abstract;
using GetFood.Data.Abstract;
using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Concrete
{
    public class ProvinceManager : IProvinceService
    {
        private readonly IProvinceRepository repository;
        private readonly IMapper mapper;
        public ProvinceManager(IProvinceRepository repository)
        {
            this.repository = repository;

        }



        public Province Find(int id)
        {
            var responseProvince = repository.Find(id);
            if(responseProvince is not null)
            {
                return responseProvince;
            }
            else
            {
                throw new Exception("Can not find province");
            }
                      
        }




    }
}
