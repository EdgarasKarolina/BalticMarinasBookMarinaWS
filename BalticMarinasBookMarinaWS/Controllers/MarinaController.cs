using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarinaController : ControllerBase
    {
        // GET api/marina
        [HttpGet]
        public IEnumerable<Marina> GetAll()
        {
            MarinaContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.MarinaContext)) as MarinaContext;
            return context.GetAllMarinas();
        }

        // GET api/marina/5
        [HttpGet("{id}")]
        public Marina GetMarinaById(int id)
        {
            MarinaContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.MarinaContext)) as MarinaContext;
            return context.GetMarinaById(id);
        }

        // GET api/marina/country/1
        [HttpGet("country/{country}")]
        public IEnumerable<Marina> GetAllMarinasByCountry(string country)
        {
            MarinaContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.MarinaContext)) as MarinaContext;
            return context.GetAllMarinasByCountry(country);
        }
    }
}