using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class DbRoom
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<DbSeat> Seats { get; set; }
    }
}
