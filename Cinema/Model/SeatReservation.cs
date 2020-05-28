using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class SeatReservation
    {
        public int Id { get; set; }

        public int ProjectionId { get; set; }

        public int ViewerId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public SeatReservation(int id, int projectionId, int viewerId, int row, int column)
        {
            Id = id;
            ProjectionId = projectionId;
            ViewerId = viewerId;
            Row = row;
            Column = column;
        }
    }
}
