using BalticMarinasBookMarinaWS.Models;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface IReservationRepository
    {
        void CreateReservation(Reservation reservation);
        void UpdateReservation(int reservationId);
        void DeleteNotPaidReservation(int reservationId);
        List<Reservation> GetAllReservationsByCustomerId(int id);
        //List<Reservation> GetAllReservationsByBerthId(int berthId, DateTime checkIn, DateTime checkOut);
        int GetReservationId(int berthId, int CustomerId, DateTime checkIn, DateTime checkOut);

    }
}
