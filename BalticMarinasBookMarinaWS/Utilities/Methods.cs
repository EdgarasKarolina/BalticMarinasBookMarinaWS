using BalticMarinasBookMarinaWS.Models;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Utilities
{
    public class Methods
    {
        public static List<Berth> getFreeBerths(List<Berth> listOfBerths, HashSet<int> reservedBerthsIds)
        {
            List<Berth> listofFreeBerths = new List<Berth>();
            foreach (var berth in listOfBerths)
            {
                bool exists = false;

                foreach (var reservedBerth in reservedBerthsIds)
                {
                    if (berth.BerthId == reservedBerth)
                    {
                        exists = true;
                    }
                    else { }
                }
                if (exists == false)
                {
                    listofFreeBerths.Add(berth);
                }
            }
            return listofFreeBerths;
        }
    }
}
