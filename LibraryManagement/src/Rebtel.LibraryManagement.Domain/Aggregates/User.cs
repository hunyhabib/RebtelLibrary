using Rebtel.LibraryManagement.Domain.Shared;

namespace Rebtel.LibraryManagement.Domain.Aggregates;

public class User : IAggregateRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime MembershipDate { get; set; }
    public List<BorrowRecord> BorrowRecords { get; set; } = new();  
}
