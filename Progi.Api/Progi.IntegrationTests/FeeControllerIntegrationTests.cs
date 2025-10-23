using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Progi.Api.DTOs;

namespace Progi.IntegrationTests
{
    public class FeeControllerIntegrationTests: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public FeeControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CalculateFees_ShouldReturnExpectedResponse_ForCommonVehicle()
        {
            // Arrange
            var request = new FeeRequest(1000m, VehicleType.Common);

            // Act
            var response = await _client.PostAsJsonAsync("/api/bid/calculate", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<FeeResponse>();
            Assert.NotNull(result);

            Assert.Equal(1000m, result!.VehiclePrice);
            Assert.Equal(VehicleType.Common, result.VehicleType);
            Assert.Equal(4, result.Fees.Count());
            Assert.Equal(1180m, result.Total);
        }

        [Fact]
        public async Task CalculateFees_ShouldReturnExpectedResponse_ForLuxuryVehicle()
        {
            // Arrange
            var request = new FeeRequest(1800m, VehicleType.Luxury);

            // Act
            var response = await _client.PostAsJsonAsync("/api/bid/calculate", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<FeeResponse>();
            Assert.NotNull(result);

            Assert.Equal(VehicleType.Luxury, result!.VehicleType);
            Assert.Equal(4, result.Fees.Count());
            Assert.Equal(2167m, result.Total);
        }
    }
}
