using Microsoft.AspNetCore.Identity;

namespace Library.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
