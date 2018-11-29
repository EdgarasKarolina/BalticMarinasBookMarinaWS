using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        // GET api/reservation/1
        [HttpGet("reservation/{userId}")]
        public IEnumerable<Reservation> GetAllReservationsByCustomerId(int customerId)
        {
            ReservationContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.ReservationContext)) as ReservationContext;
            return context.GetAllReservationsByCustomerId(customerId);
        }

        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            ReservationContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.ReservationContext)) as ReservationContext;
            context.CreateReservation(reservation);
        }
    }
}