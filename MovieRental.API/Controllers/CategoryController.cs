using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovielRental.Infrastructures.Security;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [AuthRequired]
    public class CategoryController : ControllerBase
    {
        private CategoryService _service;



        public CategoryController()
        {
            _service = new CategoryService();
        }




        [AuthRequired]
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.GetAll());
        }

    }
}

