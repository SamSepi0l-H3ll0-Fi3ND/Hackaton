using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMap.API.Entities
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
