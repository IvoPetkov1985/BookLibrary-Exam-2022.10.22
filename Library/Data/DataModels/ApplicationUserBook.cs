using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.DataModels
{
    [Comment("Mapping table between the books and the users")]
    public class ApplicationUserBook
    {
        [Required]
        [Comment("User identifier")]
        public string ApplicationUserId { get; set; } = string.Empty;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        [Comment("Book identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
