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
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            return Ok(_service.Insert(customer));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            _service.Update(customer);
            return Ok("Update done.");
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return Ok("Delete done.");
            }
            else
            {
                return BadRequest("Delete NOT done.");
            }
        }
    }
}
