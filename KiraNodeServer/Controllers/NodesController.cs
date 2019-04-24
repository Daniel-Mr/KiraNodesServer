using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KiraNodeServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace KiraNodeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {

        DataContext db = new DataContext();
        NodesManager mgr = new NodesManager();

        // GET api/nodes
        [HttpGet]
        [Route("")]
        public IEnumerable<Node> Get()
        {
            return mgr.GetAll();
        }

        // GET api/nodes/GetByNode/abc
        [HttpGet]
        [Route("GetByNode/{node}", Name = "GetByNode")]
        public ActionResult<Node> Get(string node)
        {
            return mgr.Get(node);
        }

        // GET api/nodes/GetByUserName/abc
        [HttpGet]
        [Route("GetByUserName/{username}", Name = "GetByUserName")]
        public IEnumerable<Node> GetUserNodes(string username)
        {
            return mgr.GetAllFromUser(username);
        }

        // POST api/nodes
        [HttpPost]
        public void Post(Node input)
        {
            mgr.Insert(input);
        }

        // PUT api/nodes/5
        [HttpPut("{id}")]
        public void Put(Node input)
        {
            mgr.Update(input);
        }

        // DELETE api/nodes/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            mgr.Delete(id);
        }

        // POST api/nodes
        [HttpPost]
        [Route("AddToUser")]
        public void AddToUser(string username, string nodeid)
        {
            mgr.AddToUser(username, nodeid);
        }

    }
}
