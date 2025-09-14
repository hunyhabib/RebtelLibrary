using Microsoft.EntityFrameworkCore;
using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.Domain.Repositories;

namespace Rebtel.LibraryManagement.Infrastructure.Repositories;

internal class BookRepository(LibraryManagementContext context) : IBookRepository
{
    //<inheritdoc />
    public async Task<IEnumerable<Book>> GetCommonBorrowedBooks(Guid bookId, int count, CancellationToken cancellationToken)
    {
        var commonBooks = await context.BorrowRecords
            .Include(br => br.Books)
            .Where(br => br.Books.Any(b => b.Id == bookId))
            .SelectMany(br => br.Books.Where(b => b.Id != bookId))
            .GroupBy(b => b)
            .Select(g => new { Book = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync(cancellationToken);

        return commonBooks;
    }

    //<inheritdoc />
    public async Task<IEnumerable<Book>> GetMostBorrowedBooks(int count, CancellationToken cancellationToken) =>
         await context.Books
            .Select(book => new
            {
                Book = book,
                BorrowCount = book.BorrowRecords.Count()
            })
            .OrderByDescending(x => x.BorrowCount)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync(cancellationToken);

}
