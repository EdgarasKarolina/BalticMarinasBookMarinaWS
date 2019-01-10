using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BerthsController : ControllerBase
    {
        // POST api/berths
        [HttpPost]
        public void Post([FromBody] Berth berth)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            repository.CreateBerth(berth);
        }

        // GET api/berths
        [HttpGet]
        public IEnumerable<Berth> GetAll()
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            return repository.GetAllBerths();
        }

        // GET api/marinas/5/berths
        [HttpGet("marinas/{id}/berths")]
        public IEnumerable<Berth> GetAllForSpecificMarina(int id)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            return repository.GetAllBerthsByMarinaId(id);
        }
        // GET api/marinas/5/berths/3
        [HttpGet("marinas/{marinaId}/berths/{berthId}")]
        public Berth GetSpecificBerthForSpecificMarina(int marinaId, int berthId)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            return repository.GetBerthByIdAndMarinaId(marinaId, berthId);
        }

        // GET api/marinas/5/berths/checkin/2015-10-10/checkOut/2015-10-12
        [HttpGet("marinas/{marinaId}/berths/checkin/{checkIn}/checkout/{checkOut}")]
        public IEnumerable<Berth> GetNotReservedBerths(int marinaId, DateTime checkIn, DateTime checkOut)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            var listOfReservedBeths = repository.GetReservedBerthsByMarinaIdAndDates(marinaId, checkIn, checkOut);
            var listOfBerths = repository.GetAllBerthsByMarinaId(marinaId);
            List<Berth> listofFreeBerths = new List<Berth>();

            HashSet<int> reservedBerthsIds = new HashSet<int>();

            foreach (var berth in listOfReservedBeths)
            {
                reservedBerthsIds.Add(berth.BerthId);
            }
            return Methods.getFreeBerths(listOfBerths, reservedBerthsIds);
                //return listofFreeBerths;
        }

        // GET api/berths/5
        [HttpDelete("{berthId}")]
        public void Delete(int berthId)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BerthRepository)) as BerthRepository;
            repository.DeleteBerth(berthId);
        }
    }
}