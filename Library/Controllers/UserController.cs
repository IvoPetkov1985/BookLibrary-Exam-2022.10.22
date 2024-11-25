using Library.Data.DataModels;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Library.Data.Constants.DataConstants;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Library.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, BookContrName);
            }

            RegisterFormModel model = new();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            ApplicationUser user = new()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, BookContrName);
            }

            LoginFormModel model = new();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            ApplicationUser user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction(AllActionName, BookContrName);
                }
            }

            ModelState.AddModelError(string.Empty, LoginErrorMessage);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(IndexActionName, HomeContrName);
        }
    }
}
