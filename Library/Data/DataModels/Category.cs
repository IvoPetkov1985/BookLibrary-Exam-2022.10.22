using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Data.Constants.DataConstants;

namespace Library.Data.DataModels
{
    [Comment("The book category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
