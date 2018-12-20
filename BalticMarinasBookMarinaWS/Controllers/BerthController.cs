using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BerthController : ControllerBase
    {
        // GET api/berth
        [HttpGet]
        public IEnumerable<Berth> GetAll()
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthRepository)) as BerthRepository;
            return repository.GetAllBerths();
        }

        // GET api/berth/5
        [HttpGet("{id}")]
        public IEnumerable<Berth> GetAllForSpecificMarina(int id)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthRepository)) as BerthRepository;
            return repository.GetAllBerthsByMarinaId(id);
        }
        // GET api/berth/5/3
        [HttpGet("{marinaId}/{berthId}")]
        public Berth GetSpecificBerthForSpecificMarina(int marinaId, int berthId)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthRepository)) as BerthRepository;
            return repository.GetBerthByIdAndMarinaId(marinaId, berthId);
        }

        // GET api/berth/marinaId/checkIn/checkOut
        [HttpGet("{marinaId}/{checkIn}/{checkOut}")]
        public IEnumerable<Berth> GetNotReservedBerths(int marinaId, DateTime checkIn, DateTime checkOut)
        {
            IBerthRepository repository = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthRepository)) as BerthRepository;
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
    }
}