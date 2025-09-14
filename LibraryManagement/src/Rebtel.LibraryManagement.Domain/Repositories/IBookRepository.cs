using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Domain.Repositories;

public interface IBookRepository : IRepository<Book>
{
    /// <summary>
    /// Gets the most borrowed books.
    /// </summary>
    /// <param name="count">The numebr of books returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Book>> GetMostBorrowedBooks(int count, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the common borrowed books with the book passed.
    /// </summary>
    /// <param name="bookId">The book identifier.</param>
    /// <param name="count">The number of common borrowed books to retrieve.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Book>> GetCommonBorrowedBooks(Guid bookId, int count, CancellationToken cancellationToken);
}
