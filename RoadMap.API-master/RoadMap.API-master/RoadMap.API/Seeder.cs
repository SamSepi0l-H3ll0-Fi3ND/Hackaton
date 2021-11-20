using RoadMap.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMap.API
{
    public class Seeder
    {
        private readonly MapDbContext _dbContext;

        public Seeder(MapDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Maps.Any())
                {
                    var map = GetMap();
                    _dbContext.Maps.Add(map);
                    _dbContext.SaveChanges();
                }
            }
        }

        private Map GetMap()
        {
            return new Map()
            {
                X = 500,
                Y = 500,
                Rooms = new List<Room>()
                {
                    new Room(){ Position_X = 100, Position_Y = 200, Type = new RoomType(){ Type = "Room"}},
                    new Room(){ Position_X = 200, Position_Y = 150, Type = new RoomType(){ Type = "Kitchen"}}
                }
            };
        }
    }
}
