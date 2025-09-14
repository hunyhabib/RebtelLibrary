using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Rebtel.LibraryManagement.Contracts;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Api.Profiles
{
    public class ProtoToDtoProfile : Profile
    {
        public ProtoToDtoProfile()
        {
            // Base type mappings for protobuf types
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(src => src.ToDateTime());
            
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(src => Timestamp.FromDateTime(src.ToUniversalTime()));

            // Book mappings
            CreateMap<BookDto, BookDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.Isbn))
                .ForMember(dest => dest.PageCount, opt => opt.MapFrom(src => src.PageCount))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate))
                .ForMember(dest => dest.CopiesAvailable, opt => opt.MapFrom(src => src.CopiesAvailable));

            // User mappings
            CreateMap<UserDto, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.MembershipDate, opt => opt.MapFrom(src => src.MembershipDate));
        }
    }
}
