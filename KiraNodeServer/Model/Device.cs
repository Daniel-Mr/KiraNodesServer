using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KiraNodeServer.Model
{
    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NodeId { get; set; }
        public int PinNumber { get; set; }
        public string Name { get; set; }
        public int? ZoneId { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }
}
