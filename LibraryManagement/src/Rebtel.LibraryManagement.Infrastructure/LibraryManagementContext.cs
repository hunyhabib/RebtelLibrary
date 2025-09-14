using Microsoft.EntityFrameworkCore;
using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Infrastructure
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext()
        {

        }
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementContext).Assembly);
        }
    }
}
