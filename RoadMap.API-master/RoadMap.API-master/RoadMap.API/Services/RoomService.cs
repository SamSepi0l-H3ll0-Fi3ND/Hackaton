using Microsoft.EntityFrameworkCore;
using RoadMap.API.Entities;
using RoadMap.API.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMap.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly MapDbContext _mapDbContext;
        
        public RoomService(MapDbContext mapDbContext)
        {
            _mapDbContext = mapDbContext;
        }

        public async Task CreateRoom(Room room, int id)
        {
            var map = _mapDbContext.Maps.FirstOrDefault(x => x.Id == id);

            map.Rooms.Add(room);
            await _mapDbContext.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = _mapDbContext.Rooms.FirstOrDefault(x => x.Id_Room == id);

            if (room is null)
                throw new Exception($"Room with id: {id}");

            _mapDbContext.Rooms.Remove(room);
            await _mapDbContext.SaveChangesAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _mapDbContext.Rooms.Include(x=>x.Type).FirstOrDefaultAsync(x => x.Id_Room == id);

            if (room is null)
                throw new Exception($"Room with id: {id}");

            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _mapDbContext.Rooms.ToListAsync();

            if (rooms is null)
                throw new Exception("Rooms is null");

            return rooms;
        }
    }
}
