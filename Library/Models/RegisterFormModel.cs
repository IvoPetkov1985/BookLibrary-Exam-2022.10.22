using System.ComponentModel.DataAnnotations;
using static Library.Data.Constants.DataConstants;

namespace Library.Models
{
    public class RegisterFormModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
