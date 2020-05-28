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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IReadOnlyCollection<Order> Get()
        {
            return repository.List();
        }

        [HttpGet("{id}")]
        public IReadOnlyCollection<Order> GetOrdersByFilm(int id)
        {
            return repository.GetOrdersByViewerId(id);
        }

        [HttpDelete("delete/{id}")]
        public Order Delete(int id)
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
        public Order Create([FromBody] Dto.CreateOrder value)
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
