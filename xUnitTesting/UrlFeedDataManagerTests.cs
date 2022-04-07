using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Interfaces;
using WebAPI.Classes;
using WebAPI.Models.Helpers;
using Microsoft.Extensions.Configuration;
using Xunit;
using System.IO;

namespace xUnitTesting
{
    public class UrlFeedDataManagerTests
    {
        private IApiUrl _apiUrl;

        

        [Fact(DisplayName = "Should return Url")]
        public void ShouldReturnUrl()
        {   
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _apiUrl = new UrlFeedDataManager(configuration);

            List<Parameters> param = new List<Parameters>
            {
                new Parameters() { Key = "start_date", Value = "2020-09-09" },
                new Parameters() { Key = "end_date", Value = "2020-09-16" }
            };

            // Act
            string url = _apiUrl.GetUrl("APINeoFeed", param);
            // Assert
            string expectedUrl = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

            Assert.Equal(expectedUrl, url);
        }

        [Fact(DisplayName = "Should return Error: No Api name in config")]
        public void ShouldReturnUrlError()
        {
            string expectedApiKeyInConfig = "APINeoFeed";
            string apiKeyInConfig = "NoExistKey";

            Assert.NotEqual(expectedApiKeyInConfig, apiKeyInConfig);
        }

    }
}
