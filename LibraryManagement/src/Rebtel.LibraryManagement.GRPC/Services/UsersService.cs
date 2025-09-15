using Grpc.Core;
using MediatR;
using Rebtel.LibraryManagement.Application.Exceptions;
using Rebtel.LibraryManagement.Contracts;

namespace Rebtel.LibraryManagement.GRPC.Services
{
    public class UsersService(ILogger<UsersService> logger, IMediator mediator) : Contracts.UsersService.UsersServiceBase
    {
        /// <summary>
        /// Gets the most borrowing users within a date range
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>A response containing the most borrowing users within the specified date range</returns>
        public override async Task<GetMostBorrowingUsersResponse> GetMostBorrowingUsers(GetMostBorrowingUsersRequest request, ServerCallContext context)
        {
            try
            {
                logger.LogInformation("GetMostBorrowingUsers called with start_time: {StartTime}, end_time: {EndTime}, count: {Count}",
                    request.StartTime, request.EndTime, request.Count);

                if (request == null)
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));


                var query = new Application.Queries.Users.GetMostBorrowingUser.GetMostBorrowingUserQuery(
                    request.StartTime.ToDateTime(), request.EndTime.ToDateTime(), request.Count);

                var result = await mediator.Send(query, context.CancellationToken);

                var response = new GetMostBorrowingUsersResponse();
                foreach (var userDto in result)
                {
                    response.Users.Add(MapUserDtoToProtoDto(userDto));
                }

                logger.LogInformation("GetMostBorrowingUsers completed successfully, returned {UserCount} users", result.Count());
                return response;
            }
            catch (ApplicationValidationException ex)
            {
                logger.LogWarning("Validation failed for GetMostBorrowingUsers: {ValidationErrors}",
                    ex.ValidationFailures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Validation failed: {string.Join(", ", ex.ValidationFailures.Select(f => f.ErrorMessage))}"));
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error in GetMostBorrowingUsers");
                throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"));
            }
        }

        /// <summary>
        /// Gets the reading pace for a specific user
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>A response containing the user's reading pace (pages per day)</returns>
        public override async Task<GetUserReadingPaceResponse> GetUserReadingPace(GetUserReadingPaceRequest request, ServerCallContext context)
        {
            try
            {
                logger.LogInformation("GetUserReadingPace called with user_id: {UserId}, book_id: {BookId}",
                    request.UserId, request.BookId);

                // Input validation
                if (request == null)
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));

                var userIdParsed = Guid.TryParse(request.UserId, out var userId);
                var bookIdParsed = Guid.TryParse(request.BookId, out var bookId);
                var query = new Application.Queries.Users.GetUserReadingPace.GetUserReadingPaceQuery(userId, bookId);
                var result = await mediator.Send(query, context.CancellationToken);

                var response = new GetUserReadingPaceResponse
                {
                    Pace = result ?? 0
                };

                logger.LogInformation("GetUserReadingPace completed successfully for user {UserId}, book {BookId}, pace: {Pace}",
                    request.UserId, request.BookId, response.Pace);
                return response;
            }
            catch (ApplicationValidationException ex)
            {
                logger.LogWarning("Validation failed for GetUserReadingPace: {ValidationErrors}",
                    ex.ValidationFailures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"Validation failed: {string.Join(", ", ex.ValidationFailures.Select(f => f.ErrorMessage))}"));
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error in GetUserReadingPace");
                throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"));
            }
        }

        private static UserDto MapUserDtoToProtoDto(DTOs.UserDTO userDto) =>
            new UserDto
            {
                Id = userDto.Id.ToString(),
                Name = userDto.Name ?? string.Empty,
                Email = userDto.Email ?? string.Empty,
                PhoneNumber = userDto.PhoneNumber ?? string.Empty,
                MembershipDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(userDto.MembershipDate.ToUniversalTime())
            };
    }
}
