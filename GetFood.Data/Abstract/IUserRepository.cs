using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    public interface IUserRepository
    {

        public List<User> GetAll();
        public User Find(int id);
        public User Register(User userRegister);
        public User Login(User userLogin);
        public User Update(User user);

    }
}
