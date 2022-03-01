using GetFood.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Context
{
    public class GetFoodContext : DbContext
    {
        public GetFoodContext(DbContextOptions<GetFoodContext> options) : base(options)
        {
        }

        

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Food> Foods { get; set; }





    }
}
