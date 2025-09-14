using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Profiles
{
    internal class UsersProfile : AutoMapper.Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
