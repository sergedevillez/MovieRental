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
    public class RentailDetailController : ControllerBase
    {

        private readonly RentalDetailService _service;

        public RentailDetailController(RentalDetailService service)
        {
            _service = service; // new BrandService();
        }

        // GET: api/<RentailDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<RentailDetailController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/<RentailDetailController>
        [HttpPost]
        public IActionResult Post([FromBody] RentalDetail rentailDetail)
        {
            _service.Insert(rentailDetail);
            return Ok("Insert done.");
        }

        // PUT api/<RentailDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] RentalDetail rentailDetail)
        {
            _service.Update(rentailDetail);
            return Ok("Update done");
        }

        // DELETE api/<RentailDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int idCustomer, int idFilm)
        {
            if (_service.Delete(idCustomer, idFilm))
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
