using AutoMapper;
using MediatR;
using Rebtel.LibraryManagement.Domain.Repositories;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetMostBorrowingUser;

internal class GetMostBorrowingUserQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetMostBorrowingUserQuery, IEnumerable<UserDTO>>
{
    public async Task<IEnumerable<UserDTO>> Handle(GetMostBorrowingUserQuery request, CancellationToken cancellationToken) =>
        mapper.Map<IEnumerable<UserDTO>>(await userRepository.GetMostBorrowingUser(request.StartDate, request.EndDate, request.Count, cancellationToken));
}
