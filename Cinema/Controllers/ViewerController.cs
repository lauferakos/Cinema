using Cinema.DAL;
using Cinema.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewerController : ControllerBase
    {
        private readonly IViewerRepository repository;

        public ViewerController(IViewerRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IReadOnlyCollection<Viewer> Get()
        {
            return repository.List();
        }

        [HttpDelete("delete/{id}")]
        public Viewer Delete(int id)
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

        [HttpPost]
        public Viewer Create([FromBody] Dto.CreateViewer value)
        {
            var created = repository.Insert(value);
            if (created == null)
            {
                return null;
            }
            else return created;

        }
    }
}
