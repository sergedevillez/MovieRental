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
    public class RentalController : ControllerBase
    {

        private readonly RentalService _service;

        public RentalController(RentalService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post([FromBody] Rental rental)
        {
            _service.Insert(rental);
            return Ok("Insert done.");
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Rental rental)
        {
            _service.Update(rental);
            return Ok("Update done");
        }

        // DELETE api/<RentalController>/5
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
