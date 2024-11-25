using System.ComponentModel.DataAnnotations;
using static Library.Data.Constants.DataConstants;

namespace Library.Models
{
    public class LoginFormModel
    {
        [Required]
        [Display(Name = UserNameDisplay)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
