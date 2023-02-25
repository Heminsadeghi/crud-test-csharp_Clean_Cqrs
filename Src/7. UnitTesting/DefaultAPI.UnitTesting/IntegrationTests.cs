using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DefaultAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DefaultAPI.UnitTesting
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<DefaultCQRSAPI.Startup>>
    {
        private readonly HttpClient httpClient;

        public IntegrationTests(WebApplicationFactory<DefaultCQRSAPI.Startup> factory)
        {
            httpClient = factory.CreateClient();
        }


        [Fact]
        public async Task CustomerQueryAll()
        {
            // Act
            var response = await httpClient.GetAsync("api/Customer/CustomerQueryAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var terms = JsonSerializer.Deserialize<List<Customer>>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //Assert
            Assert.Equal(3, terms.Count);
           
        }



        [Fact]
        public async Task GetById()
        {
            // Act
            var response = await httpClient.GetAsync("api/Customer/CustomerQueryId?id=2");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var terms = JsonSerializer.Deserialize<Customer>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //Assert
            Assert.Equal(1, terms.Id);
                       
        }




    }
}
