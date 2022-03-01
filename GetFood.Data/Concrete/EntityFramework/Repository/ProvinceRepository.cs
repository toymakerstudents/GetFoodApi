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
    public class ProvinceRepository : EntityFrameworkRepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
