using BalticMarinasBookMarinaWS.Models;
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
            BerthContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthContext)) as BerthContext;
            return context.GetAllBerths();
        }

        // GET api/berth/5
        [HttpGet("{id}")]
        public IEnumerable<Berth> GetAllForSpecificMarina(int id)
        {
            BerthContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthContext)) as BerthContext;
            return context.GetAllBerthsByMarinaId(id);
        }
        // GET api/berth/5/3
        [HttpGet("{marinaId}/{berthId}")]
        public Berth GetSpecificBerthForSpecificMarina(int marinaId, int berthId)
        {
            BerthContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthContext)) as BerthContext;
            return context.GetBerthByIdAndMarinaId(marinaId, berthId);
        }

        // GET api/berth/marinaId/checkIn/checkOut
        [HttpGet("{marinaId}/{checkIn}/{checkOut}")]
        public IEnumerable<Berth> GetNotReservedBerths(int marinaId, DateTime checkIn, DateTime checkOut)
        {
            BerthContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.BerthContext)) as BerthContext;
            var listOfReservedBeths = context.GetReservedBerthsByMarinaIdAndDates(marinaId, checkIn, checkOut);
            var listOfBerths = context.GetAllBerthsByMarinaId(marinaId);
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