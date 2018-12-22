using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
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
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetAllMarinas();
        }

        // GET api/marina/5
        [HttpGet("{id}")]
        public Marina GetMarinaById(int id)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetMarinaById(id);
        }

        // GET api/marina/country/1
        [HttpGet("country/{country}")]
        public IEnumerable<Marina> GetAllMarinasByCountry(string country)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetAllMarinasByCountry(country);
        }
    }
}