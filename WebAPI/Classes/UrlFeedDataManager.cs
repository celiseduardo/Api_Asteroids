using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models.Helpers;

namespace WebAPI.Classes
{
    public class UrlFeedDataManager : IApiUrl
    {
        private readonly IConfiguration _config;

        public UrlFeedDataManager(IConfiguration config)
        {
            _config = config;
        }
        public string GetUrl(string ConfigKetApi, List<Parameters> param, bool key)
        {
            List<string> paramValues = new List<string>();
            foreach (var p in param)
            {
                paramValues.Add(p.Key + "=" + p.Value);
            }

            try
            {
                string Url = _config.GetValue<string>(ConfigKetApi + ":Url");
                Url = Url + "?" + String.Join("&", paramValues);
                if (key)
                {
                    string Key = _config.GetValue<string>(ConfigKetApi + ":Key");
                    Url += "&api_key=" + Key;
                }

                return Url;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting url: " + ex.Message.ToString());
            }
            
        }
    }
}
