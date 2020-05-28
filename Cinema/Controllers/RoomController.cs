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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository repository;

        public RoomController(IRoomRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IReadOnlyCollection<Room> Get()
        {
            return repository.List();
        }
        [HttpPost]
        public Room Create([FromBody] Dto.CreateRoom value)
        {
            var created = repository.Insert(value);
            if (created == null)
            {
                return null;
            }
            else return created;

        }
        [HttpDelete("delete/{id}")]
        public Room Delete(int id)
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
