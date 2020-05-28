using Cinema.Controllers.Dto;
using Cinema.DAL.EfDbContext;
using Cinema.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly CinemaDbContext db;

        public ProjectionRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Projection Delete(int projId)
        {
            var dbProjection = db.Projections.FirstOrDefault(t => t.Id == projId);
            if (dbProjection == null)
            {
                return null;
            }
            else
            {
                db.Projections.Remove(dbProjection);
                db.SaveChanges();

                return ToModel(dbProjection);
            }
        }

        public Projection FindById(int projId)
        {
            var dbProjection = db.Projections.FirstOrDefault(t => t.Id == projId);
            if (dbProjection == null)
                return null;
            else
                return ToModel(dbProjection);
        }

        public IReadOnlyCollection<Projection> List()
        {
            return db.Projections.Include(p => p.Film).Select(ToModel).ToList();
        }

        private static Model.Projection ToModel(DbProjection value)
        {
            if (value.Film == null)
            {
                return new Model.Projection(value.Id, value.FilmId, value.RoomId, value.Start);
            }
            else
            {
                return new Model.Projection(
                    value.Id,
                    value.FilmId,
                    new Model.Film(
                        value.Film.Id,
                        value.Film.Title,
                        value.Film.Director,
                        value.Film.Description,
                        value.Film.Rating),
                    value.RoomId,
                    value.Start);
            }
        }

        public IReadOnlyCollection<Projection> GetProjectionsByFilm(int filmId)
        {
            return db.Projections.Where(p => p.FilmId == filmId).Select(ToModel).ToList();
        }

        public Projection Insert(CreateProjection value)
        {
            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {

                var toInsert = new DbProjection()
                {
                    FilmId = value.FilmId,
                    RoomId = value.RoomId,
                    Start = value.Start
                };
                db.Projections.Add(toInsert);

                db.SaveChanges();
                tran.Commit();

                return new Model.Projection(toInsert.Id, toInsert.FilmId, toInsert.RoomId, toInsert.Start);
            }
        }

        public Projection Edit(int id, CreateProjection value)
        {
            var dbProjection = db.Projections.FirstOrDefault(p => p.Id == id);
            if (dbProjection == null)
                return null;
            else
            {
                dbProjection.FilmId = value.FilmId;
                dbProjection.RoomId = value.RoomId;
                dbProjection.Start = value.Start;


                db.SaveChanges();

                return new Model.Projection(dbProjection.Id, dbProjection.FilmId, dbProjection.RoomId, dbProjection.Start);
            }
        }
    }
}
