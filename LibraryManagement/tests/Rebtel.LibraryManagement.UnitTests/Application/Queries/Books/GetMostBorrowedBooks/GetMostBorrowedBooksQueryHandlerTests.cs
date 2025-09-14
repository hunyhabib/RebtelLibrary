using Rebtel.LibraryManagement.UnitTests.Helpers;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Books.GetMostBorrowedBooks
{
    public class GetMostBorrowedBooksQueryHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetMostBorrowedBooksQueryHandler _handler;

        public GetMostBorrowedBooksQueryHandlerTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetMostBorrowedBooksQueryHandler(_mockBookRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnMappedBookDTOs_WhenBooksExist()
        {
            // Arrange
            var query = new GetMostBorrowedBooksQuery(3);
            var books = TestDataHelper.GetSampleBooks();
            var expectedBookDTOs = TestDataHelper.GetSampleBookDTOs();
            var cancellationToken = CancellationToken.None;

            _mockBookRepository
                .Setup(x => x.GetMostBorrowedBooks(query.Count, cancellationToken))
                .ReturnsAsync(books);

            _mockMapper
                .Setup(x => x.Map<IEnumerable<BookDTO>>(books))
                .Returns(expectedBookDTOs);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedBookDTOs);
            _mockBookRepository.Verify(x => x.GetMostBorrowedBooks(query.Count, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyCollection_WhenNoBooksExist()
        {
            // Arrange
            var query = new GetMostBorrowedBooksQuery(5);
            var emptyBooks = new List<Book>();
            var emptyBookDTOs = new List<BookDTO>();
            var cancellationToken = CancellationToken.None;

            _mockBookRepository
                .Setup(x => x.GetMostBorrowedBooks(query.Count, cancellationToken))
                .ReturnsAsync(emptyBooks);

            _mockMapper
                .Setup(x => x.Map<IEnumerable<BookDTO>>(emptyBooks))
                .Returns(emptyBookDTOs);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
            _mockBookRepository.Verify(x => x.GetMostBorrowedBooks(query.Count, cancellationToken), Times.Once);
        }
    }
}
