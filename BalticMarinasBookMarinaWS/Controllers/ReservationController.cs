using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            ReservationContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.ReservationContext)) as ReservationContext;
            context.CreateReservation(reservation);
        }
    }
}