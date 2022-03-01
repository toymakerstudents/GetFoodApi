using GetFood.Business.Abstract;
using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {

        private readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IResponse<List<UserDto>> GetAll()
        {
            var response = service.GetAll();
            return response;

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IResponse<UserDto> Find(int id)
        {
            var response = service.Find(id);
            return response;
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public IResponse<UserToken> Register(UserRegisterDto userRegister)
        {
            var response = service.Register(userRegister);
            return response;

        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<UserToken> Login(UserLoginDto userLogin)
        {
            var response = service.Login(userLogin);
            return response;
        }



        /*
        It is temporary, it will take id from token       
        */

        [HttpPost("BindRestaurant")]
        [AllowAnonymous]
        public IResponse<UserDto> BindRestaurantToUser(int id, RestaurantCreateDto restaurant)
        {
            var response = service.BindRestaurantToUser(id, restaurant);
            return response;

        }













        [HttpGet("TokenTest")]
        public string TokenTester()
        {
            return "have token";
        }



        [HttpGet("TokenRead")]
        public string TokenRead()
        {
            /*
            TOKEN READ TEST
            */
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                // or
                //identity.FindFirst("ClaimName").Value;
                var newtest = claims;
                var new2 = claims.ToList();
                var new3 = new2[1];
                var new35 = new3.Value;
                var new4 = "hello";

                return new35;

            }




            return "hello token";





        }






    }
}
