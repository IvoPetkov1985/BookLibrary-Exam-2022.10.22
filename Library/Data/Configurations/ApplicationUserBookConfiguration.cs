using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class ApplicationUserBookConfiguration : IEntityTypeConfiguration<ApplicationUserBook>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserBook> builder)
        {
            builder.HasKey(ab => new
            {
                ab.ApplicationUserId,
                ab.BookId
            });
        }
    }
}
