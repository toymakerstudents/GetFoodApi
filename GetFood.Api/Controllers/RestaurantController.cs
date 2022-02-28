using GetFood.Business.Abstract;
using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetFood.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService service;
        public RestaurantController(IRestaurantService service)
        {
            this.service = service;
        }



        // 123

        /*
        It is temporary, it will take id from token       
        */

        [HttpPost]
        public IResponse<RestaurantDto> CreateRestaurant(int id, RestaurantCreateDto restaurant)
        {
            var response = service.CreateRestaurant(id, restaurant);
            return response;

        }

    }
}
