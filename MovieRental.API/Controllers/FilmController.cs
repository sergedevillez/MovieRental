using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private FilmService _service;

        public FilmController()
        {
            _service = new FilmService();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }


        //[HttpGet]
        //[Route("Actor")]
        //public IActionResult GetByActor(string lastName)
        //{
        //    return Ok(_service.GetFilmByActorName(lastName));
        //}

        [HttpGet]
        [Route("ActorId")]
        public IActionResult GetByIdActor(int id)
        {
            return Ok(_service.GetFilmByActor(id));
        }

        //[HttpGet]
        //[Route("Category")]
        //public IActionResult GetByIdCategory(string catName)
        //{
        //    return Ok(_service.GetByCategory(catName));
        //}

        [HttpGet]
        [Route("CategoryId")]
        public IActionResult GetByCategory(int id)
        {
            return Ok(_service.GetFilmByCategory(id));
        }

        //[HttpGet]
        //[Route("language")]
        //public IActionResult GetByLanguage(string language)
        //{
        //    return Ok(_service.GetFilmByLanguage(language));
        //}

        [HttpGet]
        [Route("LanguageId")]
        public IActionResult GetByLanguage(int id)
        {
            return Ok(_service.GetFilmByLanguage(id));
        }

        [HttpGet]
        [Route("title")]
        public IActionResult GetByTitle(string title)
        {
            return Ok(_service.GetFilmByTitle(title));
        }

        [HttpGet]
        [Route("keyword")]
        public IActionResult GetByKeyWord(string keyword)
        {
            return Ok(_service.GetFilmByKeyword(keyword));
        }
    }
}

