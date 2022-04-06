using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface ISearchHazardousAsteroids
    {
        List<Asteroids> GetHazardousAsteroids(Dictionary<string, NearEarthObjects[]> data, string planet);
        List<Asteroids> GetTopHazardousAsteroidsDiameter(List<Asteroids> data, int top, string sortType = "desc");

    }
}
