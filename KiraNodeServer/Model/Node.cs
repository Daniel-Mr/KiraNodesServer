using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiraNodeServer.Model
{
    public class Node
    {
        [Key]
        public string Id { get; set; }
        public string SocketId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
