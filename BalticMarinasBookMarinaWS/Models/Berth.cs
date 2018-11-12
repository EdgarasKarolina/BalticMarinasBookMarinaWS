using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasBookMarinaWS.Models
{
    public class Berth
    {
        public int BerthId { get; set; }
        public int MarinaId { get; set; }
        public double Price { get; set; }
    }
}
