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
    public class DevicesController : ControllerBase
    {
        DataContext db = new DataContext();

        // GET: api/Devices
        [HttpGet]
        public IEnumerable<Device> Get()
        {
            return db.Devices;
        }

        [HttpGet("GetByNode/{node}")]
        public IEnumerable<Device> GetByNode(string node)
        {
            return db.Devices.Where(a => a.NodeId == node);
        }

        [HttpGet("GetByZone/{id}")]
        public IEnumerable<Device> GetByZone(int id)
        {
            return db.Devices.Where(a => a.ZoneId == id);
        }

        // GET: api/Devices/5
        [HttpGet("GetById/{id:int}")]
        public Device GetById(int id)
        {
            return db.Devices.Find(id);
        }

        // POST: api/Devices
        [HttpPost]
        public void Post(Device input)
        {
            db.Devices.Add(input);
            db.SaveChanges();
        }

        // PUT: api/Devices/5
        [HttpPut]
        public void Put(Device input)
        {
            db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Remove(new Device { Id = id });
            db.SaveChanges();
        }
    }
}
