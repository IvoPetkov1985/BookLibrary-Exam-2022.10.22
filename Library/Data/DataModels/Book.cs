using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.Common.DataConstants;

namespace Library.Data.DataModels
{
    [Comment("A single book from the library with its properties")]
    public class Book
    {
        [Key]
        [Comment("Book identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Book title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(AuthorMaxLength)]
        [Comment("The author(s) of the book")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Some details about the book")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Link to the image of the book")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Book rating")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public IEnumerable<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
