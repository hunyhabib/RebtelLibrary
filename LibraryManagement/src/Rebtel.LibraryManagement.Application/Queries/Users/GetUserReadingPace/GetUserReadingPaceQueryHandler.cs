using AutoMapper;
using MediatR;
using Rebtel.LibraryManagement.Domain.Repositories;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetUserReadingPace;

internal class GetUserReadingPaceQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserReadingPaceQuery, int?>
{
    public async Task<int?> Handle(GetUserReadingPaceQuery request, CancellationToken cancellationToken) =>
        await userRepository.GetUserReadingPace(request.UserId, request.BookId, cancellationToken);
}
