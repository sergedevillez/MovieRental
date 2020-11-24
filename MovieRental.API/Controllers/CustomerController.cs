using Microsoft.AspNetCore.Mvc;
using MovieRental.API.Infrastructure.Security;
using MovieRental.API.Models.Form;
using MovieRental.API.Models.Interface;
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
        private readonly ITokenService _tokenService;

        public CustomerController(CustomerService service, ITokenService tokenService)
        {
            _service = service; // new BrandService();
            _tokenService = tokenService; 
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

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (ModelState.IsValid)
            {
                Customer Bob = new Customer();
                Bob.email = form.Email;
                Bob.passwd = form.Passwd;
                Customer customer = _service.Login(Bob);

                if (customer is null)
                {
                    return NotFound();
                }

                customer.Token = _tokenService.GenerateToken(customer);

                return Ok(customer);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    lastName = form.LastName,
                    firstName = form.FirstName,
                    email = form.Email,
                    passwd = form.Passwd
                };
                _service.Insert(customer);
                return Ok();
            }

            return BadRequest();
        }
    }
}
