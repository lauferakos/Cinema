using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Order
    {
        public int Id { get; set; }

        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }

        public int Price { get; set; }

        public int ReservedSeats { get; set; }
        public int ViewerId { get; set; }

        public Order(int id, int projectionId,int price, int reservedSeats, int viewerId)
        {
            Id = id;
            ProjectionId = projectionId;
            Price = price;
            ReservedSeats = reservedSeats;
            ViewerId = viewerId;
           
        }
        public Order(int id, int projectionId,Projection projection, int price, int reservedSeats, int viewerId)
        {
            Id = id;
            ProjectionId = projectionId;
            Price = price;
            ReservedSeats = reservedSeats;
            ViewerId = viewerId;
            Projection = projection;

        }
    }
}
