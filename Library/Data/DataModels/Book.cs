using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.Constants.DataConstants;

namespace Library.Data.DataModels
{
    [Comment("The book itself")]
    public class Book
    {
        [Key]
        [Comment("Book identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        [Comment("Book official title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(BookAuthorNameMaxLength)]
        [Comment("The author(s) of the book")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(BookDescriptionMaxLength)]
        [Comment("Details about the book")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(BookImageUrlMaxLength)]
        [Comment("Link to the image of the book")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Rating of the book")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public IEnumerable<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
