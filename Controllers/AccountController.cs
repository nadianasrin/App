using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnurl = returnUrl;
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnurl = returnUrl;
            return View();
        }

        public async Task<IActionResult> Register(Registration registration, string returnUrl)
        {
            return View(registration);
        }

    }
}