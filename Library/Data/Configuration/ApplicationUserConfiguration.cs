using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Library.Data.Constants.DataConstants;

namespace Library.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(au => au.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Property(au => au.Email)
                .HasMaxLength(UserEmailMaxLength)
                .IsRequired();
        }
    }
}
