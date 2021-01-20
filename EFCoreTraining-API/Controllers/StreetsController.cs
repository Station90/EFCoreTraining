using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTraining_API.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreTraining_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetsController : ControllerBase
    {
        private MyContext context;
        
        public StreetsController(MyContext context)
        {
            this.context = context;
        }
        
        // GET: api/<StreetsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return context.Streets.SelectMany(x=>x.PostalCodeStreets.Select(x=>x.PostalCodes.Code)).ToList();
        }

        // GET api/<StreetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StreetsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StreetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StreetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
