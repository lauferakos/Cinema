using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class DbOrder
    {
        public int Id { get; set; }

        [ForeignKey("projections")]
        public int ProjectionId { get; set; }
        public DbProjection Projection { get; set; }

        public int Price { get; set; }

        public int ReservedSeats { get; set; }

        [ForeignKey("viewers")]
        public int ViewerId { get; set; }
        public DbViewer Viewer { get; set; }
    }
}
