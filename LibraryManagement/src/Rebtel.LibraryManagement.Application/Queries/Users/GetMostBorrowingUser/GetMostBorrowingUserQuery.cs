using MediatR;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetMostBorrowingUser;

public record GetMostBorrowingUserQuery(DateTime StartDate, DateTime EndDate, int Count) : IRequest<IEnumerable<UserDTO>>;
