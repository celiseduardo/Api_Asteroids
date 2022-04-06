using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Classes
{
    public class NeoFeedDataManager : IApiNeoFeedData
    {
        public Neo GetNeoFeedData(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
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
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data: " + ex.Message.ToString());
            }
        }
    }
}
