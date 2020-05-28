using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL
{
    public interface ISeatReservationRepository
    {
        bool ReserveSeats(int projid,int viewerid,int seats);

        IReadOnlyCollection<SeatReservation> GetReservationsByViewer(int id);
    }
}
