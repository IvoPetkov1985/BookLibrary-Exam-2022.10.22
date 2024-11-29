using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class ApplicationUserBookConfiguration : IEntityTypeConfiguration<ApplicationUserBook>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserBook> builder)
        {
            builder.HasKey(ub => new
            {
                ub.ApplicationUserId,
                ub.BookId
            });

            builder.HasOne(ub => ub.Book)
                .WithMany(b => b.ApplicationUsersBooks)
                .HasForeignKey(ub => ub.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ub => ub.ApplicationUser)
                .WithMany(u => u.ApplicationUsersBooks)
                .HasForeignKey(ub => ub.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
