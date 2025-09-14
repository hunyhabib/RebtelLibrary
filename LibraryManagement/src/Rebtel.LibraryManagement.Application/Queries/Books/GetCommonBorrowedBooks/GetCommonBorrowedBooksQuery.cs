using MediatR;
using Rebtel.LibraryManagement.DTOs;

namespace Rebtel.LibraryManagement.Application.Queries.Books.GetCommonBorrowedBooks
{
    public record GetCommonBorrowedBooksQuery(Guid BookId, int Count) : IRequest<IEnumerable<BookDTO>>;
}
