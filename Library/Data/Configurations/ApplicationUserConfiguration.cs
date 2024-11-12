using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Library.Data.Common.DataConstants;

namespace Library.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(ab => ab.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Property(ab => ab.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();
        }
    }
}
