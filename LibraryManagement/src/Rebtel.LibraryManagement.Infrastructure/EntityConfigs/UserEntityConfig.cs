using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rebtel.LibraryManagement.Domain.Aggregates;
using Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs
{
    internal class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(320); // Max length for email addresses

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.MembershipDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Create unique index on Email
            builder.HasIndex(u => u.Email)
                .IsUnique();

            // Create indexes for common queries
            builder.HasIndex(u => u.Name);
            builder.HasIndex(u => u.MembershipDate);

            // Configure the one-to-many relationship with BorrowRecord
            builder.HasMany(u => u.BorrowRecords)
                .WithOne(br => br.User)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(UserSeedData.Users);
        }
    }
}
