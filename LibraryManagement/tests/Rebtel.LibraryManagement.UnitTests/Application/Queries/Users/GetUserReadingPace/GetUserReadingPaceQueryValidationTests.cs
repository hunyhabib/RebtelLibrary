using FluentValidation.TestHelper;
using Rebtel.LibraryManagement.Application.Queries.Users.GetUserReadingPace;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Users.GetUserReadingPace;

public class GetUserReadingPaceQueryValidationTests
{
    private readonly GetUserReadingPaceQueryValidation _validator;

    public GetUserReadingPaceQueryValidationTests()
    {
        _validator = new GetUserReadingPaceQueryValidation();
    }

    [Fact]
    public void Should_Have_Validation_Error_When_UserId_Is_Empty()
    {
        // Arrange
        var query = new GetUserReadingPaceQuery(Guid.Empty, Guid.NewGuid());

        // Act & Assert
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.UserId);
    }

    [Fact]
    public void Should_Have_Validation_Error_When_BookId_Is_Empty()
    {
        // Arrange
        var query = new GetUserReadingPaceQuery(Guid.NewGuid(), Guid.Empty);

        // Act & Assert
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.BookId);
    }

    [Fact]
    public void Should_Not_Have_Validation_Error_When_Both_Ids_Are_Valid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var bookId = Guid.NewGuid();
        var query = new GetUserReadingPaceQuery(userId, bookId);

        // Act & Assert
        var result = _validator.TestValidate(query);
        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.BookId);
    }
}
