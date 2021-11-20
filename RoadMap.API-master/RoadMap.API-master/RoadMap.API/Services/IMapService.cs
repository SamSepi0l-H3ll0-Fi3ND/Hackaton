using RoadMap.API.Entities;
using RoadMap.API.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMap.API.Services
{
    public interface IMapService
    {
        Map GetMap();
        Map GetMapById(int id);
        void DeleteMap(int id);
        void CreateMap(Map dto);
    }
}
