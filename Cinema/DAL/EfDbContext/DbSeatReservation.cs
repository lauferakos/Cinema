using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class DbSeatReservation
    {
        public int Id { get; set; }

        [ForeignKey("projections")]
        public int ProjectionId { get; set; }

        [ForeignKey("viewers")]
        public int ViewerId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
