using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Seat(int id, int row, int column)
        {
            Id = id;
            Row = row;
            Column = column;
        }

    }
}
