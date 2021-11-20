using Microsoft.AspNetCore.Mvc;
using RoadMap.API.Entities;
using RoadMap.API.Services;
using System.Collections.Generic;

namespace RoadMap.API.Controllers
{
    [Route("api/Rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _roomService.GetRooms();

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomById([FromRoute]int id)
        {
            var room = _roomService.GetRoomById(id);

            return Ok(room);
        }

        [HttpPost("{idMap}")]
        public ActionResult CreateRoom([FromBody] Room room,[FromRoute]int idMap)
        {
            _roomService.CreateRoom(room,idMap);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRoom([FromRoute]int id)
        {
            _roomService.DeleteRoom(id);

            return Ok();
        }
    }
}
