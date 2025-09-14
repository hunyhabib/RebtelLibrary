using Rebtel.LibraryManagement.Infrastructure.Repositories;
using Rebtel.LibraryManagement.UnitTests.Fixtures;

namespace Rebtel.LibraryManagement.UnitTests.Infrastructure.Repositories;

public class UserRepositoryTests : IClassFixture<LibraryManagementDBFixture>
{
    private readonly UserRepository repository;
    private readonly LibraryManagementContext mockContext;

    public UserRepositoryTests(LibraryManagementDBFixture fixture)
    {
        mockContext = fixture.Context;
        repository = new UserRepository(mockContext);
    }

    [Fact]
    public async Task GetMostBorrowingUser_ShouldReturnUsersOrderedByBorrowCount()
    {
        // Arrange
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 12, 31);
        var usersCount = 3;
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowingUser(startDate, endDate, usersCount, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountLessThanOrEqualTo(usersCount);
        var resultList = result.ToList();

        // Verify ordering by borrow count (most borrowing first)
        for (int i = 0; i < resultList.Count - 1; i++)
        {
            var currentUserBorrowCount = resultList[i].BorrowRecords.Count(l => l.BorrowDate >= startDate && l.ReturnDate <= endDate);
            var nextUserBorrowCount = resultList[i + 1].BorrowRecords.Count(l => l.BorrowDate >= startDate && l.ReturnDate <= endDate);
            currentUserBorrowCount.Should().BeGreaterThanOrEqualTo(nextUserBorrowCount);
        }
    }

    [Theory]
    [InlineData(1)]
    public async Task GetMostBorrowingUser_ShouldRespectUsersCountParameter(int usersCount)
    {
        // Arrange
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 12, 31);
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowingUser(startDate, endDate, usersCount, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountLessThanOrEqualTo(usersCount);
    }

    [Fact]
    public async Task GetMostBorrowingUser_AllTime_ShouldReturnUsersWithMostTotalBorrows()
    {
        // Arrange - Full date range to check users with multiple borrows across years
        var startDate = new DateTime(2025, 1, 1);
        var endDate = new DateTime(2025, 12, 31);
        var usersCount = 1;
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetMostBorrowingUser(startDate, endDate, usersCount, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        var resultList = result.ToList();

        resultList.Should().HaveCount(1);


        resultList[0].Id.Should().Be(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));
    }


    [Theory]
    [InlineData("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", "11111111-1111-1111-1111-111111111111",6)]
    [InlineData("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "11111111-1111-1111-1111-111111111111",7)]
    public async Task GetUserReadingPace_ShouldCalculateCorrectPace_ForSpecificUserAndBook(string userId, string bookId,int pace)
    {
        var user = Guid.Parse(userId);
        var book = Guid.Parse(bookId);
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetUserReadingPace(user, book, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(pace);
    }

    [Fact]
    public async Task GetUserReadingPace_UserWithActiveBorrows_ShouldExcludeUnreturnedBooks()
    {
        var user = Guid.Parse("22222222-2222-2222-2222-222222222231");
        var book = Guid.Parse("11111111-1111-1111-1111-111111111132");
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetUserReadingPace(user, book, cancellationToken);

        // Assert 
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task GetUserReadingPace_NonExistentUser_ShouldReturnNull()
    {
        var user = Guid.NewGuid(); // Non-existent user
        var book = Guid.Parse("11111111-1111-1111-1111-111111111123");
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetUserReadingPace(user, book, cancellationToken);

        // Assert
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task GetUserReadingPace_NonExistentBook_ShouldReturnNull()
    {
        var user = Guid.Parse("22222222-2222-2222-2222-222222222221");
        var book = Guid.NewGuid(); // Non-existent book
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await repository.GetUserReadingPace(user, book, cancellationToken);

        // Assert
        result.Should().BeNull();
    }
}
