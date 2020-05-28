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
    public class OrderRepository : IOrderRepository
    {
        private readonly CinemaDbContext db;

        public OrderRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Order Delete(int orderId)
        {
            var dbOrder = db.Orders.FirstOrDefault(o => o.Id == orderId);
            if (dbOrder == null)
            {
                return null;
            }
            else
            {
                db.Orders.Remove(dbOrder);
                db.SaveChanges();

                return ToModel(dbOrder);
            }
        }

        public Order FindById(int orderId)
        {
            var dbOrder = db.Orders.FirstOrDefault(t => t.Id == orderId);
            if (dbOrder == null)
                return null;
            else
                return ToModel(dbOrder);
        }

        public IReadOnlyCollection<Order> List()
        {
            return db.Orders.Select(ToModel).ToList();
        }

        private static Model.Order ToModel(DbOrder value)
        {
            
            if (value.Projection != null && value.Projection.Film != null)
            {
                return new Model.Order(
                    value.Id,
                    value.ProjectionId, 
                    new Model.Projection(
                        value.Projection.Id,
                        value.Projection.FilmId,
                        new Model.Film(
                            value.Projection.Film.Id,
                            value.Projection.Film.Title,
                            value.Projection.Film.Director,
                            value.Projection.Film.Description,
                            value.Projection.Film.Rating),
                        value.Projection.RoomId,
                        value.Projection.Start),
                    value.Price, 
                    value.ReservedSeats, 
                    value.ViewerId);
            }
            else
            {
                return new Model.Order(value.Id, value.ProjectionId, value.Price, value.ReservedSeats, value.ViewerId);
            }
        }

        public IReadOnlyCollection<Order> GetOrdersByViewerId(int viewerId)
        {
            return db.Orders.Include(o => o.Projection).ThenInclude(p => p.Film).Where(o => o.ViewerId == viewerId).Select(ToModel).ToList();
        }

        public Order Insert(CreateOrder value)
        {
            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {

                var toInsert = new DbOrder()
                {
                   ProjectionId = value.ProjectionId,
                   Price = value.Price,
                   ReservedSeats = value.ReservedSeats,
                   ViewerId = value.ViewerId
                };
                db.Orders.Add(toInsert);

                db.SaveChanges();
                tran.Commit();

                return new Model.Order(toInsert.Id, toInsert.ProjectionId, toInsert.Price, toInsert.ReservedSeats, toInsert.ViewerId);
            }
        }
    }
}
