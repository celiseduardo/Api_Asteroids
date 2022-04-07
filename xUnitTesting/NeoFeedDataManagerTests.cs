using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Interfaces;
using WebAPI.Classes;
using System.Net.Http;
using WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;
using System.Net;
using System.Threading.Tasks;

namespace xUnitTesting
{
    public class NeoFeedDataManagerTests
    {
        private IApiNeoFeedData _neoData;
        private HttpClient _httpClient;
        private string _url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

        public NeoFeedDataManagerTests()
        {
            _neoData = Mock.Of<IApiNeoFeedData>();
            _httpClient = new HttpClient();
        }


        [Theory(DisplayName = "Http request to Url api feed OK")]
        [InlineData("GET")]
        public async Task GetNeoData(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), _url);

            //Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
