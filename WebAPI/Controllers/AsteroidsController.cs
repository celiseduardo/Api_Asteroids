using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/asteroids")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AsteroidsController(IConfiguration config)
        {
            _config = config;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Asteroids>> GetAsteroids([FromQuery, BindRequired] string planet)
        {
            if (String.IsNullOrEmpty(HttpContext.Request.Query["planet"]))
            {
                return BadRequest("Invalid planet request");
            }

            planet = HttpContext.Request.Query["planet"];

            // DATES
            DateTime Today = DateTime.Today;
            DateTime Next7 = Today.AddDays(7);

            // URL
            string Url = _config.GetValue<string>("API:Url");
            string Key = _config.GetValue<string>("API:Key");
            Url = Url + "?start_date=" + Today.ToString("yyyy-MM-dd") +  "&end_date=" + Next7.ToString("yyyy-MM-dd") + "&api_key=" + Key;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject json = JObject.Parse(result);
                    Neo data = JsonConvert.DeserializeObject<Neo>(result);
                    List<Asteroids> list = new List<Asteroids>();

                    foreach (var item in data.NearEarthObjects) 
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

                    // LIST ASTEROIDS
                    List<Asteroids> sizes = list.OrderByDescending(o => o.Diameter).Take(3).ToList();
                    
                    return Ok(sizes);

                }
            }
            catch (Exception)
            {
                return Ok("error");
            }
        }
    }
}
