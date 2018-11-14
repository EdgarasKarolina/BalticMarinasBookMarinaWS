﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalticMarinasBookMarinaWS.Models;
using Microsoft.AspNetCore.Mvc;

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
        public Marina Get(int id)
        {
            MarinaContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.MarinaContext)) as MarinaContext;
            return context.GetMarinaById(id);
        }

        // GET api/marina/5
        [HttpGet("{country}")]
        public IEnumerable<Marina> Get(string country)
        {
            MarinaContext context = HttpContext.RequestServices.GetService(typeof(BalticMarinasBookMarinaWS.Models.MarinaContext)) as MarinaContext;
            return context.GetAllMarinasByCountry(country);
        }
    }
}