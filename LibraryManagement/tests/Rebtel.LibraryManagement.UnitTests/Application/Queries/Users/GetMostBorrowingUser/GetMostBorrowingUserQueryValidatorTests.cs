using FluentValidation.TestHelper;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Users.GetMostBorrowingUser
{
    public class GetMostBorrowingUserQueryValidatorTests
    {
        private readonly GetMostBorrowingUserQueryValidation _validator;

        public GetMostBorrowingUserQueryValidatorTests()
        {
            _validator = new GetMostBorrowingUserQueryValidation();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void Should_Not_Have_Validation_Error_When_Count_Is_Greater_Than_Zero(int count)
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now;
            var query = new GetMostBorrowingUserQuery(startDate, endDate, count);

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
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now;
            var query = new GetMostBorrowingUserQuery(startDate, endDate, count);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Count);
        }

        [Fact]
        public void Should_Have_Validation_Error_When_StartDate_Is_After_EndDate()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(-30);
            var query = new GetMostBorrowingUserQuery(startDate, endDate, 5);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void Should_Not_Have_Validation_Error_When_StartDate_Is_Before_EndDate()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now;
            var query = new GetMostBorrowingUserQuery(startDate, endDate, 5);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void Should_Have_Validation_Error_When_StartDate_Equals_EndDate()
        {
            // Arrange
            var date = DateTime.Now;
            var query = new GetMostBorrowingUserQuery(date, date, 5);

            // Act & Assert
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }
    }
}
