using BalticMarinasBookMarinaWS.Models;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface IReservationRepository
    {
        void CreateReservation(Reservation reservation);
        List<Reservation> GetAllReservationsByCustomerId(int id);
        List<Reservation> GetAllReservationsByBerthId(int berthId, DateTime checkIn, DateTime checkOut);

    }
}
