using MediatR;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetUserReadingPace;

public record GetUserReadingPaceQuery(Guid UserId, Guid BookId) : IRequest<int?>;
