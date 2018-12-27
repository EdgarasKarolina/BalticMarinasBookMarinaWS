using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // GET api/reservations/1
        [HttpGet("reservations/{reservationId}")]
        public int GetIfReservationExists(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetIfReservationExists(reservationId);
        }

        // GET api/customer/1/reservations
        [HttpGet("customers/{customerId}/reservations")]
        public IEnumerable<Reservation> GetAllReservationsByCustomerId(int customerId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetAllReservationsByCustomerId(customerId);
        }

        // GET api/berths/1/customers/3/checkin/2014-10-12/checkout/2014-10-15
        [HttpGet("berths/{berthId}/customers/{customerId}/checkin/{checkIn}/checkout/{checkOut}")]
        public int GetReservationId(int berthId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetReservationId(berthId, customerId, checkIn, checkOut);
        }

        // POST api/reservations
        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.CreateReservation(reservation);
        }

        // PUT api/reservations/5
        [HttpPut("{reservationId}")]
        public void Put(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.UpdateReservation(reservationId);
        }

        // GET api/reservations/5
        [HttpDelete("{reservationId}")]
        public void Delete(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.DeleteNotPaidReservation(reservationId);
        }
    }
}