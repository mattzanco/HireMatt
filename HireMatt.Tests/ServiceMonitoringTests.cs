using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HireMatt.Tests
{
    public class ServiceMonitoringTests
    {
        [Fact]
        public async Task PingEndpoint_ReturnsTrue()
        {
            // Arrange
            var application = new WebApplicationFactory<HireMatt.Api.Program>();
            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/ping");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("true", result);
        }
    }
}