using RoadMap.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadMap.API.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetRooms();
        Task<Room> GetRoomById(int id);
        Task CreateRoom(Room dto,int id);
        Task DeleteRoom(int id);
    }
}
