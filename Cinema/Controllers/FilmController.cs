using Cinema.DAL;
using Cinema.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController: ControllerBase
    {
        private readonly IFilmRepository repository;

        public FilmController(IFilmRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IReadOnlyCollection<Film> Get()
        {
            return repository.List();
        }
        [HttpGet("popular")]
        public IReadOnlyCollection<Film> GetPopularFilms()
        {
            return repository.ListPopularFilms();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Model.Film> Get(int id)
        {
            var value = repository.FindById(id);
            if (value == null)
                return NotFound();
            else
                return Ok(value);
        }
        [HttpGet("title/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Model.Film> GetByName(string name)
        {
            var value = repository.FindByName(name);
            if (value == null)
                return NotFound();
            else
                return Ok(value);
        }

        [HttpPost]
        public Film Create([FromBody] Dto.CreateFilm value)
        {
            var created = repository.Insert(value);
            if (created == null)
            {
                return null;
            }
            else return created;

        }

        [HttpPut("{id}")]
        public Film Edit(int id, [FromBody] Dto.CreateFilm value)
        {
            var edited = repository.Edit(id,value);
            if(edited == null)
            {
                return null;
            }
            else
            {
                return edited;
            }

        }

        [HttpDelete("delete/{id}")]
        public Film Delete(int id)
        {
            
            var value = repository.Delete(id);
            if (value == null)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
    }
}
