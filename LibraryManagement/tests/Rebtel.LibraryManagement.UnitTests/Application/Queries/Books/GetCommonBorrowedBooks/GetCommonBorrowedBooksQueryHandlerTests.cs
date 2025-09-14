using Rebtel.LibraryManagement.UnitTests.Helpers;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Books.GetCommonBorrowedBooks;

public class GetCommonBorrowedBooksQueryHandlerTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly GetCommonBorrowedBooksQueryHandler _handler;

    public GetCommonBorrowedBooksQueryHandlerTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _mockMapper = new Mock<IMapper>();
        _handler = new GetCommonBorrowedBooksQueryHandler(_mockBookRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnMappedBookDTOs_WhenCommonBooksExist()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var count = 3;
        var query = new GetCommonBorrowedBooksQuery(bookId, count);
        var books = TestDataHelper.GetSampleBooks();
        var expectedBookDTOs = TestDataHelper.GetSampleBookDTOs();
        var cancellationToken = CancellationToken.None;

        _mockBookRepository
            .Setup(x => x.GetCommonBorrowedBooks(bookId, count, cancellationToken))
            .ReturnsAsync(books);

        _mockMapper
            .Setup(x => x.Map<IEnumerable<BookDTO>>(books))
            .Returns(expectedBookDTOs);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedBookDTOs);
        _mockBookRepository.Verify(x => x.GetCommonBorrowedBooks(bookId, count, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmptyCollection_WhenNoCommonBooksExist()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var count = 5;
        var query = new GetCommonBorrowedBooksQuery(bookId, count);
        var emptyBooks = new List<Book>();
        var emptyBookDTOs = new List<BookDTO>();
        var cancellationToken = CancellationToken.None;

        _mockBookRepository
            .Setup(x => x.GetCommonBorrowedBooks(bookId, count, cancellationToken))
            .ReturnsAsync(emptyBooks);

        _mockMapper
            .Setup(x => x.Map<IEnumerable<BookDTO>>(emptyBooks))
            .Returns(emptyBookDTOs);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        _mockBookRepository.Verify(x => x.GetCommonBorrowedBooks(bookId, count, cancellationToken), Times.Once);
    }
}
