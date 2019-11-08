using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        // Request to view account/signup
        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();  
        }

    }
}