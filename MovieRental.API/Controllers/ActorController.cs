using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.DAL.Models;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private ActorService _service;

        public ActorController()
        {
            _service = new ActorService();
        }


        [HttpGet]

        public IEnumerable<Actor> GetAll()
        {
            return _service.GetAll();
        }



        [HttpGet("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_service.Get(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet]
        //[Route("title")]
        //public IActionResult GetByFilm(string title)
        //{
        //    try
        //    {
        //        return Ok(_service.GetByFilm(title));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        //[HttpGet("{initial}")]
        //public IActionResult GetByInital(string initial)
        //{
        //    try
        //    {
        //        return Ok(_service.GetActorByInitial(initial[0], initial[1]));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //}

        [HttpGet]
        [Route("AllInitials")]
        public IActionResult getAllByInitial()
        {
            return Ok(_service.GetAllInitials());
        }


    }
}

