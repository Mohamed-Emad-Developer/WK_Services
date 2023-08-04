using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Models.User;
using WK_Services.Utility;

namespace WK_Services.Presentation.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Incorrect Email or Password");
                }
                else
                {
                    var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
                    if (checkPassword)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: login.RememberPassword);
                        if (string.IsNullOrWhiteSpace(returnUrl))
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            return LocalRedirect(returnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Email or Password");
                    }

                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
 
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        

    }
}