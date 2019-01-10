using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarinasController : ControllerBase
    {
        // POST api/marinas
        [HttpPost]
        public void Post([FromBody] Marina marina)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            repository.CreateMarina(marina);
        }

        // GET api/marinas
        [HttpGet]
        public IEnumerable<Marina> GetAll()
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetAllMarinas();
        }

        // GET api/marinas/5
        [HttpGet("{id}")]
        public Marina GetMarinaById(int id)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetMarinaById(id);
        }

        // GET api/countries/1/marinas
        [HttpGet("countries/{country}/marinas")]
        public IEnumerable<Marina> GetAllMarinasByCountry(string country)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetAllMarinasByCountry(country);
        }

        // GET api/marinas/marinasnames
        [HttpGet("marinasNames")]
        public IEnumerable<string> GetAllMarinasNames()
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetAllMarinasNames();
        }

        // GET api/marinas/marinaname/marinaId
        [HttpGet("{marinaName}/marinaId")]
        public int GetMarinaIdByMarinaName(string marinaName)
        {
            IMarinaRepository repository = HttpContext.RequestServices.GetService(typeof(MarinaRepository)) as MarinaRepository;
            return repository.GetMarinaIdByMarinaName(marinaName);
        }
    }
}