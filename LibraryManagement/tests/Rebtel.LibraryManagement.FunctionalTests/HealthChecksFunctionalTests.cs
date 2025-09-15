using System.Net;
using Rebtel.LibraryManagement.FunctionalTests.Fixtures;

namespace Rebtel.LibraryManagement.FunctionalTests;

public class HealthChecksFunctionalTests : IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;

    public HealthChecksFunctionalTests(ApiWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthEndpoint_ShouldReturnHealthy()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Fact]
    public async Task ReadyEndpoint_ShouldReturnHealthy()
    {
        // Act
        var response = await _client.GetAsync("/ready");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Fact]
    public async Task StartupEndpoint_ShouldReturnHealthy()
    {
        // Act
        var response = await _client.GetAsync("/startup");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Theory]
    [InlineData("/health")]
    [InlineData("/ready")]
    [InlineData("/startup")]
    public async Task HealthCheckEndpoints_ShouldNotRequireApiVersioning(string endpoint)
    {
        // Act
        var response = await _client.GetAsync(endpoint);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
