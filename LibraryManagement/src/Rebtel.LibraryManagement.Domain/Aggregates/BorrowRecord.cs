using Rebtel.LibraryManagement.Domain.Shared;

namespace Rebtel.LibraryManagement.Domain.Aggregates;
public class BorrowRecord : IAggregateRoot
{
    public Guid Id { get; set; }
    public List<Book> Books { get; set; }
    public User User { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public DateTime MaxAllowedReturnDate => BorrowDate.AddDays(30);
}
