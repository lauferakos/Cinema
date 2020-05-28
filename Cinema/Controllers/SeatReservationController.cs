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
    public class SeatReservationController : ControllerBase
    {
        private readonly ISeatReservationRepository repository;

        public SeatReservationController(ISeatReservationRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("reserve/{projid}/{viewerid}/{seats}")]
        public bool ReserveSeats(int projid, int viewerid, int seats)
        {
            return repository.ReserveSeats(projid,viewerid,seats);
        }

        [HttpGet("{id}")]
        public IReadOnlyCollection<SeatReservation> Get(int id)
        {
            var value = repository.GetReservationsByViewer(id);
            if (value == null)
                return null;
            else
                return value;
        }
    }
}
