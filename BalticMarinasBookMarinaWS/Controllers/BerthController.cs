using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;

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

            HashSet<int> myHashSet = new HashSet<int>();
            foreach (var berth in listOfReservedBeths)
            {
                myHashSet.Add(berth.BerthId);
            }

                foreach (var berth in listOfBerths)
                {
                    bool exists = false;

                    foreach (var reservedBerth in myHashSet)
                    {
                        if (berth.BerthId == reservedBerth)
                        {
                            exists = true;
                        }
                        else
                        {

                        }
                    }
                    if(exists == false)
                    {
                    listofFreeBerths.Add(berth);
                    }
                } 
                return listofFreeBerths;
        }
    }
}