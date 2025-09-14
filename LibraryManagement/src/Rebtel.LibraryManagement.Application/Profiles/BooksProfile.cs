using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Profiles
{
    internal class BooksProfile : AutoMapper.Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
