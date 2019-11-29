using System;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class StudentController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET request from 
//        public IActionResult Index()
//        {
//            return View();
//        }

        // get currently logged in user
        public string GetUser()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
        
        // get currently logged in user role
        public string GetUserId(string userId)
        {
            try
            {
                var role = _context.OfficerReg.Find(userId);
                return role.Role;
            }
            catch (Exception )
            {
                return null;
            }
        }
        
        public async Task<IActionResult> Index(string sid)
        {
            var student = await _context.Student.FirstOrDefaultAsync(s => s.Registration.RegistrationId == sid);
            
            return View(student);
        }
    }
}