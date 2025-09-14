using Rebtel.LibraryManagement.UnitTests.Helpers;

namespace Rebtel.LibraryManagement.UnitTests.Application.Queries.Users.GetMostBorrowingUser
{
    public class GetMostBorrowingUserQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetMostBorrowingUserQueryHandler _handler;

        public GetMostBorrowingUserQueryHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetMostBorrowingUserQueryHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnMappedUserDTOs_WhenUsersExist()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now;
            var count = 2;
            var query = new GetMostBorrowingUserQuery(startDate, endDate, count);
            var users = TestDataHelper.GetSampleUsers();
            var expectedUserDTOs = TestDataHelper.GetSampleUserDTOs();
            var cancellationToken = CancellationToken.None;

            _mockUserRepository
                .Setup(x => x.GetMostBorrowingUser(startDate, endDate, count, cancellationToken))
                .ReturnsAsync(users);

            _mockMapper
                .Setup(x => x.Map<IEnumerable<UserDTO>>(users))
                .Returns(expectedUserDTOs);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedUserDTOs);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyCollection_WhenNoUsersExist()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now;
            var count = 5;
            var query = new GetMostBorrowingUserQuery(startDate, endDate, count);
            var emptyUsers = new List<User>();
            var emptyUserDTOs = new List<UserDTO>();
            var cancellationToken = CancellationToken.None;

            _mockUserRepository
                .Setup(x => x.GetMostBorrowingUser(startDate, endDate, count, cancellationToken))
                .ReturnsAsync(emptyUsers);

            _mockMapper
                .Setup(x => x.Map<IEnumerable<UserDTO>>(emptyUsers))
                .Returns(emptyUserDTOs);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
