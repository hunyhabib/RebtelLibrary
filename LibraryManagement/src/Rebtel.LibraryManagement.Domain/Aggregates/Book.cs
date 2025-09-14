using Rebtel.LibraryManagement.Domain.Shared;

namespace Rebtel.LibraryManagement.Domain.Aggregates;

public class Book : IAggregateRoot
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public int CopiesAvailable { get; set; }

    public List<BorrowRecord> BorrowRecords { get; set; } = new();
}
