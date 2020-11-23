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
    public class FilmController : ControllerBase
    {

        private readonly FilmService _service;

        public FilmController(FilmService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<FilmController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<FilmController>
        [HttpPost]
        public IActionResult Post([FromBody] Film film)
        {
            _service.Insert(film);
            return Ok("Insert done.");
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Film film)
        {
            _service.Update(film);
            return Ok("Update done");
        }

        // DELETE api/<FilmController>/5
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
