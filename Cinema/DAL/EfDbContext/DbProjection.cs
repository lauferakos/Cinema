using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class DbProjection
    {
        public int Id { get; set; }
        [ForeignKey("films")]
        public int FilmId { get; set; }
        public DbFilm Film { get; set; }

        [ForeignKey("rooms")]
        public int RoomId { get; set; }
        public DbRoom Room { get; set; }

        public DateTime Start { get; set; }
    }
}
