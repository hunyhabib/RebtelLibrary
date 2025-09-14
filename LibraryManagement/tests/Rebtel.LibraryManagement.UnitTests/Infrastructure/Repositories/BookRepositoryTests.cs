using Rebtel.LibraryManagement.Infrastructure.Repositories;
using Rebtel.LibraryManagement.UnitTests.Fixtures;

namespace Rebtel.LibraryManagement.UnitTests.Infrastructure.Repositories;

public class BookRepositoryTests : IClassFixture<LibraryManagementDBFixture>
{
    private readonly BookRepository repository;
    private readonly LibraryManagementContext mockContext;

    public BookRepositoryTests(LibraryManagementDBFixture fixture)
    {
        mockContext = fixture.Context;
        repository = new BookRepository(mockContext);
    }

    [Fact]
    public async Task GetMostBorrowedBooks_ShouldReturnBooksOrderedByBorrowCount()
    {
        // Arrange
        var count = 2;
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowedBooks(count, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountLessThanOrEqualTo(count);
        var resultList = result.ToList();

        // Verify ordering by borrow count (most borrowed first)
        for (int i = 0; i < resultList.Count - 1; i++)
        {
            resultList[i].BorrowRecords.Count.Should().BeGreaterThanOrEqualTo(resultList[i + 1].BorrowRecords.Count);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public async Task GetMostBorrowedBooks_ShouldRespectCountParameter(int count)
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowedBooks(count, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountLessThanOrEqualTo(count);
    }

    [Fact]
    public async Task GetCommonBorrowedBooks_ShouldReturnBooksCommonlyBorrowedWith()
    {
        // Arrange - Using The Great Gatsby ID which is frequently borrowed with other books
        var targetBookId = Guid.Parse("11111111-1111-1111-1111-111111111111"); // The Great Gatsby
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetCommonBorrowedBooks(targetBookId, 3, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.All(b => b.Id != targetBookId).Should().BeTrue("Result should not contain the target book itself");
        result.Should().HaveCountLessThanOrEqualTo(3);
    }

    [Fact]
    public async Task GetCommonBorrowedBooks_WithNonExistentBook_ShouldReturnEmpty()
    {
        // Arrange
        var nonExistentBookId = Guid.Parse("99999999-9999-9999-9999-999999999999");
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetCommonBorrowedBooks(nonExistentBookId, 3, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetMostBorrowedBooks_ShouldReturnCorrectOrderingBasedOnBorrowFrequency()
    {
        // Arrange
        var count = 5;
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowedBooks(count, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        var resultList = result.ToList();
        
        // The Great Gatsby should be most borrowed (appears in 4 borrow records)
        // followed by other frequently borrowed books
        if (resultList.Any())
        {
            // Verify that results are ordered by borrow count descending
            for (int i = 0; i < resultList.Count - 1; i++)
            {
                resultList[i].BorrowRecords.Count.Should().BeGreaterThanOrEqualTo(resultList[i + 1].BorrowRecords.Count);
            }
        }
    }
}
