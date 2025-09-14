namespace Rebtel.LibraryManagement.DTOs
{
    public record BookDTO(Guid Id, string Title, string Author, string ISBN, int PageCount, DateTime PublishedDate, int CopiesAvailable);
}
