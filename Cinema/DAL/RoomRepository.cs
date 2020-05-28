using Cinema.Controllers.Dto;
using Cinema.DAL.EfDbContext;
using Cinema.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaDbContext db;

        public RoomRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Room Delete(int roomId)
        {
            var dbRoom = db.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (dbRoom == null)
            {
                return null;
            }
            else
            {
                db.Rooms.Remove(dbRoom);
                db.SaveChanges();

                return ToModel(dbRoom);
            }
        }

        public Room FindById(int roomId)
        {
            var dbRoom = db.Rooms.FirstOrDefault(t => t.Id == roomId);
            if (dbRoom == null)
                return null;
            else
                return ToModel(dbRoom);
        }

        public IReadOnlyCollection<Room> List()
        {
            return db.Rooms.Select(ToModel).ToList();
        }

        private static Model.Room ToModel(DbRoom value)
        {
            return new Model.Room(value.Id, value.Capacity);
        }

        public Room Insert(CreateRoom value)
        {
            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {

                var toInsert = new DbRoom()
                {
                    Capacity = value.Capacity
                };
                db.Rooms.Add(toInsert);

                db.SaveChanges();
                tran.Commit();

                return new Model.Room(toInsert.Id, toInsert.Capacity);
            }
        }
    }
}
