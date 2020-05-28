using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Projection
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime Start { get; set; }

        public Projection(int id, int filmId, int roomId, DateTime start)
        {
            Id = id;
            FilmId = filmId;
            RoomId = roomId;
            Start = start;
        }
        public Projection(int id, int filmId,Film film ,int roomId, DateTime start)
        {
            Id = id;
            FilmId = filmId;
            RoomId = roomId;
            Start = start;
            Film = film;
        }
    }
}
