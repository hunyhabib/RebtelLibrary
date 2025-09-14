using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs
{
    internal class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(b => b.PageCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(b => b.PublishedDate)
                .IsRequired();

            builder.Property(b => b.CopiesAvailable)
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasIndex(b => b.ISBN)
                .IsUnique();
            builder.HasIndex(b => b.Author);
            builder.HasIndex(b => b.Title);
            builder.HasIndex(b => b.PublishedDate);

            builder.HasData(BookSeedData.Books);
        }
    }
}
