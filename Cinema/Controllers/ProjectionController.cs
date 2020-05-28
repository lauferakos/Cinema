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
    public class ProjectionController : ControllerBase
    {
        private readonly IProjectionRepository repository;

        public ProjectionController(IProjectionRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IReadOnlyCollection<Projection> Get()
        {
            return repository.List();
        }
        [HttpPut("{id}")]
        public Projection Edit(int id, [FromBody] Dto.CreateProjection value)
        {
            var edited = repository.Edit(id, value);
            if (edited == null)
            {
                return null;
            }
            else
            {
                return edited;
            }

        }
        [HttpPost]
        public Projection Create([FromBody] Dto.CreateProjection value)
        {
            var created = repository.Insert(value);
            if (created == null)
            {
                return null;
            }
            else return created;

        }
        [HttpGet("get/{id}")]
        public Projection GetProjectionsById(int id)
        {
            var value = repository.FindById(id);
            if (value == null)
            {
                return null;
            }
            else return value;
        }
       
        [HttpGet("{id}")]
        public IReadOnlyCollection<Projection> GetProjectionsByFilm(int id)
        {
            return repository.GetProjectionsByFilm(id);
        }
        [HttpDelete("delete/{id}")]
        public Projection Delete(int id)
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
