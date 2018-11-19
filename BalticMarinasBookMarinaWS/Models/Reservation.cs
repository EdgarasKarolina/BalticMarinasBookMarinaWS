using System;

namespace BalticMarinasBookMarinaWS.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int BerthId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int IsPaid { get; set; }
    }
}
