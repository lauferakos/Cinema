using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface ISeatRepository
    {
        IReadOnlyCollection<Seat> List();

        Seat FindById(int seatId);

        //Seat Insert(CreateSeat value);
        Seat Delete(int seatId);
    }
}
