using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Abstract
{
    public interface IUserService
    {
        public IResponse<List<UserDto>> GetAll();
        public IResponse<UserDto> Find(int id);
        public IResponse<UserToken> Register(UserRegisterDto userRegister);
        public IResponse<UserToken> Login(UserLoginDto userLogin);

    }
}
