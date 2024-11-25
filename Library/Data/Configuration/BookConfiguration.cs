using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book()
            {
                Id = 1,
                Title = "Lorem Ipsum",
                Author = "Dolor Sit",
                ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CategoryId = 1,
                Rating = 9.5m
            });

            builder.Property(b => b.Rating)
                .HasPrecision(18, 2);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
