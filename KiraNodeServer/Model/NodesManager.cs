using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiraNodeServer.Model
{
    public class NodesManager
    {

        private DataContext db = new DataContext();

        public IEnumerable<Node> GetAll()
        {
            return db.Nodes;
        }
        public IEnumerable<Node> GetAllFromUser(string username)
        {
            var nodes = db.UsersNodes.Where(a => a.UserName == username).Select(a => a.NodeId);

            return db.Nodes.Where(a => nodes.Contains(a.Id));

        }

        public Node Get(string id)
        {
            return db.Nodes.Find(id);
        }

        public void Insert(Node input)
        {

            var existing = db.Nodes.Find(input.Id);

            if (existing == null)
            {
                db.Nodes.Add(input);
                db.SaveChanges();
            }
            else
            {
                existing.SocketId = input.SocketId;
                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

        public void Update(Node input)
        {
            db.Entry(input).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            db.Remove(new Node { Id = id });
            db.SaveChanges();
        }

        public void AddToUser(string username, string nodeid)
        {
            db.Add(new UserNode { UserName = username, NodeId = nodeid });
            db.SaveChanges();
        }

    }
}
