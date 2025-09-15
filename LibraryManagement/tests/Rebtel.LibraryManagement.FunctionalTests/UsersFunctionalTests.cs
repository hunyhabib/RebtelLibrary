using System.Net;
using Rebtel.LibraryManagement.FunctionalTests.Fixtures;

namespace Rebtel.LibraryManagement.FunctionalTests;

public class UsersFunctionalTests : IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ApiWebApplicationFactory _factory;

    public UsersFunctionalTests(ApiWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMostBorrowingUsers_WithValidDateRange_ShouldReturnSuccessAndUsers()
    {
        // Arrange
        var startTime = "2024-01-01T00:00:00Z";
        var endTime = "2024-12-31T23:59:59Z";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/mostborrowing?startTime={startTime}&endTime={endTime}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        
        var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content);
        users.Should().NotBeNull();
        users.Should().HaveCountLessThanOrEqualTo(3); // Default count is 3
        
        // Verify user structure
        var firstUser = users.FirstOrDefault();
        if (firstUser != null)
        {
            firstUser.Id.Should().NotBeEmpty();
            firstUser.Name.Should().NotBeNullOrEmpty();
            firstUser.Email.Should().NotBeNullOrEmpty();
        }
    }

    [Theory]
    [InlineData("2024-01-01T00:00:00Z", "2024-12-31T23:59:59Z", 1)]
    [InlineData("2024-01-01T00:00:00Z", "2024-12-31T23:59:59Z", 2)]
    [InlineData("2024-01-01T00:00:00Z", "2024-12-31T23:59:59Z", 5)]
    public async Task GetMostBorrowingUsers_WithCustomCount_ShouldReturnCorrectNumberOfUsers(string startTime, string endTime, int count)
    {
        // Act
        var response = await _client.GetAsync($"/api/v1/users/mostborrowing?startTime={startTime}&endTime={endTime}&count={count}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content);
        
        users.Should().NotBeNull();
        users.Should().HaveCountLessThanOrEqualTo(count);
    }

    [Fact]
    public async Task GetMostBorrowingUsers_WithFutureDateRange_ShouldReturnEmptyOrNoUsers()
    {
        // Arrange
        var startTime = "2030-01-01T00:00:00Z";
        var endTime = "2030-12-31T23:59:59Z";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/mostborrowing?startTime={startTime}&endTime={endTime}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content);
        
        users.Should().NotBeNull();
        // Future dates should return empty results
        users.Should().BeEmpty();
    }


    [Fact]
    public async Task GetUserReadingPace_WithValidUserAndBookId_ShouldReturnSuccessAndPace()
    {
        // Arrange - Use known IDs from seed data
        var userId = "22222222-2222-2222-2222-222222222221";
        var bookId = "11111111-1111-1111-1111-111111111123";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/{userId}/readingpace?bookId={bookId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        
        var result = JsonConvert.DeserializeAnonymousType(content, new { Pace = 0.0 });
        result.Should().NotBeNull();
        result.Pace.Should().Be(9);
    }

    [Fact]
    public async Task GetUserReadingPace_WithMissingUserId_ShouldReturnBadRequest()
    {
        // Arrange
        var bookId = "11111111-1111-1111-1111-111111111123";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/invalid-guid/readingpace?bookId={bookId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetUserReadingPace_WithNonExistentUser_ShouldReturnNotFoundOrZeroPace()
    {
        // Arrange
        var nonExistentUserId = Guid.NewGuid();
        var bookId = "11111111-1111-1111-1111-111111111123";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/{nonExistentUserId}/readingpace?bookId={bookId}");

        // Assert
        // The response might be OK with zero pace or NotFound depending on business logic
        response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NotFound);
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(content, new { Pace = 0.0 });
            result.Pace.Should().Be(0);
        }
    }

    [Fact]
    public async Task GetUserReadingPace_WithMissingBookIdParameter_ShouldReturnBadRequest()
    {
        // Arrange
        var userId = "22222222-2222-2222-2222-222222222221";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/{userId}/readingpace");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UsersEndpoints_ShouldHaveCorrectApiVersioning()
    {
        // Arrange
        var startTime = "2024-01-01T00:00:00Z";
        var endTime = "2024-12-31T23:59:59Z";

        // Test that v1 endpoints work
        var v1Response = await _client.GetAsync($"/api/v1/users/mostborrowing?startTime={startTime}&endTime={endTime}");
        v1Response.StatusCode.Should().Be(HttpStatusCode.OK);

        // Test that invalid version returns not found or bad request
        var invalidVersionResponse = await _client.GetAsync($"/api/v2/users/mostborrowing?startTime={startTime}&endTime={endTime}");
        invalidVersionResponse.StatusCode.Should().BeOneOf(HttpStatusCode.NotFound, HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UsersEndpoints_ShouldReturnJsonContentType()
    {
        // Arrange
        var startTime = "2024-01-01T00:00:00Z";
        var endTime = "2024-12-31T23:59:59Z";

        // Act
        var response = await _client.GetAsync($"/api/v1/users/mostborrowing?startTime={startTime}&endTime={endTime}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }
}
