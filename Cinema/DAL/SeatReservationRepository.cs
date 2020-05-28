using Cinema.DAL.EfDbContext;
using Cinema.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public class SeatReservationRepository : ISeatReservationRepository
    {
        private readonly CinemaDbContext db;

        public SeatReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IReadOnlyCollection<SeatReservation> GetReservationsByViewer(int id)
        {
            return db.Reservations.Select(ToModel).Where(r => r.ViewerId == id).ToList();
        }
        private static Model.SeatReservation ToModel(DbSeatReservation value)
        {
            return new Model.SeatReservation(value.Id, value.ProjectionId,value.ViewerId,value.Row,value.Column);
        }

        public bool InsertSeats(int projid, int viewerid, int seats, int r, int c)
        {
            int maxRow = 6;
            int maxCol = 5;

            bool result = false;

            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                for (int i = 0; i < seats; i++)
                {
                    c++;
                    if (c > maxCol)
                    {
                        c = 1;
                        r++;
                    }

                    if (r > maxRow)
                    {
                        result = false;
                        tran.Rollback();
                    }
                    var toInsert = new DbSeatReservation()
                    {
                        ProjectionId = projid,
                        ViewerId = viewerid,
                        Row = r,
                        Column = c
                    };
                    db.Reservations.Add(toInsert);
                   
                }
                result = true;
                db.SaveChanges();
                tran.Commit();
            }
            return result;
        }
        public bool ReserveSeats(int projid, int viewerid, int seats)
        {
            int maxRow = 6;
            int maxCol = 5;

            bool hasElement = db.Reservations.Any(r => r.ProjectionId == projid);
            //Ha üres beszúrjuk
            if (!hasElement)
            {
             return InsertSeats(projid,viewerid,seats,1,0);
            }
            else
            {
                var dbReservations = db.Reservations.Where(r => r.ProjectionId == projid).ToList();
                //Max számú szék keresése
                var last = dbReservations.Last();

                if (last.Row == maxRow && last.Column == maxCol)
                {
                    //Ha nincs hely return false
                    return false;
                }
                else
                {
                    //Ha van még hely beszúrjuk
                    return InsertSeats(projid,viewerid,seats,last.Row,last.Column);
                }
            }
        }
    }
}
