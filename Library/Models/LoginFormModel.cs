using System.ComponentModel.DataAnnotations;
using static Library.Data.Common.DataConstants;

namespace Library.Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [Display(Name = UserNameDisplayName)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
