using Cinema.Controllers.Dto;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface IRoomRepository
    {
        IReadOnlyCollection<Room> List();

        Room FindById(int roomId);

        Room Insert(CreateRoom value);
        Room Delete(int roomId);
    }
}
