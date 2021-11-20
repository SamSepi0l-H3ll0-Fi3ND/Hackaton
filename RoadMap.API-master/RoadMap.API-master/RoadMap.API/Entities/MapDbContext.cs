using Microsoft.EntityFrameworkCore;

namespace RoadMap.API.Entities
{
    public class MapDbContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<Room> Rooms  { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<OthersType> OthersTypes { get; set; }

        public MapDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
