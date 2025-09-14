using Microsoft.EntityFrameworkCore;
using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.Domain.Repositories;

namespace Rebtel.LibraryManagement.Infrastructure.Repositories
{
    internal class UserRepository(LibraryManagementContext context) : IUserRepository
    {
        //<inheritdoc />
        public async Task<IEnumerable<User>> GetMostBorrowingUser(DateTime startDate, DateTime endDate, int usersCount, CancellationToken cancellationToken) =>
            await context.Users
                .Where(u => u.BorrowRecords.Any(br => br.BorrowDate >= startDate && br.BorrowDate <= endDate))
                .Select(u => new
                {
                    User = u,
                    BorrowCount = u.BorrowRecords.Count(br => br.BorrowDate >= startDate && br.BorrowDate <= endDate)
                })
                .OrderByDescending(x => x.BorrowCount)
                .Take(usersCount)
                .Select(x => x.User)
                .ToListAsync(cancellationToken);

        //<inheritdoc />
        public async Task<int?> GetUserReadingPace(Guid userId, Guid bookId, CancellationToken cancellationToken)
        {
            var result = await context.BorrowRecords
                .Where(br => br.User.Id == userId &&
                           br.ReturnDate != null &&
                           br.Books.Any(b => b.Id == bookId))
                .Select(br => new
                {
                    Book = br.Books.First(b => b.Id == bookId),
                    DaysToRead = (int)(br.ReturnDate!.Value - br.BorrowDate).TotalDays
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result == null ? null : (int)Math.Round((double)result.Book.PageCount / result.DaysToRead);
        }
    }
}
