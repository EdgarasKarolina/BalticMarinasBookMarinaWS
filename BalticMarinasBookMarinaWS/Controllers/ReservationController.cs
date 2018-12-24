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
    public class ReservationController : ControllerBase
    {
        [HttpGet("{reservationId}")]
        public int GetIfReservationExists(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetIfReservationExists(reservationId);
        }

        // GET api/reservation/1
        [HttpGet("{customerId}")]
        public IEnumerable<Reservation> GetAllReservationsByCustomerId(int customerId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetAllReservationsByCustomerId(customerId);
        }

        // GET api/reservation/1
        [HttpGet("{berthId}/{customerId}/{checkIn}/{checkOut}")]
        public int GetReservationId(int berthId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            return repository.GetReservationId(berthId, customerId, checkIn, checkOut);
        }

        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.CreateReservation(reservation);
        }

        [HttpPut("{reservationId}")]
        public void Put(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.UpdateReservation(reservationId);
        }

        // GET api/solditem/5
        [HttpDelete("{reservationId}")]
        public void Delete(int reservationId)
        {
            IReservationRepository repository = HttpContext.RequestServices.GetService(typeof(ReservationRepository)) as ReservationRepository;
            repository.DeleteNotPaidReservation(reservationId);
        }
    }
}