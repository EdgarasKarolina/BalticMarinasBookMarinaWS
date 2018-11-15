using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        // POST api/event
        [HttpPost("{berthId}/{customerId}/{checkIn}/{checkOut}")]
        public void Post(int berthId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            ReservationContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.ReservationContext)) as ReservationContext;
            context.CreateReservation(berthId, customerId, checkIn, checkOut);
        }
    }
}