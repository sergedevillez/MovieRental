using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovielRental.Models.Interfaces;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService _service;

        public CustomerController()
        {
            _service = new CustomerService();
        }


    }
}
