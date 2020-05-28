using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class DbSeat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        [ForeignKey("rooms")]
        public int RoomId { get; set; }
        public DbRoom Room { get; set; }
    }
}
