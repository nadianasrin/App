using System;
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
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
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

        private string CurrentlyLoggedInUserId(string username)
        {
            return _userManager.FindByNameAsync(username).Result.Id;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(Registration registration)
        {
            registration.RegistrationId = Guid.NewGuid().ToString().Replace("-", "");

            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id = registration.RegistrationId,
                    Role = registration.Role,
                    UserName = registration.StudentVarsityId,
                    Student_FullName = registration.StudentFullName,
                    Email = registration.RegUserEmail
                };
                var result = await _userManager.CreateAsync(user, registration.RegUserPassword);

                if(result.Succeeded)
                {
                    _context.Add(registration);
                    await _context.SaveChangesAsync();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("signin", "account", new {sid = registration.RegistrationId}); 
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
                    return RedirectToAction("index", "Student"); 
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(login);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}