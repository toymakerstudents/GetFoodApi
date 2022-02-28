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
    public class FoodController : ControllerBase
    {
        [HttpPost]
        public string AddFood()
        {
            return null;
        }
        [HttpDelete]
        public string DeleteFood()
        {
            return null;
        }
    }
}
