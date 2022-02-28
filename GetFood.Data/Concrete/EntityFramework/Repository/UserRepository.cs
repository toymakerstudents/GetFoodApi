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
            var user = context.Set<User>().Include(x => x.Restaurant).FirstOrDefault(x => x.UserId == id);
            if(user is not null)
            {
                return user;
            }
            else
            {
                throw new Exception("Can not find user");
            }
            
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


        public User Login(User userLogin)
        {
            var user = context.Set<User>().FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password );
            return user;
        }




    }
}
