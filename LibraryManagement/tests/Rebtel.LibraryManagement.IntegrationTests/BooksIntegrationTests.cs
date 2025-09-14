using Grpc.Net.Client;
using Rebtel.LibraryManagement.Contracts;
using Rebtel.LibraryManagement.IntegrationTests.Fixtures;

namespace Rebtel.LibraryManagement.IntegrationTests
{
    public class BooksIntegrationTests : IClassFixture<LibraryManagementWebAppFixture>
    {
        private readonly BooksService.BooksServiceClient booksServiceClient;

        public BooksIntegrationTests(LibraryManagementWebAppFixture factory)
        {
            GrpcChannelOptions options = new() { HttpHandler = factory.Server.CreateHandler() };
            GrpcChannel channel = GrpcChannel.ForAddress(factory.Server.BaseAddress, options);
            booksServiceClient = new(channel);
        }

        [Fact]
        public async Task GetMostBorrowedBooks_WithValidRequest_ShouldReturnBooks()
        {
            // Arrange
            var request = new GetMostBorrowedBooksRequest
            {
                Count = 2
            };

            // Act
            var response = await booksServiceClient.GetMostBorrowedBooksAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Books.Should().NotBeNull();
            response.Books.Count.Should().BeGreaterThan(0);
            response.Books.Count.Should().BeLessThanOrEqualTo(2);

            // Verify book properties are populated
            var firstBook = response.Books.First();
            firstBook.Id.Should().Be("11111111-1111-1111-1111-111111111131");

        }

        [Theory]
        [InlineData("11111111-1111-1111-1111-111111111123", "11111111-1111-1111-1111-111111111127")]
        public async Task GetCommonBorrowedBooks_WithDifferentBooks_ShouldReturnRelevantResults(string bookId, string resultId)
        {
            // Arrange
            var request = new GetCommonBorrowedBooksRequest
            {
                BookId = bookId,
                Count = 1
            };

            // Act
            var response = await booksServiceClient.GetCommonBorrowedBooksAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Books.Should().NotBeNull();
            response.Books[0].Id.Should().Be(resultId); 

        }
    }
}
