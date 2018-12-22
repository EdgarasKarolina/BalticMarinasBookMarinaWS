using BalticMarinasBookMarinaWS.Models;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface IMarinaRepository
    {
        List<Marina> GetAllMarinas();
        Marina GetMarinaById(int id);
        List<Marina> GetAllMarinasByCountry(string country);
    }
}
