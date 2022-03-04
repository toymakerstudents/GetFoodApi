using GetFood.Data.Abstract;
using GetFood.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Repository
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly DbContext context;
        public ProvinceRepository(DbContext context)
        {
            this.context = context;
        }


        public Province Find(int id)
        {
            var province = context.Set<Province>().FirstOrDefault(x => x.ProvinceId == id);
            if(province is not null)
            {
                return province;
            }
            else
            {
                throw new Exception("Can not find province");
            }
            

        }


    }
}
