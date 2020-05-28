using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<Seat> Seats { get; set; }
        public Room(int id, int capacity)
        {
            Id = id;
            Capacity = capacity;
        }
    }
}
