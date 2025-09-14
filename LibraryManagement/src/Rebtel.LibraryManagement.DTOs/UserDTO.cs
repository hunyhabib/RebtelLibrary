using System;

namespace Rebtel.LibraryManagement.DTOs
{
    public record UserDTO(Guid Id, string Name, string Email, string PhoneNumber, DateTime MembershipDate);
}
