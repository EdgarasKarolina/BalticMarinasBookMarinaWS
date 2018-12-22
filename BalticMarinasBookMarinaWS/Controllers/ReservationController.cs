using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        // GET api/reservation/1
        [HttpGet("{customerId}")]
        public IEnumerable<Reservation> GetAllReservationsByCustomerId(int customerId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetAllReservationsByCustomerId(customerId);
        }

        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.CreateReservation(reservation);
        }
    }
}