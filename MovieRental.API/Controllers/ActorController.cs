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
    public class ActorController : ControllerBase
    {
        private readonly ActorService _service;

        public ActorController(ActorService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody]Actor actor)
        {
            _service.Insert(actor);
            return Ok("Insert done.");
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Actor actor)
        {
            _service.Update(actor);
            return Ok("Update done");
        }

        // DELETE api/<ActorController>/5
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
