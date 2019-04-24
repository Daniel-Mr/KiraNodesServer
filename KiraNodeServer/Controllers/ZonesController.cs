using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KiraNodeServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiraNodeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {

        DataContext db = new DataContext();

        // GET: api/Zones
        [HttpGet("{userId}")]
        public IEnumerable<Zone> Get(string userId)
        {
            return db.Zones.Where(a => a.UserId == userId);
        }

        // GET: api/Zones/5
        [HttpGet("GetById/{id}", Name = "Get")]
        public Zone Get(int id)
        {
            return db.Zones.Find(id);
        }

        // POST: api/Zones
        [HttpPost]
        public void Post(Zone input)
        {
            db.Zones.Add(input);
            db.SaveChanges();
        }

        // PUT: api/Zones/
        [HttpPut]
        public void Put(Zone input)
        {
            db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE: api/Zones/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Remove(new Zone { Id = id });
            db.SaveChanges();
        }
    }
}
