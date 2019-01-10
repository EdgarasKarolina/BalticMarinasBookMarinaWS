using BalticMarinasBookMarinaWS.Models;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface IBerthRepository
    {
        void CreateBerth(Berth berth);
        List<Berth> GetAllBerths();
        List<Berth> GetAllBerthsByMarinaId(int id);
        Berth GetBerthByIdAndMarinaId(int marinaId, int berthId);
        List<Berth> GetReservedBerthsByMarinaIdAndDates(int marinaId, DateTime checkIn, DateTime checkOut);
        void DeleteBerth(int berthId);
    }
}
