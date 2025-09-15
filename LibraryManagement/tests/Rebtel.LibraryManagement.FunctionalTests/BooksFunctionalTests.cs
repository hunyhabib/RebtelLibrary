using Microsoft.AspNetCore.Mvc;
using Rebtel.LibraryManagement.FunctionalTests.Fixtures;
using System.Net;

namespace Rebtel.LibraryManagement.FunctionalTests;

public class BooksFunctionalTests : IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ApiWebApplicationFactory _factory;

    public BooksFunctionalTests(ApiWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMostBorrowedBooks_WithDefaultCount_ShouldReturnSuccessAndBooks()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/books/mostborrowed");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        
        var books = JsonConvert.DeserializeObject<IEnumerable<BookDTO>>(content);
        books.Should().NotBeNull();
        books.Should().HaveCountLessThanOrEqualTo(3); // Default count is 3
        
        // Verify book structure
        var firstBook = books.FirstOrDefault();
        if (firstBook != null)
        {
            firstBook.Id.Should().NotBeEmpty();
            firstBook.Title.Should().NotBeNullOrEmpty();
            firstBook.Author.Should().NotBeNullOrEmpty();
        }
    }

    [Theory]
    [InlineData(1)]
    public async Task GetMostBorrowedBooks_WithCustomCount_ShouldReturnCorrectNumberOfBooks(int count)
    {
        // Act
        var response = await _client.GetAsync($"/api/v1/books/mostborrowed?count={count}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<IEnumerable<BookDTO>>(content);
        
        books.Should().NotBeNull();
        books.Should().HaveCountLessThanOrEqualTo(count);
    }


    [Theory]
    [InlineData("11111111-1111-1111-1111-111111111123", 1)]
    [InlineData("11111111-1111-1111-1111-111111111124", 2)]
    public async Task GetCommonBorrowedBooks_WithValidBookIdAndCount_ShouldReturnCorrectNumberOfBooks(string bookId, int count)
    {
        // Act
        var response = await _client.GetAsync($"/api/v1/books/{bookId}/commonborrowed?count={count}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<IEnumerable<BookDTO>>(content);
        
        books.Should().NotBeNull();
        books.Should().HaveCountLessThanOrEqualTo(count);
    }

    [Fact]
    public async Task GetCommonBorrowedBooks_WithNonExistentBookId_ShouldReturnNotFoundOrEmptyResult()
    {
        var nonExistentBookId = Guid.NewGuid();
        
        // Act
        var response = await _client.GetAsync($"/api/v1/books/{nonExistentBookId}/commonborrowed");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<IEnumerable<BookDTO>>(content);
        books.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostBorrowedBooks_WithInvalidCount_ShouldReturnBadRequest()
    {
        // Act - Using a negative count should trigger validation error
        var response = await _client.GetAsync("/api/v1/books/mostborrowed?count=-1");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }


 
}
