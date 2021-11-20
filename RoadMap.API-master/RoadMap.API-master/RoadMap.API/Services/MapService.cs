using Microsoft.EntityFrameworkCore;
using RoadMap.API.Entities;
using System;
using System.Linq;

namespace RoadMap.API.Services
{
    public class MapService : IMapService
    {
        private readonly MapDbContext _dbContext;
        public MapService(MapDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Map GetMap()
        {
            var map = _dbContext.Maps.Include(x=>x.Rooms).FirstOrDefault();

            if (map is null)
                throw new Exception("Cannot get map");

            return map;
        }

        public void DeleteMap(int id)
        {
            var map = _dbContext.Maps.FirstOrDefault(x=>x.Id == id);
            _dbContext.Maps.Remove(map);
            _dbContext.SaveChanges();
        }

        public void CreateMap(Map map)
        {
            _dbContext.Maps.Add(map);
            _dbContext.SaveChanges();
        }
    }
}
