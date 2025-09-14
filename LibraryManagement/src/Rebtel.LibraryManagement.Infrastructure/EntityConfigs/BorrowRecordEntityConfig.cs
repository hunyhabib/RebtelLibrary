using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs
{
    internal class BorrowRecordEntityConfig : IEntityTypeConfiguration<BorrowRecord>
    {
        public void Configure(EntityTypeBuilder<BorrowRecord> builder)
        {
            builder.HasKey(br => br.Id);

            // Configure shadow property for UserId foreign key
            builder.Property<Guid>("UserId")
                .IsRequired();

            builder.Property(br => br.BorrowDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(br => br.ReturnDate)
                .IsRequired(false); // Nullable

            builder.Ignore(br => br.MaxAllowedReturnDate);

            // Configure many-to-many relationship with Books
            builder.HasMany(br => br.Books)
                .WithMany(b => b.BorrowRecords)
                .UsingEntity(
                    j => j.HasOne(typeof(Book)).WithMany().HasForeignKey("BookId"),
                    j => j.HasOne(typeof(BorrowRecord)).WithMany().HasForeignKey("BorrowRecordId"),
                    j => j.HasData(BorrowRecordSeedData.GetBorrowRecordBooks()));

            builder.HasData(BorrowRecordSeedData.GetBorrowRecords());
        }
    }
}
