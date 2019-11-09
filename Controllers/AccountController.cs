using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // Request to view account/signup
        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Signup(Registration registration)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser{UserName = registration.StudentVarsityId, Email = registration.RegUserEmail};
                var result = await _userManager.CreateAsync(user, registration.RegUserPassword);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("signin", "account"); 
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Signin(Login login)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.LoginUserId, login.LoginUserPassword, login.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("index", "home"); 
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(login);
        }
        
    }
}