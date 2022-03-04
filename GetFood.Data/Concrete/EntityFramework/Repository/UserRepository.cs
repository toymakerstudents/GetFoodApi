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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;
        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            var userList = context.Set<User>().Include(x => x.Restaurant).ToList();
            return userList;

        }

        public User Find(int id)
        {
            var user = context.Set<User>().Include(x => x.Restaurant).Include(x => x.Customer).ThenInclude(x => x.Province).FirstOrDefault(x => x.UserId == id);
            if(user is not null)
            {
                return user;
            }
            else
            {
                throw new Exception("Can not find user");
            }
            
        }

        public User Update(User user)
        {
            context.Set<User>().Update(user);
            context.SaveChanges();
            return user;
        }





        public User Register(User userRegister)
        {
            try
            {
                //User user = context.Set<User>().SingleOrDefault(x => x.Email == userRegister.Email);
                User user = context.Set<User>().FirstOrDefault(x => x.Email == userRegister.Email);
                if (user is null)
                {

                    context.Set<Customer>().Add(userRegister.Customer);


                    context.Set<User>().Add(userRegister);
                    context.SaveChanges();
                    return userRegister;

                }
                else
                {
                    throw new Exception("Email already registered");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }             
        }


        public Restaurant GetRestaurantOfUser(int userId)
        {
            var user = context.Set<User>().Include(x => x.Restaurant).FirstOrDefault(x => x.UserId == userId);
            if(user is not null)
            {
                var restaurant = user.Restaurant;
                return restaurant;
            }
            else
            {
                throw new Exception("Can not find user");
            }
        }

        public Customer GetCustomerAccountOfUser(int userId)
        {
            var user = context.Set<User>().Include(x => x.Customer).FirstOrDefault(x => x.UserId == userId);
            if(user is not null)
            {
                var customer = user.Customer;
                return customer;
            }
            else
            {
                throw new Exception("Can not find user");
            }
            
        }



        public User Login(User userLogin)
        {
            var user = context.Set<User>().FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password );
            return user;
        }


        




    }
}
