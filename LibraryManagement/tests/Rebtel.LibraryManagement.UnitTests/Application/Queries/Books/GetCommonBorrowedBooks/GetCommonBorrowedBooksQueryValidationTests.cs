using FluentValidation.TestHelper;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Books.GetCommonBorrowedBooks
{
    public class GetCommonBorrowedBooksQueryValidationTests
    {
        private readonly GetCommonBorrowedBooksQueryValidation _validator;

        public GetCommonBorrowedBooksQueryValidationTests()
        {
            _validator = new GetCommonBorrowedBooksQueryValidation();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void Should_Not_Have_Validation_Error_When_Count_Is_Greater_Than_Zero(int count)
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var query = new GetCommonBorrowedBooksQuery(bookId, count);

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
            var bookId = Guid.NewGuid();
            var query = new GetCommonBorrowedBooksQuery(bookId, count);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Count);
        }

        [Fact]
        public void Should_Have_Validation_Error_When_BookId_Is_Empty()
        {
            // Arrange
            var query = new GetCommonBorrowedBooksQuery(Guid.Empty, 5);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.BookId);
        }

        [Fact]
        public void Should_Not_Have_Validation_Error_When_BookId_Is_Valid()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var query = new GetCommonBorrowedBooksQuery(bookId, 5);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldNotHaveValidationErrorFor(x => x.BookId);
        }
    }
}
