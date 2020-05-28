using Cinema.Controllers.Dto;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface IFilmRepository
    {
        IReadOnlyCollection<Film> List();

        IReadOnlyCollection<Film> ListPopularFilms();
        Film FindByName(string title);

        Film FindById(int filmId);

        Film Insert(CreateFilm value);
        Film Delete(int filmId);

        Film Edit(int id, CreateFilm value);
    }
}
