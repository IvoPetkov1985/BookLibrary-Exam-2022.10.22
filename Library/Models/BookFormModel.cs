using System.ComponentModel.DataAnnotations;
using static Library.Data.Common.DataConstants;

namespace Library.Models
{
    public class BookFormModel
    {
        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength, ErrorMessage = BookInputErrorMsg)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength, ErrorMessage = BookInputErrorMsg)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength, ErrorMessage = BookInputErrorMsg)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), BookRatingMinValue, BookRatingMaxValue, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
