using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class OfficerController : Controller
    {

         private readonly ApplicationDbContext _context;

        public OfficerController(ApplicationDbContext context)
        {
            _context = context;
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