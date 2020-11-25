using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.DAL.Models;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.API.Controllers
{
    [Route("api/[controller]")]
    
    public class RentalController : ControllerBase
    {
        private RentalService _services;

        public RentalController() {
            _services = new RentalService();
        }

        [HttpPost]
        [Route("Location")]
        public IActionResult Pute(Rental rent, int[] fi)
        {

            return Ok(_services.Insertion(rent, fi));
        }
    }
}
