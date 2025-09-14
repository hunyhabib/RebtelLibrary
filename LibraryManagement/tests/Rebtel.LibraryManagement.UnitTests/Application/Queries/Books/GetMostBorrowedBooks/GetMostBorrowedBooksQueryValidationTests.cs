using FluentValidation.TestHelper;
using Rebtel.LibraryManagement.UnitTests.Helpers;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Books.GetMostBorrowedBooks
{
    public class GetMostBorrowedBooksQueryValidationTests
    {
        private readonly GetMostBorrowedBooksQueryValidation _validator;

        public GetMostBorrowedBooksQueryValidationTests()
        {
            _validator = new GetMostBorrowedBooksQueryValidation();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void Should_Not_Have_Validation_Error_When_Count_Is_Greater_Than_Zero(int count)
        {
            // Arrange
            var query = new GetMostBorrowedBooksQuery(count);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldNotHaveValidationErrorFor(x => x.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Have_Validation_Error_When_Count_Is_Zero_Or_Negative(int count)
        {
            // Arrange
            var query = new GetMostBorrowedBooksQuery(count);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Count);
        }
    }
}
