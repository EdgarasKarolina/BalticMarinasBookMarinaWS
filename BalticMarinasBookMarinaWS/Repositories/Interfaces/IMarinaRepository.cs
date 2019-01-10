using BalticMarinasBookMarinaWS.Models;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface IMarinaRepository
    {
        void CreateMarina(Marina marina);
        List<Marina> GetAllMarinas();
        Marina GetMarinaById(int id);
        List<Marina> GetAllMarinasByCountry(string country);
        List<string> GetAllMarinasNames();
        int GetMarinaIdByMarinaName(string marinaName);
    }
}
