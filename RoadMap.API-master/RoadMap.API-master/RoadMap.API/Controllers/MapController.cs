using Microsoft.AspNetCore.Mvc;
using RoadMap.API.Entities;
using RoadMap.API.Services;

namespace RoadMap.API.Controllers
{
    [Route("api/Map")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapDbContext;

        public MapController(IMapService mapDbContext)
        {
            _mapDbContext = mapDbContext;
        }

        [HttpPost]
        public ActionResult CreateMap([FromBody] Map map)
        {
            _mapDbContext.CreateMap(map);

            return Ok();
        }

        [HttpGet]
        public ActionResult<Map> GetMap()
        {
            var map = _mapDbContext.GetMap();

            return Ok(map);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMap([FromRoute] int id)
        {
            _mapDbContext.DeleteMap(id);

            return NoContent();
        }
    }
}
