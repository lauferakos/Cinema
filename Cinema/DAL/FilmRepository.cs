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
    public class FilmRepository : IFilmRepository
    {
        private readonly CinemaDbContext db;

        public FilmRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public Film Delete(int filmId)
        {
            var dbFilm = db.Films.FirstOrDefault(f => f.Id == filmId);
            if (dbFilm == null)
            {
                return null;
            }
            else
            {
                db.Films.Remove(dbFilm);
                db.SaveChanges();

                return ToModel(dbFilm);
            }
        }

        public Film FindById(int filmId)
        {
            var dbFilm = db.Films.FirstOrDefault(f => f.Id == filmId);
            if (dbFilm == null)
                return null;
            else
                return ToModel(dbFilm);
        }
        public Film FindByName(string title)
        {
            var dbFilm = db.Films.FirstOrDefault(f => f.Title == title);
            if (dbFilm == null)
                return null;
            else
                return ToModel(dbFilm);
        }

        public IReadOnlyCollection<Film> List()
        {
            return db.Films.Select(ToModel).ToList();
        }
        private static Model.Film ToModel(DbFilm value)
        {
            return new Model.Film(value.Id, value.Title, value.Director, value.Description, value.Rating);
        }

        public IReadOnlyCollection<Film> ListPopularFilms()
        {
            return db.Films.Select(ToModel).OrderByDescending(f => f.Rating).ToList();
        }

        public Film Insert(CreateFilm value)
        {
            using (var tran = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
         
                var toInsert = new DbFilm() 
                {
                    Title = value.Title,
                    Director = value.Director,
                    Description = value.Description,
                    Rating = value.Rating
                };
                db.Films.Add(toInsert);

                db.SaveChanges();
                tran.Commit();

                return new Model.Film(toInsert.Id,toInsert.Title,toInsert.Director,toInsert.Description,toInsert.Rating);
            }
        }

        public Film Edit(int id, CreateFilm value)
        {
            var dbFilm = db.Films.FirstOrDefault(f => f.Id == id);
            if (dbFilm == null)
                return null;
            else
            {
                dbFilm.Title = value.Title;
                dbFilm.Director = value.Director;
                dbFilm.Description = value.Description;
                dbFilm.Rating = value.Rating;

                db.SaveChanges();

                return new Model.Film(dbFilm.Id,dbFilm.Title,dbFilm.Director,dbFilm.Description,dbFilm.Rating);
            }
        }
    }
}
