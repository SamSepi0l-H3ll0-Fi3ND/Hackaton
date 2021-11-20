using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoadMap.API.Entities
{
    public class Room
    {
        [Key]
        public int Id_Room { get; set; }

        public int Position_X { get; set; }
        
        public int Position_Y { get; set; }

        public RoomType Type { get; set; }

        public List<OthersType> Others { get; set; }
    }
}