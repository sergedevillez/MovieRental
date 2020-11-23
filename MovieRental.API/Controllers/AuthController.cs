using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.WSIdentity;
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
        private readonly AuthService _service;
        private readonly TokenService _tokenService;

        public AuthController(AuthService service, TokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            _service.Register(customer);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Check([FromBody] Customer customer)
        {
            customer = _service.Login(customer);
            if (customer is null)
            {
                return Unauthorized();
            }
            customer.Token = _tokenService.GeneratorToken(customer);
            return Ok(_service.Login(customer));
        }
    }
}
