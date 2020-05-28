using Cinema.DAL.EfDbContext;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaDbContext db;

        public SeatRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Seat Delete(int seatId)
        {
            var dbSeat = db.Seats.FirstOrDefault(t => t.Id == seatId);
            if (dbSeat == null)
            {
                return null;
            }
            else
            {
                db.Seats.Remove(dbSeat);
                db.SaveChanges();

                return ToModel(dbSeat);
            }
        }

        public Seat FindById(int seatId)
        {
            var dbSeat = db.Seats.FirstOrDefault(t => t.Id == seatId);
            if (dbSeat == null)
                return null;
            else
                return ToModel(dbSeat);
        }

        public IReadOnlyCollection<Seat> List()
        {
            return db.Seats.Select(ToModel).ToList();
        }

        private static Model.Seat ToModel(DbSeat value)
        {
            return new Model.Seat(value.Id, value.Row, value.Column);
        }
    }
}
