using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Rebtel.LibraryManagement.Contracts;
using Rebtel.LibraryManagement.IntegrationTests.Fixtures;

namespace Rebtel.LibraryManagement.IntegrationTests
{
    public class UsersIntegrationTests : IClassFixture<LibraryManagementWebAppFixture>
    {
        private readonly UsersService.UsersServiceClient usersServiceClient;

        public UsersIntegrationTests(LibraryManagementWebAppFixture factory)
        {
            GrpcChannelOptions options = new() { HttpHandler = factory.Server.CreateHandler() };
            GrpcChannel channel = GrpcChannel.ForAddress(factory.Server.BaseAddress, options);
            usersServiceClient = new(channel);
        }

        [Fact]
        public async Task GetMostBorrowingUsers_WithTimePeriod_ShouldReturnUsersWithMostBorrows()
        {
            var request = new GetMostBorrowingUsersRequest
            {
                StartTime = Timestamp.FromDateTime(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                EndTime = Timestamp.FromDateTime(new DateTime(2025, 12, 31, 23, 59, 59, DateTimeKind.Utc)),
                Count = 3
            };

            // Act
            var response = await usersServiceClient.GetMostBorrowingUsersAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Users.Should().NotBeEmpty();
            response.Users.Count.Should().BeLessThanOrEqualTo(3);

           
            response.Users[0].Id.Should().Be("22222222-2222-2222-2222-222222222221");
            response.Users[1].Id.Should().Be("22222222-2222-2222-2222-222222222222"); 
            response.Users[2].Id.Should().Be("22222222-2222-2222-2222-222222222223");
        }

        [Fact]
        public async Task GetMostBorrowingUsers_FutureDateRange_ShouldReturnEmptyResult()
        {
            // Arrange
            var request = new GetMostBorrowingUsersRequest
            {
                StartTime = Timestamp.FromDateTime(new DateTime(2030, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                EndTime = Timestamp.FromDateTime(new DateTime(2030, 12, 31, 23, 59, 59, DateTimeKind.Utc)),
                Count = 5
            };

            // Act
            var response = await usersServiceClient.GetMostBorrowingUsersAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Users.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserReadingPace_WithValidUserId_ShouldReturnReadingPace()
        {
            var request = new GetUserReadingPaceRequest
            {
                UserId = "22222222-2222-2222-2222-222222222221", 
                BookId = "11111111-1111-1111-1111-111111111133"
            };

            // Act
            var response = await usersServiceClient.GetUserReadingPaceAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Pace.Should().BeGreaterThanOrEqualTo(0);

            response.Pace.Should().Be(13);
        }
    }
}
