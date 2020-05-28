using Cinema.Controllers.Dto;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface IProjectionRepository
    {
        IReadOnlyCollection<Projection> List();

        Projection FindById(int projId);

        Projection Insert(CreateProjection value);
        Projection Delete(int projId);
        Projection Edit(int id, CreateProjection value);

        IReadOnlyCollection<Projection> GetProjectionsByFilm(int filmId);
    }
}
