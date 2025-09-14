using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Gets the most borrowing user
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="usersCount">The users count.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<User>> GetMostBorrowingUser(DateTime startDate, DateTime endDate, int usersCount,CancellationToken cancellationToken);

    /// <summary>
    /// Gets the user reading pace.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="bookId">The book user borrowed to calculate pace on.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Page Count else null if user not found or book not borrowed</returns>
    Task<int?> GetUserReadingPace(Guid userId,Guid bookId,CancellationToken cancellationToken);
}
