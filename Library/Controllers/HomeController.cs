using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Library.Data.Constants.DataConstants;

namespace Library.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, BookContrName);
            }

            return View();
        }
    }
}
