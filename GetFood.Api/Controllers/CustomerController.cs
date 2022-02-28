using GetFood.Entities.Dtos;
using GetFood.Entities.IBase;
using GetFood.Entities.Models;
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
    public class CustomerController : ControllerBase
    {


        [HttpGet]
        public Customer TempCustomerGet()
        {
            var tempItem = new Customer();
            tempItem.CustomerId = 5;
            tempItem.FirstName = "John";
            tempItem.LastName = "Doe";

            return tempItem;


        }











    }
}
