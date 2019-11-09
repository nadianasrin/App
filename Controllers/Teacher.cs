using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class Teacher : Controller
    {
        public IActionResult EnrolledStudent()
        {
            return View();
        }
        
    }
}