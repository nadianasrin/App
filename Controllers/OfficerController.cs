using System;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class OfficerController : Controller
    {

         private readonly ApplicationDbContext _context;
         private readonly UserManager<ApplicationUser> _userManager;

         public OfficerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
         {
             _context = context;
             _userManager = userManager;
         }

        public string getUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }

        public string getUserRole(string userId)
        {
            try
            {
                var role = _context.OfficerReg.Find(userId);
                return role.Role;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public IActionResult EnrolledStudent()
        {
            return View();
        }
        
        [HttpGet("/Teacher/getStudentEnrolledCourses")]
        public async Task<JsonResult> getStudentEnrolledCourses([FromBody]Semester semester)
        {
            try
            {
                _context.Add(semester);
                await _context.SaveChangesAsync();
                var semesters = await _context.Semester.ToListAsync();

                return Json(semesters);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}