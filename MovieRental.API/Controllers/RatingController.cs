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
    public class RatingController : ControllerBase
    {

        private readonly RatingService _service;

        public RatingController(RatingService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<RatingController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<RatingController>
        [HttpPost]
        public IActionResult Post([FromBody] Rating rating)
        {
            _service.Insert(rating);
            return Ok("Insert done.");
        }

        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Rating rating)
        {
            _service.Update(rating);
            return Ok("Update done");
        }

        // DELETE api/<RatingController>/5
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
