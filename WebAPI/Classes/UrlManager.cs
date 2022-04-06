using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models.Helpers;

namespace WebAPI.Classes
{
    public class UrlManager : IApiUrl
    {
        private readonly IConfiguration _config;

        public UrlManager(IConfiguration config)
        {
            _config = config;
        }
        public string GetUrl(string api, List<Parameters> param, bool key)
        {
            List<string> paramValues = new List<string>(); ;
            foreach (var p in param)
            {
                paramValues.Add(p.Key + "=" + p.Value);
            }

            
            string Url = _config.GetValue<string>(api + ":Url");
            Url = Url + "?" + String.Join("&", paramValues);
            if (key)
            {
                string Key = _config.GetValue<string>(api + ":Key");
                Url += "&api_key=" + Key;
            }

            return Url;
        }
    }
}
