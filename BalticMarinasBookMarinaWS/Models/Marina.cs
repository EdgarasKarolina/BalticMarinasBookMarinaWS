using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasBookMarinaWS.Models
{
    public class Marina
    {
        public int MarinaId { get; set; }
        public string MarinaName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Depth { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string ZipCodeNumber { get; set; }
        public int TotalBerths { get; set; }
        public int IsToilet { get; set; }
        public int IsShower { get; set; }
        public int IsInternet { get; set; }
    }
}
