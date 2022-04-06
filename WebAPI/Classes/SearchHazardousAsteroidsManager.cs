using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Classes
{
    public class SearchHazardousAsteroidsManager : ISearchHazardousAsteroids
    {
        public List<Asteroids> GetHazardousAsteroids(Dictionary<string, NearEarthObjects[]> data, string planet)
        {
            List<Asteroids> list = new List<Asteroids>();
            foreach (var item in data)
            {
                var hazardous = item.Value.Where(w => w.IsPotentiallyHazardousAsteroid.Equals(true)
                                              && w.CloseApproachData.Any(a => a.OrbitingBody.ToLower().Equals(planet))).ToList();
                foreach (var elem in hazardous)
                {
                    Asteroids asteroids = new Asteroids();
                    asteroids.Name = elem.Name;
                    asteroids.Planet = elem.CloseApproachData.First().OrbitingBody;
                    asteroids.Diameter = (elem.EstimatedDiameter.Kilometers.EstimatedDiameterMin + elem.EstimatedDiameter.Kilometers.EstimatedDiameterMax) / 2;
                    asteroids.Velocity = elem.CloseApproachData.First().RelativeVelocity.KilometersPerHour;
                    asteroids.Date = elem.CloseApproachData.First().CloseApproachDate;

                    list.Add(asteroids);
                }
            }
            return list;
        }

        public List<Asteroids> GetTopHazardousAsteroidsDiameter(List<Asteroids> data, int top, string sortType = "desc")
        {
            if (sortType == "desc")
            {
                return data.OrderByDescending(o => o.Diameter).Take(top).ToList();
            } else
            {
                return data.OrderBy(o => o.Diameter).Take(top).ToList();
            }
        }
    }
}
