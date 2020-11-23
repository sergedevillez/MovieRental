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
    public class LanguageController : ControllerBase
    {

        private readonly LanguageService _service;

        public LanguageController(LanguageService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<LanguageController>
        [HttpPost]
        public IActionResult Post([FromBody] Language language)
        {
            _service.Insert(language);
            return Ok("Insert done.");
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Language language)
        {
            _service.Update(language);
            return Ok("Update done");
        }

        // DELETE api/<LanguageController>/5
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
