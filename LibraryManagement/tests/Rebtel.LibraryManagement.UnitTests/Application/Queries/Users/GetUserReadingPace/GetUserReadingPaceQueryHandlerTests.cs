using Rebtel.LibraryManagement.Application.Queries.Users.GetUserReadingPace;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Users.GetUserReadingPace;

public class GetUserReadingPaceQueryHandlerTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetUserReadingPaceQueryHandler _handler;

    public GetUserReadingPaceQueryHandlerTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _handler = new GetUserReadingPaceQueryHandler(_mockUserRepository.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnReadingPace_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bookId = Guid.NewGuid();
        var query = new GetUserReadingPaceQuery(userId, bookId);
        var expectedReadingPace = 25;
        var cancellationToken = CancellationToken.None;

        _mockUserRepository
            .Setup(x => x.GetUserReadingPace(userId, bookId, cancellationToken))
            .ReturnsAsync(expectedReadingPace);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Should().Be(expectedReadingPace);
        _mockUserRepository.Verify(x => x.GetUserReadingPace(userId, bookId, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bookId = Guid.NewGuid();
        var query = new GetUserReadingPaceQuery(userId, bookId);
        var cancellationToken = CancellationToken.None;

        _mockUserRepository
            .Setup(x => x.GetUserReadingPace(userId, bookId, cancellationToken))
            .ReturnsAsync((int?)null);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Should().BeNull();
        _mockUserRepository.Verify(x => x.GetUserReadingPace(userId, bookId, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithCorrectParameters()
    {
        // Arrange
        var expectedUserId = Guid.NewGuid();
        var expectedBookId = Guid.NewGuid();
        var query = new GetUserReadingPaceQuery(expectedUserId, expectedBookId);
        var cancellationToken = new CancellationToken();

        _mockUserRepository
            .Setup(x => x.GetUserReadingPace(expectedUserId, expectedBookId, cancellationToken))
            .ReturnsAsync(50);

        // Act
        await _handler.Handle(query, cancellationToken);

        // Assert
        _mockUserRepository.Verify(x => x.GetUserReadingPace(expectedUserId, expectedBookId, cancellationToken), Times.Once);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(999)]
    public async Task Handle_ShouldReturnCorrectValue_ForVariousReadingPaces(int readingPace)
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bookId = Guid.NewGuid();
        var query = new GetUserReadingPaceQuery(userId, bookId);
        var cancellationToken = CancellationToken.None;

        _mockUserRepository
            .Setup(x => x.GetUserReadingPace(userId, bookId, cancellationToken))
            .ReturnsAsync(readingPace);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Should().Be(readingPace);
    }
}
