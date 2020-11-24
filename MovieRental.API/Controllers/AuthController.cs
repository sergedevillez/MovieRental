using Microsoft.AspNetCore.Mvc;
using MovieRental.DAL.Models;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly CustomerService _service;

        public AuthController(CustomerService service)
        {
            _service = service; // new BrandService();
        }


        [Route("/Login")]
        [HttpPost]

        public IActionResult GetCheck(Customer customer)
        {
            return Ok(_service.Login(customer));
        }

        [Route("/Register")]
        [HttpPost]
        public IActionResult Register(Customer entity)
        {
            return Ok(_service.Insert(entity));
        }
    }
}
