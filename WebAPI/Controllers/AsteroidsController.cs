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
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Helpers;
using WebAPI.Classes;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/asteroids")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IApiUrl _apiUrl;
        private readonly IApiNeoFeedData _neoData;
        private readonly ISearchHazardousAsteroids _searchHazardous;
        private readonly IHelpers _helpers;

        public AsteroidsController(IConfiguration config, IApiUrl apiUrl, IApiNeoFeedData neoData, ISearchHazardousAsteroids searchHazardous,
                                   IHelpers helpers)
        {
            _config = config;
            _apiUrl = apiUrl;
            _neoData = neoData;
            _searchHazardous = searchHazardous;
            _helpers = helpers;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Asteroids>> GetAsteroids([FromQuery, BindRequired] string planet, [FromQuery] int days)
        {
            if (String.IsNullOrEmpty(planet))
            {
                return BadRequest("Planet is required");
            }

            int Days = int.Parse(_config.GetValue<string>("APINeoFeed:Days"));
            if (!String.IsNullOrEmpty(days.ToString()))
            {
                if (days > 7)
                {
                    return BadRequest("Max days 7");
                } else
                {
                    Days = days;
                }
                
            }
            
            Dates dates = _helpers.GetDatesFromToday(Days);

            List<Parameters> param = new List<Parameters>
            {
                new Parameters() { Key = "start_date", Value = dates.StartDate.ToString("yyyy-MM-dd") },
                new Parameters() { Key = "end_date", Value = dates.EndDate.ToString("yyyy-MM-dd") }
            };

            string Url = _apiUrl.GetUrl("APINeoFeed", param);

            try
            {
                Neo data = _neoData.GetNeoFeedData(Url);
                List<Asteroids> list = _searchHazardous.GetHazardousAsteroids(data.NearEarthObjects, planet);
                List<Asteroids> asteroids = _searchHazardous.GetTopHazardousAsteroidsDiameter(list, 3);

                return Ok(asteroids);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
          
        }
    }
}
