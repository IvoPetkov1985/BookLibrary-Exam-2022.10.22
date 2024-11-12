using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Library.Data.Common.DataConstants;

namespace Library.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName(UsernameDisplay)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
